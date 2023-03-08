#include "../global.h"
#include <llapi/LLAPI.h>
#include <llapi/utils/StringHelper.h>

extern "C"
{
    struct string_pair
    {
        std::string* key;
        std::string* value;
    };
    LLNET_EXPORT bool LLAPI_registerPlugin(
        HMODULE handle,
        wchar_t* name,
        wchar_t* desc,
        void* pVersion,
        std::vector<string_pair>* args)
    {
        std::map<std::string, std::string> map;

        for (auto& [k, v] : *args)
        {
            map.emplace(std::make_pair(*k, *v));
        }

        return ::RegisterPlugin(handle, wstr2str(name), wstr2str(desc),
            *reinterpret_cast<ll::Version*>(pVersion), std::move(map));
    }
}