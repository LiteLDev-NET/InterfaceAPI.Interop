using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace LiteLoader.InterfaceAPI.Interop
{
    public static class RemoteCall
    {
#if (WINDOWS)
        [DllImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
            CallingConvention = CallingConvention.Cdecl,
            EntryPoint = "RemoteCall_hasFunc", SetLastError = true)]
        [MethodImpl(MethodImplOptions.Unmanaged)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.U1)]
        public static unsafe extern bool HasFunc(char* nameSpace, char* funcName);
#elif (LINUX)

#endif

#if (WINDOWS)
        [DllImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
            CallingConvention = CallingConvention.Cdecl,
            EntryPoint = "RemoteCall_removeFunc", SetLastError = true)]
        [MethodImpl(MethodImplOptions.Unmanaged)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.U1)]
        public static unsafe extern bool RemoveFunc(char* nameSpace, char* funcName);
#elif (LINUX)

#endif

#if (WINDOWS)
        [DllImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
            CallingConvention = CallingConvention.Cdecl,
            EntryPoint = "RemoteCall_removeNameSpace", SetLastError = true)]
        [MethodImpl(MethodImplOptions.Unmanaged)]
        [SuppressUnmanagedCodeSecurity]
        public static unsafe extern int RemoveNameSpace(char* nameSpace);
#elif (LINUX)

#endif

#if (WINDOWS)
        [DllImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
            CallingConvention = CallingConvention.Cdecl,
            EntryPoint = "RemoteCall_removeFuncs", SetLastError = true)]
        [MethodImpl(MethodImplOptions.Unmanaged)]
        [SuppressUnmanagedCodeSecurity]
        public static unsafe extern int RemoveFuncs(void* vector);
#elif (LINUX)

#endif

#if (WINDOWS)
        [DllImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
            CallingConvention = CallingConvention.Cdecl,
            EntryPoint = "RemoteCall_exportFunc", SetLastError = true)]
        [MethodImpl(MethodImplOptions.Unmanaged)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.U1)]
        public static unsafe extern bool ExportFunc(char* nameSpace, char* fullName, void* callback, nint handle);
#elif (LINUX)

#endif

#if (WINDOWS)
        [DllImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
            CallingConvention = CallingConvention.Cdecl,
            EntryPoint = "RemoteCall_importFunc", SetLastError = true)]
        [MethodImpl(MethodImplOptions.Unmanaged)]
        [SuppressUnmanagedCodeSecurity]
        public static unsafe extern void* ImportFunc(char* nameSpace, char* fullName);
#elif (LINUX)

#endif
    }
}
