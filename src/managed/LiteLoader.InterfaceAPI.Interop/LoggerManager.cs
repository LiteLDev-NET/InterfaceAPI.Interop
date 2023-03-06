using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace LiteLoader.InterfaceAPI.Interop;



public static class LoggerManager
{
    public enum OutputStreamType
    {
        debug = 0,
        info = 1,
        warn = 2,
        error = 3,
        fatal = 4
    };

#if (WINDOWS)
    [DllImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
            CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "LoggerManager_CreateLogger", SetLastError = true)]
    [MethodImpl(MethodImplOptions.Unmanaged)]
    [SuppressUnmanagedCodeSecurity]
    [return: MarshalAs(UnmanagedType.U1)]
    public static unsafe extern bool CreateLogger(ref ulong id, [MarshalAs(UnmanagedType.LPWStr)] string title);
#elif (LINUX)

#endif


#if (WINDOWS)
    [DllImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
            CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "LoggerManager_DeleteLogger", SetLastError = true)]
    [MethodImpl(MethodImplOptions.Unmanaged)]
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    public static unsafe extern void DeleteLogger(ulong id);
#elif (LINUX)

#endif

#if (WINDOWS)
    [DllImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
            CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "LoggerManager_SetTitle", SetLastError = true)]
    [MethodImpl(MethodImplOptions.Unmanaged)]
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    public static unsafe extern void SetTitle(ulong id, [MarshalAs(UnmanagedType.LPWStr)] string title);
#elif (LINUX)

#endif

#if (WINDOWS)
    [DllImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
            CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "LoggerManager_GetTitle", SetLastError = true)]
    [MethodImpl(MethodImplOptions.Unmanaged)]
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.U1)]
    public static unsafe extern bool GetTitle(ulong id, char* buffer, ulong bufferSize);
#elif (LINUX)

#endif

#if (WINDOWS)
    [DllImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
            CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "LoggerManager_WriteLine", SetLastError = true)]
    [MethodImpl(MethodImplOptions.Unmanaged)]
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    public static unsafe extern void WriteLine(ulong id, OutputStreamType type, [MarshalAs(UnmanagedType.LPWStr)] string str);
#elif (LINUX)

#endif
}