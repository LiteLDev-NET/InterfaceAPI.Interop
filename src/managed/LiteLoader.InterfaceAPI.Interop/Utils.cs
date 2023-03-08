using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace LiteLoader.InterfaceAPI.Interop
{
    public class Utils
    {
        [DllImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
        CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "Std_ctor_string", SetLastError = true)]
        [SuppressUnmanagedCodeSecurity]
        public static unsafe extern void* Ctor_string([MarshalAs(UnmanagedType.LPWStr)] string str);

        [DllImport("LiteLoader.InterfaceAPI.Interop.Native.dll",
        CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "Std_dtor_string", SetLastError = true)]
        [SuppressUnmanagedCodeSecurity]
        public static unsafe extern void Dtor_string(void** str);
    }
}
