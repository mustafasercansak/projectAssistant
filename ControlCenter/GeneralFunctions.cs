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
    internal delegate bool DM_NOTIFY_PROC(UInt32 dwNotifyClass,
              UInt32 dwNotifyCode,
              IntPtr lpbyData,
              UInt32 dwItems,
              IntPtr lpvUser);

    internal class GeneralFunctions
    {
        [DllImport("dmclient.dll", EntryPoint = "DMConnectW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMConnect([In] String lpszAppName,
                         [In] DM_NOTIFY_PROC lpfnNotify,
                         [In] IntPtr lpvUser,
                         [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);


        [DllImport("dmclient.dll", CharSet = CharSet.Unicode, EntryPoint = "DMCreateObjectW", ExactSpelling = false)]
        public static extern bool DMCreateObject([In] uint dwObjectType, [In] string lpszProjectFile, [In] IntPtr lpvObjectData, [In] uint dwFlags, [In] uint dwCreatorID, [In][Out] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMDisConnectW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMDisConnect([In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMGetConnectionStateW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMGetConnectionState([In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMExitWinCCExW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMExitWinCCEx(UInt32 dwMode);

        [DllImport("dmclient.dll", EntryPoint = "DMActivateRTProjectW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMActivateRTProject([In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMDeactivateRTProjectExW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMDeactivateRTProjectEx([In][MarshalAs(UnmanagedType.U4)] DMDeactivate dwOptions, [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "GAPIModifyStartListEntryW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GAPIModifyStartListEntry(
            [In] string lpszProjectFile,
            [In] string lpszMachine,
            [In] uint cEntries,
            [In, Out] GAPI_MODIFY_STARTLIST_ENTRY pEntries,
            [In, Out] CMN_ERROR lpdmError);
    }
}
