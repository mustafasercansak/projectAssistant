using General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate bool DM_NOTIFY_VARIABLE_PROC(
        [In] UInt32 dwTAID,
        [In] IntPtr lpdmvus,
        [In] UInt32 dwItems,
        [In] IntPtr lpvUser);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate bool DM_NOTIFY_VARIABLEEX_PROC(
        [In] UInt32 dwTAID,
        [In] IntPtr lpdmvus,
        [In] UInt32 dwItems,
        [In] IntPtr lpvUser);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate bool DM_NOTIFY_VARIABLE_PROC_EXSTR(
        [In] UInt32 dwTAID,
        [In] IntPtr lpdmvus,
        [In] UInt32 dwItems,
        [In] IntPtr lpvUser);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate bool DM_COMPLETITION_PROC(
        [In] UInt32 dwTAID,
        [In] IntPtr lpdmVarState,
        [In] UInt32 dwItems,
        [In] IntPtr lpvUser);

    internal static class Runtime
    {
        [DllImport("dmclient.dll", EntryPoint = "DMGetValueW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMGetValue(
            [In] DM_VARKEY lpdmVarKey,
            [In] UInt32 dwItems,
            [In, Out] DM_VAR_UPDATE_STRUCT lpdmvus,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMGetValueW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMGetValue(
            [In] IntPtr lpdmVarKey,
            [In] UInt32 dwItems,
            [In, Out] IntPtr lpdmvus,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMGetValueExW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMGetValueEx(
            [In] IntPtr lpdmVarKey,
            [In] UInt32 dwItems,
            [In, Out] IntPtr lpdmvus,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMGetValueExStrW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMGetValueExStr(
            [In] UInt32 dwFlags,
            [In][MarshalAs(UnmanagedType.LPStruct)] VariantArray lpdmVarKey,
            [In] IntPtr lpdmvus,
            [In] UInt32 dwdmvusCount,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMGetValueWaitW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMGetValueWait(
            [In, Out] ref UInt32 pdwTAID,
            [In] IntPtr lpdmVarKey,
            [In] UInt32 dwItems,
            [In] bool fWaitForCompletition,
            [In] UInt32 dwTimeOut,
            [In] DM_NOTIFY_VARIABLE_PROC lpfnVariable,
            [In] IntPtr lpvUser,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMGetValueWaitExW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMGetValueWaitEx(
            [In, Out] ref UInt32 pdwTAID,
            [In] IntPtr lpdmVarKey,
            [In] UInt32 dwItems,
            [In] bool fWaitForCompletition,
            [In] UInt32 dwTimeOut,
            [In] DM_NOTIFY_VARIABLEEX_PROC lpfnVariable,
            [In] IntPtr lpvUser,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMGetValueWaitExStrW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMGetValueWaitExStr(
            [In, Out] ref UInt32 pdwTAID,
            [In] UInt32 dwFlags,
            [In][MarshalAs(UnmanagedType.LPStruct)] VariantArray lpdmVarKey,
            [In][MarshalAs(UnmanagedType.LPStruct)] VariantArray lpvCookie,
            [In] bool fWaitForCompletition,
            [In] UInt32 dwTimeOut,
            [In] DM_NOTIFY_VARIABLE_PROC_EXSTR lpfnVariable,
            [In] IntPtr lpvUser,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMGetVarLimitsW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMGetVarLimits(
            [In] string lpszProjectFile,
            IntPtr lpdmVarKey,
            [In] UInt32 dwItems,
            IntPtr lpdmVarLimit,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMGetVarLimitsExStrW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMGetVarLimitsExStr(
            [In] string lpszProjectFile,
            [In][MarshalAs(UnmanagedType.LPStruct)] VariantArray lpdmVarKey,
            IntPtr lpdmVarLimit,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMGetVarTypeW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMGetVarType(
            [In] string lpszProjectFile,
            IntPtr lpdmVarKey,
            [In] UInt32 dwItems,
            IntPtr lpdmTypeRef,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMGetVarTypeExStrW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMGetVarTypeExStr(
            [In] string lpszProjectFile,
            [In][MarshalAs(UnmanagedType.LPStruct)] VariantArray lpdmVarKey,
            IntPtr lpdmTypeRef,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMSetValueW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMSetValue(
            [In] IntPtr lpdmVarKey,
            [In] UInt32 dwItems,
            [In] IntPtr lpdmValue,
            [In] IntPtr lpdmVarState,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMSetValueExStrW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMSetValueExStr(
            [In] IntPtr lpdmVarKey,
            [In] IntPtr lpdmValue,
            [In] IntPtr lpdmVarState,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMSetValueMessageW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMSetValueMessage(
            [In] DM_VARKEY lpdmVarKey,
            [In] Variant lpdmValue,
            [In] DMSVM_OPERATION fFlags,
            [In] string lpszMessage,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMSetValueWaitW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMSetValueWait(
            [In, Out] ref UInt32 pdwTAID,
            [In] IntPtr lpdmVarKey,
            [In] UInt32 dwItems,
            [In] IntPtr lpdmValue,
            [In] UInt32 dwTimeOut,
            [In] DM_COMPLETITION_PROC lpfnVariable,
            [In] IntPtr lpvUser,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMSetValueWaitExStrW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMSetValueWaitExStr(
            [In, Out] ref UInt32 pdwTAID,
            [In][MarshalAs(UnmanagedType.LPStruct)] VariantArray lpdmVarKey,
            [In] UInt32 dwItems,
            [In][MarshalAs(UnmanagedType.LPStruct)] VariantArray lpdmValue,
            [In, Out] ref UInt32[] lpdwState,
            [In] UInt32 dwTimeOut,
            [In] DM_COMPLETITION_PROC lpfnVariable,
            [In] IntPtr lpvUser,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMBeginStartVarUpdateW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMBeginStartVarUpdate(
            [In, Out] ref UInt32 pdwTAID,
            [In, Out] [MarshalAs(UnmanagedType.LPStruct)]CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMEndStartVarUpdateW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMEndStartVarUpdate(
            [In] UInt32 dwTAID,
            [In, Out] [MarshalAs(UnmanagedType.LPStruct)]CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMResumeVarUpdateW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMResumeVarUpdate([In] UInt32 dwTAID,
                                              [In, Out] [MarshalAs(UnmanagedType.LPStruct)]
                                                                CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMStopVarUpdateW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMStopVarUpdate(
            [In, MarshalAs(UnmanagedType.U4)] UInt32 dwTAID,
            [In, Out] [MarshalAs(UnmanagedType.LPStruct)]CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMStopAllUpdatesW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMStopAllUpdates([In, Out] [MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMSuspendVarUpdateW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMSuspendVarUpdate([In] UInt32 dwTAID,
                                              [In, Out] [MarshalAs(UnmanagedType.LPStruct)]
                                                                CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMStartVarUpdateW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMStartVarUpdate(
            [In] UInt32 dwTAID,
            [In] IntPtr lpdmVarKey,
            [In] UInt32 dwItems,
            [In] UInt32 dwCycle,
            [In] DM_NOTIFY_VARIABLE_PROC lpfnVariable,
            [In] IntPtr lpvUser,
            [In, Out] [MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMStartVarUpdateExW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMStartVarUpdateEx(
            [In] UInt32 dwTAID,
            [In, Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] DM_VARKEY[] lpdmVarKey,
            [In] UInt32 dwItems,
            [In] UInt32 dwCycle,
            [In] DM_NOTIFY_VARIABLEEX_PROC lpfnVariable,
            [In] IntPtr lpvUser,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMStartVarUpdateExW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMStartVarUpdateExStr(
            [In] UInt32 dwTAID,
            [In] UInt32 dwFlags,
            [In, Out, MarshalAs(UnmanagedType.LPStruct)] VariantArray lpdmVarKey,
            [In, Out, MarshalAs(UnmanagedType.LPStruct)] VariantArray lpvCookie,
            [In] UInt32 dwCycle,
            [In] DM_NOTIFY_VARIABLE_PROC_EXSTR lpfnVariable,
            [In] IntPtr lpvUser,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMGetRuntimeProjectW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMGetRuntimeProject(
            [In, Out][MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpszProjectFile,
            [In] UInt32 dwBufSize,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);
    }
}
