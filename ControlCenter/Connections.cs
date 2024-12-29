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
    internal delegate bool DM_ENUM_CONNECTION_PROC(
        [In, Out][MarshalAs(UnmanagedType.LPStruct)] DM_CONNECTION_DATA lpvVariantData,
        [In] IntPtr lpvUser);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate bool DM_ENUM_CONNECTION_PROC_EXSTR(
        [In, Out][MarshalAs(UnmanagedType.LPStruct)] DM_CONNECTION_DATA_EXSTR lpvVariantData,
        [In] IntPtr lpvUser);

    internal class Connections
    {
        [DllImport("dmclient.dll", EntryPoint = "DMEnumConnectionDataW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMEnumConnectionData(
            [In] string lpszProjectFile,
            [In] DM_CONNKEY lpdmConnKey,
            [In] UInt32 dwItems,
            [In][MarshalAs(UnmanagedType.FunctionPtr)] DM_ENUM_CONNECTION_PROC lpfnEnum,
            [In] IntPtr lpvUser,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMEnumConnectionDataExStrW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMEnumConnectionDataExStr(
            [In] string lpszProjectFile,
            [In][MarshalAs(UnmanagedType.FunctionPtr)] DM_ENUM_CONNECTION_PROC_EXSTR lpfnEnum,
            [In] IntPtr lpvUser,
            [In, Out] UInt32 lpdwConnectionCount,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "GAPIDeleteConnectionW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GAPIDeleteConnection(
            [In, Out] [MarshalAs(UnmanagedType.LPStruct)] MCP_DELETECONNECTION_DATA pData,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "GAPICreateNewConnectionW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GAPICreateNewConnection(
             [In, Out][MarshalAs(UnmanagedType.LPStruct)] MCP_NEWCONNECTION_DATA pData,
             [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "GAPICreateNewConnectionExStrW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GAPICreateNewConnectionExStr(
             [In, Out][MarshalAs(UnmanagedType.LPStruct)] MCP_NEWCONNECTION_DATA_EXSTR pData,
             [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);
    }
}
