#include "../global.h"
#include <string>
#include <llapi/utils/StringHelper.h>

extern "C"
{
    LLNET_EXPORT void* Std_ctor_string(wchar_t* str)
    {
        return new std::string(wstr2str(str));
    }

    LLNET_EXPORT void Std_dtor_string(void** str)
    {
        delete* reinterpret_cast<std::string**>(str);
        *str = nullptr;
    }
}