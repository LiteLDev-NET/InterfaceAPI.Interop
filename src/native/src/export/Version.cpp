#include "../global.h"
#include <llapi/LLAPI.h>
#include <llapi/utils/StringHelper.h>

extern "C"
{
    LLNET_EXPORT void ctor_Version(ll::Version* ptr,
        int major, int minor, int revision, ll::Version::Status status)
    {
        *ptr = ll::Version(major, minor, revision, status);
    }

    LLNET_EXPORT bool Version_operator_lessThan(ll::Version* l, ll::Version* r)
    {
        return *l < *r;
    }

    LLNET_EXPORT bool Version_operator_geraterThan(ll::Version* l, ll::Version* r)
    {
        return *l > *r;
    }

    LLNET_EXPORT bool Version_operator_lessThanOrEqual(ll::Version* l, ll::Version* r)
    {
        return *r <= *l;
    }

    LLNET_EXPORT bool Version_operator_geraterThanOrEqual(ll::Version* l, ll::Version* r)
    {
        return *r >= *l;
    }

    LLNET_EXPORT bool Version_operator_equality(ll::Version* l, ll::Version* r)
    {
        return *r == *l;
    }

    LLNET_EXPORT wchar_t* Version_toString(ll::Version* _this, bool needStatus)
    {
        auto str = str2wstr(_this->toString(needStatus));
        auto size = str.size();
        auto buffer = new wchar_t[size];
        memcpy_s(buffer, size, str.c_str(), size);
        return buffer;
    }

    LLNET_EXPORT void Version_parse(void* pVersion, wchar_t* str)
    {
        *reinterpret_cast<ll::Version*>(pVersion) = ll::Version::parse(wstr2str(str));
    }
}