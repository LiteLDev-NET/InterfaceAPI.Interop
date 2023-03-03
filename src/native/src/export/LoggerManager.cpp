#include "LoggerManager.hpp"
#include <llapi/LoggerAPI.h>
#include <llapi/utils/StringHelper.h>


Logger LoggerManager::defaultLogger = Logger();

std::unordered_map<LoggerID, std::pair<RefCount, std::unique_ptr<::Logger>>> LoggerManager::LoggerData = {};

std::tuple<LoggerManager::IsDeleted, LoggerID, Logger*>  LoggerManager::OperatingLogger = { true,0,nullptr };

inline std::pair<LoggerID, bool> LoggerManager::CreateLogger(const std::string str)
{
    LoggerID id = do_hash(str.c_str());
    auto pair = LoggerData.insert(std::make_pair(id, std::pair<RefCount, std::unique_ptr<::Logger>>(1, new Logger(str))));
    OperatingLogger = { false,id,pair.first->second.second.get() };
    return std::make_pair(id, pair.second);
}

inline void LoggerManager::WriteLine(LoggerID id, OutputStreamType t, const std::wstring& wstr)
{
    ::Logger::OutputStream* pstream = nullptr;
    ::Logger* plogger = nullptr;

    //Optimizing
    if (!std::get<0>(OperatingLogger) && id == std::get<1>(OperatingLogger))
    {
        plogger = std::get<2>(OperatingLogger);
        goto jmp;
    }

    {
        auto iter = LoggerData.find(id);
        if (iter != LoggerData.end())
            plogger = iter->second.second.get();
        else
            plogger = &defaultLogger;
        OperatingLogger = { false,id,plogger };
    }

jmp:

    switch (t)
    {
    case LoggerManager::OutputStreamType::debug:
        pstream = &plogger->debug;
        break;
    case LoggerManager::OutputStreamType::info:
        pstream = &plogger->info;
        break;
    case LoggerManager::OutputStreamType::warn:
        pstream = &plogger->warn;
        break;
    case LoggerManager::OutputStreamType::error:
        pstream = &plogger->error;
        break;
    case LoggerManager::OutputStreamType::fatal:
        pstream = &plogger->fatal;
        break;
    default:
        break;
    }

    (*pstream)(TextEncoding::fromUnicode(wstr));
}

inline void LoggerManager::WriteLine(OutputStreamType t, const std::string& str)
{
    ::Logger::OutputStream* pstream = nullptr;
    switch (t)
    {
    case LoggerManager::OutputStreamType::debug:
        pstream = &defaultLogger.debug;
        break;
    case LoggerManager::OutputStreamType::info:
        pstream = &defaultLogger.info;
        break;
    case LoggerManager::OutputStreamType::warn:
        pstream = &defaultLogger.warn;
        break;
    case LoggerManager::OutputStreamType::error:
        pstream = &defaultLogger.error;
        break;
    case LoggerManager::OutputStreamType::fatal:
        pstream = &defaultLogger.fatal;
        break;
    default:
        break;
    }
    (*pstream)(str);
}

inline void LoggerManager::WriteLine(OutputStreamType t, const std::string str, nullptr_t)
{
    LoggerManager::WriteLine(t, str);
}

inline void LoggerManager::DeleteLogger(LoggerID id)
{
    auto iter = LoggerData.find(id);
    if (iter != LoggerData.end())
    {
        --(iter->second.first);
        if (!iter->second.first)//iter->second.first==0
        {
            LoggerData.erase(iter);
        }
    }
    if (!std::get<0>(OperatingLogger) && id == std::get<1>(OperatingLogger))
        OperatingLogger = { true,0,nullptr };
}


inline bool LoggerManager::tryLock(LoggerID id)
{
    ::Logger* plogger = nullptr;
    if (!std::get<0>(OperatingLogger) && id == std::get<1>(OperatingLogger))
    {
        plogger = std::get<2>(OperatingLogger);
        goto jmp;
    }

    {
        auto iter = LoggerData.find(id);
        if (iter != LoggerData.end())
            plogger = iter->second.second.get();
        else
            return false;
    }

jmp:

    return plogger->tryLock();
}

