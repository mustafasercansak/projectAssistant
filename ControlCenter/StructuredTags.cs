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
    internal delegate bool DM_ENUM_TYPES_PROC(
        [In][MarshalAs(UnmanagedType.LPWStr)] string lpszTypeName,
        [In] UInt32 dwTypeID,
        [In] UInt32 dwCreatorID,
        [In] IntPtr lpvUser);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate bool DM_ENUM_TYPEMEMBERS_PROC(
        [In][MarshalAs(UnmanagedType.LPWStr)] string lpszMemberName,
        [In] IntPtr lpvUser);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate bool DM_ENUM_TYPEMEMBERS_PROC_EX(
        [In][MarshalAs(UnmanagedType.LPStruct)] DM_VARKEY lpdmVarKey,
        [In][MarshalAs(UnmanagedType.LPStruct)] MCP_NEWVARIABLE_DATA_EX lpdmVarDataEx,
        [In] IntPtr lpvUser);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate bool DM_ENUM_TYPEMEMBERS_PROC_EX4(
        [In][MarshalAs(UnmanagedType.LPStruct)] DM_VARKEY lpdmVarKey,
        [In][MarshalAs(UnmanagedType.LPStruct)] MCP_NEWVARIABLE_DATA_EX4 lpdmVarDataEx,
        [In] IntPtr lpvUser);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate bool DM_ENUM_TYPEMEMBERS_PROC_EXSTR(
        [In][MarshalAs(UnmanagedType.LPWStr)] string lpszMemberName,
        [In] UInt32 dwStructMemberUserTypeID,
        [In][MarshalAs(UnmanagedType.LPStruct)] MCP_NEWVARIABLE_DATA_EXSTR lpdmVarDataEx,
        [In] IntPtr lpvUser);

    internal class StructuredTags
    {
        [DllImport("dmclient.dll", EntryPoint = "GAPICreateTypeW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GAPICreateType(
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpszProjectFile,
            [In][MarshalAs(UnmanagedType.LPStruct)] DM_TYPE_DESCRIPTOR lpdmType,
            [In] UInt32 dwFlags,
            [In] UInt32 dwCreatorID,
            [In]IntPtr lpMemberdata,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "GAPICreateType4W", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GAPICreateType4(
            [In] string lpszProjectFile,
            [In] ref DM_TYPE_DESCRIPTOR lpdmType,
            [In] UInt32 dwFlags,
            [In] UInt32 dwCreatorID,
            [In] ref MCP_NEWVARIABLE_DATA_EX4[] lpMemberdata,
            [In] ref MCP_CHNCONVERSION[] lpChnConversion,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "GAPICreateTypeExStrW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GAPICreateTypeExStr(
            [In] string lpszProjectFile,
            [In][MarshalAs(UnmanagedType.LPStruct)] DM_TYPE_DESCRIPTOR_EXSTR lpdmType,
            [In] UInt32 dwFlags,
            [In] UInt32 dwCreatorID,
            [In] IntPtr lpMemberdata,
            [In][MarshalAs(UnmanagedType.LPStruct)] MCP_CHNCONVERSION_EXSTR lpChnConversion,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "GAPIEnumTypesW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GAPIEnumTypes(
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpszProjectFile,
            [In] DM_ENUM_TYPES_PROC lpdmType,
            [In] IntPtr lpvUser,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "GAPIEnumTypeMembersW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GAPIEnumTypeMembers(
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpszProjectFile,
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpszTypeName,
            [In] DM_ENUM_TYPEMEMBERS_PROC lpfnCallback,
            [In] IntPtr lpvUser,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "GAPIEnumTypeMembersExW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GAPIEnumTypeMembersEx(
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpszProjectFile,
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpszTypeName,
            [In] DM_ENUM_TYPEMEMBERS_PROC_EX lpfnCallback,
            [In] IntPtr lpvUser,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "GAPIEnumTypeMembersEx4W", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GAPIEnumTypeMembersEx4(
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpszProjectFile,
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpszTypeName,
            [In] DM_ENUM_TYPEMEMBERS_PROC_EX4 lpfnCallback,
            [In] IntPtr lpvUser,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "GAPIEnumTypeMembersExStrW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GAPIEnumTypeMembersExStr(
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpszProjectFile,
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpszTypeName,
            [In] DM_ENUM_TYPEMEMBERS_PROC_EXSTR lpfnCallback,
            [In] IntPtr lpvUser,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "GAPIDeleteTypeW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GAPIDeleteType(
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpszProjectFile,
            [In] UInt32 dwFlags,
            [In] UInt32 dwCreatorID,
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpszTypeName,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "GAPICreateTypInstanceW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GAPICreateTypInstance(
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpszProjectFile,
            [In][MarshalAs(UnmanagedType.LPStruct)] MCP_NEWVARIABLE_DATA_EX lpdmTypeInstance,
            [In] UInt32 dwNumMembers,
            [In] UInt32 dwFlags,
            [In][MarshalAs(UnmanagedType.LPStruct)] MCP_NEWVARIABLE_DATA_EX lpMemberData,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "GAPICreateTypInstance4W", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GAPICreateTypInstance4(
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpszProjectFile,
            [In][MarshalAs(UnmanagedType.LPStruct)] MCP_NEWVARIABLE_DATA_EX4 lpdmTypeInstance,
            [In] UInt32 dwNumMembers,
            [In] UInt32 dwFlags,
            [In][MarshalAs(UnmanagedType.LPStruct)] MCP_NEWVARIABLE_DATA_EX4 lpMemberData,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);

        [DllImport("dmclient.dll", EntryPoint = "GAPICreateTypInstanceExStrW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GAPICreateTypInstanceExStr(
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpszProjectFile,
            [In][MarshalAs(UnmanagedType.LPStruct)] MCP_NEWVARIABLE_DATA_EXSTR lpdmTypeInstance,
            [In] UInt32 dwNumMembers,
            [In] UInt32 dwFlags,
            [In][MarshalAs(UnmanagedType.LPStruct)] MCP_NEWVARIABLE_DATA_EXSTR lpMemberData,
            [In] UInt32 dwCreatorID,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError);
    }
}
