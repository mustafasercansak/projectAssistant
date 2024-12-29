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
    internal delegate bool DM_ENUM_VARIABLE_PROC(DM_VARKEY lpdmVarKey,
        [In] DM_VARIABLE_DATA lpdmVarData,
        [In] IntPtr lpvUser);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate bool DM_ENUM_VARIABLE_PROC4(
        [In] DM_VARKEY lpdmVarKey,
        [In] DM_VARIABLE_DATA4/*IntPtr*/ lpdmVarData,
        [In] IntPtr lpvUser);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate bool DM_ENUM_VARIABLE_PROC_EXSTR(
        [In] DM_VARIABLE_DATA_EXSTR lpdmVarData,
        [In] IntPtr lpvUser);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate bool DM_ENUM_VARIABLE_PROC_EXSTR_7(
        [In][MarshalAs(UnmanagedType.FunctionPtr)] DM_VARIABLE_DATA_EXSTR_7 lpdmVarData,
        [In] IntPtr lpvUser);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate bool DM_ENUM_VAR_PROC(
        [In][MarshalAs(UnmanagedType.LPStruct)] DM_VARKEY lpdmVarKey,
        [In] IntPtr lpvUser);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate bool DM_ENUM_VAR_PROC_5(
        [In, Out][MarshalAs(UnmanagedType.Struct)] ref object lpvVariantData,
        [In] IntPtr lpvUser);

    internal class Tags
    {
        [DllImport("dmclient.dll", EntryPoint = "DMEnumVarDataW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMEnumVarData(
            [In] string lpszProjectFile,
            [In] DM_VARKEY[] lpdmVarKey,
            [In] UInt32 dwItems,
            [In][MarshalAs(UnmanagedType.FunctionPtr)] DM_ENUM_VARIABLE_PROC lpfnEnum,
            [In] IntPtr lpvUser,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMEnumVarData4W", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMEnumVarData4(
            [In] string lpszProjectFile,
            [In] DM_VARKEY[] lpdmVarKey,
            [In] UInt32 dwItems,
            [In][MarshalAs(UnmanagedType.FunctionPtr)] DM_ENUM_VARIABLE_PROC4 lpfnEnum,
            [In] IntPtr lpvUser,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMEnumVarDataExStrW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMEnumVarDataExStr(
            [In] string lpszProjectFile,
            [In] UInt32 dwFlags,
            [In][MarshalAs(UnmanagedType.LPStruct)] object lpvdmVarKey,
            [In] DM_ENUM_VARIABLE_PROC_EXSTR lpfnEnum,
            [In] IntPtr lpvUser,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMEnumVarDataExStr7W", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMEnumVarDataExStr7(
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpszProjectFile,
            [In] UInt32 dwFlags,
            [In][MarshalAs(UnmanagedType.IUnknown)] object lpvdmVarKey,
            [In][MarshalAs(UnmanagedType.LPStruct)] DM_VARFILTER lpdmVarFilter,
            [In] DM_ENUM_VARIABLE_PROC_EXSTR_7 lpfnEnum,
            [In] IntPtr lpvUser,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMEnumVariablesW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMEnumVariables(
            [In] string lpszProjectFile,
            [In][MarshalAs(UnmanagedType.LPStruct)] DM_VARFILTER lpdmVarFilter,
            [In][MarshalAs(UnmanagedType.FunctionPtr)] DM_ENUM_VAR_PROC lpfnEnum,
            [In] IntPtr lpvUser,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "DMEnumVariables5W", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool DMEnumVariables5(
            [In] string lpszProjectFile,
            [In][MarshalAs(UnmanagedType.LPStruct)] DM_VARFILTER lpdmVarFilter,
            [In] UInt32 dwEnumBlockCount,
            [In] DM_ENUM_VAR_PROC_5 lpfnEnum,
            [In] IntPtr lpvUser,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "GAPICreateNewVariableW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GAPICreateNewVariable(
            [In][MarshalAs(UnmanagedType.LPStruct)] MCP_NEWVARIABLE_DATA pData,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "GAPICreateNewVariable4W", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GAPICreateNewVariable4(
            [In][MarshalAs(UnmanagedType.LPStruct)] MCP_NEWVARIABLE_DATA_4 pData,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "GAPICreateNewVariableEx4W", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GAPICreateNewVariableEx4(
            [In]UInt32 dwCreatorID,
            [In][MarshalAs(UnmanagedType.LPStruct)] MCP_NEWVARIABLE_DATA_4 pData,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "GAPICreateNewVariable5W", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GAPICreateNewVariable5(
            [In] UInt32 dwCreatorID,
            [In][MarshalAs(UnmanagedType.LPStruct)] MCP_NEWVARIABLE_DATA_5 pData,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "GAPICreateNewVariableExStrW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GAPICreateNewVariableExStr(
            [In] UInt32 dwCreatorID,
            [In][MarshalAs(UnmanagedType.LPStruct)] MCP_CREATENEWVARIABLE_DATA_EXSTR pData,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "GAPICreateNewVariableExStr7W", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GAPICreateNewVariableExStr7(
            [In] UInt32 dwCreatorID,
            [In][MarshalAs(UnmanagedType.LPStruct)] MCP_CREATENEWVARIABLE_DATA_EXSTR pData,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "GAPICreateNewVariableExStr75W", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GAPICreateNewVariableExStr75(
            [In] UInt32 dwCreatorID,
            [In][MarshalAs(UnmanagedType.LPStruct)] MCP_CREATENEWVARIABLE_DATA_EXSTR_75 pData,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "GAPIDeleteVariableW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GAPIDeleteVariable(
            [In][MarshalAs(UnmanagedType.LPStruct)] MCP_DELETEVARIABLE_DATA pData,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        // WinCC V7.4 or higher
        [DllImport("dmclient.dll", EntryPoint = "GAPIDeleteVariableExStrW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GAPIDeleteVariableExStr(
            [In] UInt32 dwFlags,
            [In] string lpszProjectFile,
            [In] string lpszVarName,
            [In] UInt32 dwCreatorID,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);
    }

}