inline bool LoggerManager::lock(LoggerID id)
{
    ::Logger* plogger = nullptr;
    if (!std::get<0>(OperatingLogger) && id == std::get<1>(OperatingLogger))
    {
        plogger = std::get<2>(OperatingLogger);
        goto jmp;
    }

    {
        auto iter = LoggerData.find(id);
        if (iter != LoggerData.end())
            plogger = iter->second.second.get();
        else
            return false;
    }

jmp:

    return plogger->lock();
}

inline bool LoggerManager::unlock(LoggerID id)
{
    ::Logger* plogger = nullptr;
    if (!std::get<0>(OperatingLogger) && id == std::get<1>(OperatingLogger))
    {
        plogger = std::get<2>(OperatingLogger);
        goto jmp;
    }

    {
        auto iter = LoggerData.find(id);
        if (iter != LoggerData.end())
            plogger = iter->second.second.get();
        else
            return false;
    }

jmp:

    return plogger->unlock();
}

inline bool LoggerManager::setDefaultFile(const std::string& logFile, bool appendMode)
{
    return ::Logger::setDefaultFile(logFile, appendMode);
}

inline bool LoggerManager::setDefaultFile(std::nullptr_t a0)
{
    return ::Logger::setDefaultFile(a0);
}

inline bool LoggerManager::setFile(LoggerID id, const std::string& logFile, bool appendMode)
{
    ::Logger* plogger = nullptr;
    if (!std::get<0>(OperatingLogger) && id == std::get<1>(OperatingLogger))
    {
        plogger = std::get<2>(OperatingLogger);
        goto jmp;
    }

    {
        auto iter = LoggerData.find(id);
        if (iter != LoggerData.end())
            plogger = iter->second.second.get();
        else
            return false;
    }

jmp:
    return plogger->setFile(logFile, appendMode);
}

inline bool LoggerManager::setFile(LoggerID id, nullptr_t)
{
    ::Logger* plogger = nullptr;
    if (!std::get<0>(OperatingLogger) && id == std::get<1>(OperatingLogger))
    {
        plogger = std::get<2>(OperatingLogger);
        goto jmp;
    }

    {
        auto iter = LoggerData.find(id);
        if (iter != LoggerData.end())
            plogger = iter->second.second.get();
        else
            return false;
    }


jmp:
    return plogger->setFile(nullptr);
}

inline std::string LoggerManager::GetTitle(LoggerID id)
{
    ::Logger* plogger = nullptr;
    if (!std::get<0>(OperatingLogger) && id == std::get<1>(OperatingLogger))
    {
        plogger = std::get<2>(OperatingLogger);
        goto jmp;
    }

    {
        auto iter = LoggerData.find(id);
        if (iter != LoggerData.end())
            plogger = iter->second.second.get();
        else
            return std::string();
    }

jmp:
    return plogger->title;
}

inline void LoggerManager::SetTitle(LoggerID id, const std::string& _title)
{
    ::Logger* plogger = nullptr;
    if (!std::get<0>(OperatingLogger) && id == std::get<1>(OperatingLogger))
    {
        plogger = std::get<2>(OperatingLogger);
        goto jmp;
    }

    {
        auto iter = LoggerData.find(id);
        if (iter != LoggerData.end())
            plogger = iter->second.second.get();
        else
            return;
    }

jmp:

    plogger->title = _title;
}

extern "C"
{
    LLNET_EXPORT bool LoggerManager_CreateLogger(LoggerID& id, wchar_t* title)
    {

        auto pair = LoggerManager::CreateLogger(wstr2str(title));
        id = pair.first;
        return pair.second;
    }

    LLNET_EXPORT void LoggerManager_DeleteLogger(LoggerID id)
    {
        return LoggerManager::DeleteLogger(id);
    }

    LLNET_EXPORT void LoggerManager_SetTitle(LoggerID id, wchar_t* title)
    {
        LoggerManager::SetTitle(id, wstr2str(title));
    }

    LLNET_EXPORT bool LoggerManager_GetTitle(LoggerID id, wchar_t* buffer, size_t bufferLength)
    {
        auto title = str2wstr(LoggerManager::GetTitle(id));
        if (bufferLength < title.size())
            return false;

        memcpy(buffer, title.c_str(), title.size());
        return true;
    }

    LLNET_EXPORT void LoggerManager_WriteLine(LoggerID id, LoggerManager::OutputStreamType type, wchar_t* str)
    {
        return LoggerManager::WriteLine(id, type, str);
    }
}