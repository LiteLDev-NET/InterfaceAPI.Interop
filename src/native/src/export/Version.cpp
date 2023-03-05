#include "../global.h"
#include <llapi/LLAPI.h>

extern "C"
{
    LLNET_EXPORT void ctor_Version(ll::Version* ptr,
        int major, int minor, int revision, ll::Version::Status status)
    {
        *ptr = ll::Version(major, minor, revision, status);
    }

    LLNET_EXPORT bool operator_lessThan(ll::Version* l, ll::Version* r)
    {
        return *l < *r;
    }

    LLNET_EXPORT bool operator_geraterThan(ll::Version* l, ll::Version* r)
    {
        return *l > *r;
    }

    LLNET_EXPORT bool operator_lessThanOrEqual(ll::Version* l, ll::Version* r)
    {
        return *r <= *l;
    }

    LLNET_EXPORT bool operator_geraterThanOrEqual(ll::Version* l, ll::Version* r)
    {
        return *r >= *l;
    }

    LLNET_EXPORT bool operator_equality(ll::Version* l, ll::Version* r)
    {
        return *r == *l;
    }
}