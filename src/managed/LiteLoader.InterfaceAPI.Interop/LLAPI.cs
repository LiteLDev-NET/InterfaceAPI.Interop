using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CS8500
namespace LiteLoader.InterfaceAPI.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct RegisterPluginArgs
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Pair
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string key;

            [MarshalAs(UnmanagedType.LPWStr)]
            public string value;
        };
        public Pair* array;
        public ulong length;
    };

    public unsafe static class LLAPI
    {
        [DllImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
        CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "LLAPI_registerPlugin", SetLastError = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern bool RegisterPlugin(
            nint handle,
            [MarshalAs(UnmanagedType.LPWStr)] string name,
            [MarshalAs(UnmanagedType.LPWStr)] string desc,
            void* pVersion,
            ref RegisterPluginArgs args);
    }
}
#pragma warning restore CS8500
