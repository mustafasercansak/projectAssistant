using General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate bool AP_RT_PROC(
        [In] UInt32 dwAP_Notify,
        [In] UInt32 dwAP_NotifyCode,
        [In] UInt32 dwError,
        [In] IntPtr lpbyData,
        [In] UInt32 dwItems,
        [In] UInt32 dwOrderId,
        [In] IntPtr lpvUser);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr AllocAppMem(int nSize);

    internal class GlobalScirpts
    {
        [DllImport("apclient.dll", EntryPoint = "APConnectW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool APConnect(
            [In] String lpszAppName,
            [In] AP_RT_PROC fpAppBack,
            [In] ref UInt32 pdwOrderId,
            [In] IntPtr lpvUser,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("apclient.dll", EntryPoint = "APDisconnectW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool APDisconnect(
            [In] AP_RT_PROC fpAppBack,
            [In] ref UInt32 pdwOrderId,
            [In] IntPtr lpvUser,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("gscgen.dll", EntryPoint = "GSCGenGetActionStreamW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr GSCGenGetActionStream(
            [In, Out, MarshalAs(UnmanagedType.LPStruct)] GET_ACTION_STREAM pGenGAS,
            [In, Out] AllocAppMem lpfnAllocAppMem,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("gscgen.dll", EntryPoint = "GSCGenGetSourceCodeW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.LPWStr)]
        public static extern string GSCGenGetSourceCode(
            [In] IntPtr pActionStream,
            [In] AllocAppMem lpfnAllocAppMem,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("gscgen.dll", EntryPoint = "GSCGenInsertSourceCodeW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr GSCGenInsertSourceCode(
            [In, Out, MarshalAs(UnmanagedType.LPStruct)] INSERT_SOURCE_CODE pGenISS,
            [In, Out] AllocAppMem lpfnAllocAppMem,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("gscgen.dll", EntryPoint = "GSCGenCreateActionW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GSCGenCreateAction(
            [In, MarshalAs(UnmanagedType.LPStruct)] INSERT_ACTION pGenCNF,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("gscgen.dll", EntryPoint = "GSCGenCompileW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr GSCGenCompile(
            [In, MarshalAs(UnmanagedType.LPStruct)] GENERATE_COMPILE lpGenCompile,
            IntPtr hWndParent,
            ref uint plErrors,
            ref uint plWarnings,
            AllocAppMem lpfnAllocAppMem,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("gscgen.dll", EntryPoint = "GSCGenAddTriggerW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr GSCGenAddTrigger(
            [In, Out, MarshalAs(UnmanagedType.LPStruct)] GSC_TRIGGER pGenGT,
            [In, Out] AllocAppMem lpfnAllocAppMem,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("ap_gen.dll", EntryPoint = "AP_GEN_GetAllocTriggerW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool AP_GEN_GetAllocTrigger(
            [In] IntPtr stream,
            [In] UInt32 TriggerItem,
            [In] ref UInt32 readTrigger,
            [In] ref IntPtr pTrigger,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("ap_gen.dll", EntryPoint = "AP_GEN_FreeTriggerW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool AP_GEN_FreeTrigger(
            [In] UInt32 TriggerItem,
            [In] ref IntPtr pTrigger,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("ap_gen.dll", EntryPoint = "AP_GEN_AddTriggerW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool AP_GEN_AddTrigger(
            [In] IntPtr oldstream,
            [In] ref IntPtr newstream,
            [In] ref UInt32 newstreamsize,
            [In] UInt32 TriggerItem,
            [In] IntPtr pTrigger,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("apclient.dll", EntryPoint = "APFreePCodeW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool APFreePCode(IntPtr lpvPcode);


        [DllImport("ap_gen.dll", EntryPoint = "APCompileLngExW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool APCompileLngEx(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szProjectName,
            [In] ref UInt32 pdwOrderId,
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpvScodeProlog,
            [In] ref UInt32 dwScodePrologSize,
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpvScodeEpilog,
            [In] UInt32 TriggerItem,
            [In] IntPtr pTrigger,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);
    }
}
