﻿using System;
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
    [MethodImpl(MethodImplOptions.Unmanaged)]
    [SuppressUnmanagedCodeSecurity]
    public static extern unsafe void ctor(void* versionPtr, int major, int minor, int revvision, int status);

    [DllImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
        CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "operator_lessThan", SetLastError = true)]
    [MethodImpl(MethodImplOptions.Unmanaged)]
    [SuppressUnmanagedCodeSecurity]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern unsafe bool operator_lessThan(void* l, void* r);
    
    [DllImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
        CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "operator_geraterThan", SetLastError = true)]
    [MethodImpl(MethodImplOptions.Unmanaged)]
    [SuppressUnmanagedCodeSecurity]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern unsafe bool operator_geraterThan(void* l, void* r);
    
    [DllImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
        CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "operator_lessThanOrEqual", SetLastError = true)]
    [MethodImpl(MethodImplOptions.Unmanaged)]
    [SuppressUnmanagedCodeSecurity]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern unsafe bool operator_lessThanOrEqual(void* l, void* r);
    
    [DllImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
        CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "operator_geraterThanOrEqual", SetLastError = true)]
    [MethodImpl(MethodImplOptions.Unmanaged)]
    [SuppressUnmanagedCodeSecurity]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern unsafe bool operator_geraterThanOrEqual(void* l, void* r);
    
    [DllImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
        CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "operator_equality", SetLastError = true)]
    [MethodImpl(MethodImplOptions.Unmanaged)]
    [SuppressUnmanagedCodeSecurity]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern unsafe bool operator_equality(void* l, void* r);
}
