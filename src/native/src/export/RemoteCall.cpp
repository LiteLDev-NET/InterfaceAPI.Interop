#include "../global.h"

#include <llapi/RemoteCallAPI.h>
#include <llapi/utils/StringHelper.h>

extern "C"
{
    LLNET_EXPORT bool RemoteCall_hasFunc(wchar_t* nameSpace, wchar_t* funcName)
    {
        return ::RemoteCall::hasFunc(wstr2str(nameSpace), wstr2str(funcName));
    }

    LLNET_EXPORT bool RemoteCall_removeFunc(wchar_t* nameSpace, wchar_t* funcName)
    {
        return ::RemoteCall::removeFunc(wstr2str(nameSpace), wstr2str(funcName));
    }

    LLNET_EXPORT int RemoteCall_removeNameSpace(wchar_t* nameSpace)
    {
        return ::RemoteCall::removeNameSpace(wstr2str(nameSpace));
    }

    LLNET_EXPORT int RemoteCall_removeFuncs(void* vector)
    {
        return ::RemoteCall::removeFuncs(
            *reinterpret_cast<std::vector<std::pair<std::string, std::string>>*>(vector));
    }

    LLNET_EXPORT bool RemoteCall_exportFunc(wchar_t* nameSpace, wchar_t* fullName, void* callback, HMODULE handle)
    {
        return ::RemoteCall::exportFunc(
            wstr2str(nameSpace),
            wstr2str(fullName),
            reinterpret_cast<::RemoteCall::ValueType(*)(std::vector<::RemoteCall::ValueType>)>(callback),
            handle);
    }

    LLNET_EXPORT void* RemoteCall_importFunc(wchar_t* nameSpace, wchar_t* fullName)
    {
        return const_cast<::RemoteCall::CallbackFn*>(&::RemoteCall::importFunc(wstr2str(nameSpace), wstr2str(fullName)));
    }
}