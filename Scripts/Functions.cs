using General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    internal class Functions
    {
        [DllImport("apclient.dll", EntryPoint = "GSCGenCompileW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern string GSCGenCompile(
            [In, MarshalAs(UnmanagedType.LPStruct)] GENERATE_COMPILE lpGenCompile,
            [In] IntPtr pActionStream,
            [In] IntPtr lpfnAllocAppMem,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("apclient.dll", EntryPoint = "GSCGenCreateActionW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GSCGenCreateAction(
            [In, MarshalAs(UnmanagedType.LPStruct)] INSERT_ACTION pGenCNF,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("apclient.dll", EntryPoint = "GSCGenCreateNewFunctionW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GSCGenCreateNewFunction(
            [In, MarshalAs(UnmanagedType.LPStruct)] GENERATE_FUNCTION pGenCNF,
            [In] IntPtr hWndParent,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);


    }
}
