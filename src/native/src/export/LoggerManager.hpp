#pragma once

#include "../global.h"
#include <stdint.h>
#include <string>
#include <unordered_map>
#include <memory>

class Logger;

using LoggerID = uint64_t;

using RefCount = size_t;

class LoggerManager
{
public:
    LoggerManager() = delete;
public:
    enum class OutputStreamType {
        debug = 0,
        info = 1,
        warn = 2,
        error = 3,
        fatal = 4
    };
public:

    inline static std::pair<LoggerID, bool> CreateLogger(const std::string str);
    inline static void DeleteLogger(LoggerID id);

    inline static void SetTitle(LoggerID id, const std::string& _title);
    inline static std::string GetTitle(LoggerID id);


    inline static bool tryLock(LoggerID id);
    inline static bool lock(LoggerID id);
    inline static bool unlock(LoggerID id);
    inline static bool setDefaultFile(const std::string& logFile, bool appendMode);
    inline static bool setDefaultFile(std::nullptr_t a0);
    //static void endl(OutputStream& o);

    inline static bool setFile(LoggerID id, const std::string& logFile, bool appendMode = true);
    inline  bool setFile(LoggerID id, nullptr_t);

    inline static void WriteLine(LoggerID id, OutputStreamType t, const std::wstring& wstr);
    inline static void WriteLine(OutputStreamType t, const std::string& str);
    inline static void WriteLine(OutputStreamType t, const std::string str, nullptr_t);
private:
    typedef bool IsDeleted;
    static std::tuple<IsDeleted, LoggerID, Logger*>  OperatingLogger;
    static ::Logger defaultLogger;
    static std::unordered_map<LoggerID, std::pair<RefCount, std::unique_ptr<::Logger>>> LoggerData;
};