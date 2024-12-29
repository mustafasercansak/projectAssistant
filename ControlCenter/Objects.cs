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
    internal delegate bool DM_ENUM_OBJECT_PROC(
        [In] DMObjects dwObjectType,
        [In] IntPtr lpvData,
        [In] IntPtr lpvUser);

    internal class Objects
    {
        [DllImport("dmclient.dll", EntryPoint = "DMCreateObjectW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMCreateObject(
            [In][MarshalAs(UnmanagedType.U4)] DMObjects dwObjectType,
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpszProjectFile,
            [In] IntPtr lpvObjectData,
            [In] UInt32 dwFlags,
            [In] UInt32 dwCreatorID,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMRenameObjectW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMRenameObject(
            [In][MarshalAs(UnmanagedType.U4)] DMObjects dwObjectType,
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpszProjectFile,
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpszOldName,
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpszNewName,
            [In] UInt32 dwFlags,
            [In] UInt32 dwCreatorID,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMDeleteAllObjectsW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMDeleteAllObjects(
            [In][MarshalAs(UnmanagedType.U4)] DMObjects dwObjectType,
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpszProjectFile,
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpszName,
            [In] UInt32 dwFlags,
            [In] UInt32 dwCreatorID,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMDeleteObjectW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMDeleteObject(
            [In][MarshalAs(UnmanagedType.U4)] DMObjects dwObjectType,
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpszProjectFile,
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpszName,
            [In] UInt32 dwFlags,
            [In] UInt32 dwCreatorID,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMDeleteObjectsForConnection", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMDeleteObjectsForConnection(
            [In][MarshalAs(UnmanagedType.U4)] DMObjects dwObjectType,
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpszProjectFile,
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpszName,
            [In] UInt32 dwFlags,
            [In] UInt32 dwCreatorID,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", CharSet = CharSet.Unicode, EntryPoint = "DMEnumObjectW", ExactSpelling = false)]
        public static extern bool DMEnumObject(
            [In][MarshalAs(UnmanagedType.U4)] DMObjects dwObjectType,
            [In] string lpszProjectFile,
            [In] IntPtr lpvFilter,
            [In][MarshalAs(UnmanagedType.FunctionPtr)] DM_ENUM_OBJECT_PROC lpfnEnum,
            [In] IntPtr lpvUser,
            [In] uint dwCreatorID,
            [In][Out] CMN_ERROR lpdmError);
    }
}
