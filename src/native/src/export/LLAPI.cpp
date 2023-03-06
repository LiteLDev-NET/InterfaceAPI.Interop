#include "../global.h"
#include <llapi/LLAPI.h>
#include <llapi/utils/StringHelper.h>

extern "C"
{
    struct RegisterPluginArgs
    {
        struct pair
        {
            wchar_t* key;
            wchar_t* value;
        };
        pair* array;
        size_t length;
    };

    LLNET_EXPORT bool LLAPI_registerPlugin(
        HMODULE handle,
        wchar_t* name,
        wchar_t* desc,
        void* pVersion,
        RegisterPluginArgs& args)
    {
        std::map<std::string, std::string> map;
        RegisterPluginArgs::pair* ptr = args.array;

        for (size_t i = 0; i < args.length; ++i, ++ptr)
        {
            map.emplace(std::make_pair(wstr2str(ptr->key), wstr2str(ptr->value)));
        }

        return ::RegisterPlugin(handle, wstr2str(name), wstr2str(desc),
            *reinterpret_cast<ll::Version*>(pVersion), std::move(map));
    }
}