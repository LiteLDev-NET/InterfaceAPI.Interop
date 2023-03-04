#define WINDOWS

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace LiteLoader.InterfaceAPI.Interop;



public static partial class LoggerManager
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
    [LibraryImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
        EntryPoint = "LoggerManager_CreateLogger", SetLastError = true)]
    [MethodImpl(MethodImplOptions.Unmanaged)]
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.U1)]
    public static unsafe partial bool CreateLogger(ref ulong id, char* title);
#elif (LINUX)

#endif


#if (WINDOWS)
    [LibraryImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
        EntryPoint = "LoggerManager_DeleteLogger", SetLastError = true)]
    [MethodImpl(MethodImplOptions.Unmanaged)]
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    public static unsafe partial void DeleteLogger(ulong id);
#elif (LINUX)

#endif

#if (WINDOWS)
    [LibraryImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
        EntryPoint = "LoggerManager_SetTitle", SetLastError = true)]
    [MethodImpl(MethodImplOptions.Unmanaged)]
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    public static unsafe partial void SetTitle(ulong id, char* title);
#elif (LINUX)

#endif

#if (WINDOWS)
    [LibraryImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
        EntryPoint = "LoggerManager_GetTitle", SetLastError = true)]
    [MethodImpl(MethodImplOptions.Unmanaged)]
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.U1)]
    public static unsafe partial bool GetTitle(ulong id, char* buffer, ulong bufferSize);
#elif (LINUX)

#endif

#if (WINDOWS)
    [LibraryImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
        EntryPoint = "LoggerManager_WriteLine", SetLastError = true)]
    [MethodImpl(MethodImplOptions.Unmanaged)]
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    public static unsafe partial void WriteLine(ulong id, OutputStreamType type, char* str);
#elif (LINUX)

#endif
}