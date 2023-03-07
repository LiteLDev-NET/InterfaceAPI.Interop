using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace LiteLoader.InterfaceAPI.Interop;

public static class Version
{
    [DllImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
        CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "ctor_Version", SetLastError = true)]
    
    [SuppressUnmanagedCodeSecurity]
    public static extern unsafe void ctor(void* versionPtr, int major, int minor, int revvision, int status);

    [DllImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
        CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "Version_operator_lessThan", SetLastError = true)]
    
    [SuppressUnmanagedCodeSecurity]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern unsafe bool operator_lessThan(void* l, void* r);

    [DllImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
        CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "Version_operator_geraterThan", SetLastError = true)]
    
    [SuppressUnmanagedCodeSecurity]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern unsafe bool operator_geraterThan(void* l, void* r);

    [DllImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
        CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "Version_operator_lessThanOrEqual", SetLastError = true)]
    
    [SuppressUnmanagedCodeSecurity]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern unsafe bool operator_lessThanOrEqual(void* l, void* r);

    [DllImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
        CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "Version_operator_geraterThanOrEqual", SetLastError = true)]
    
    [SuppressUnmanagedCodeSecurity]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern unsafe bool operator_geraterThanOrEqual(void* l, void* r);

    [DllImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
        CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "Version_operator_equality", SetLastError = true)]
    
    [SuppressUnmanagedCodeSecurity]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern unsafe bool operator_equality(void* l, void* r);

    [DllImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
        CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "Version_toString", SetLastError = true)]
    
    [SuppressUnmanagedCodeSecurity]
    public static extern unsafe char* ToString(void* _this, [MarshalAs(UnmanagedType.U1)] bool needStatus);

    [DllImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
        CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "Version_parse", SetLastError = true)]
    
    [SuppressUnmanagedCodeSecurity]
    public static extern unsafe void Parse(void* pVersion, [MarshalAs(UnmanagedType.LPWStr)] string str);
}
