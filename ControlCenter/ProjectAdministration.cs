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
    internal delegate bool DM_ENUM_OPENED_PROJECTS_PROC(DM_PROJECT_INFO lpInfo,
                      IntPtr lpvUser);

    internal class ProjectAdministration
    {
        [DllImport("dmclient.dll", EntryPoint = "DMCreateNewProjectW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        internal static extern bool DMCreateNewProject(
            [In] IntPtr hWnd,
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpszProjectFile,
            [In] UInt32 dwBufSize,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError
            );

        [DllImport("dmclient.dll", EntryPoint = "DMEnumOpenedProjectsW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        internal static extern bool DMEnumOpenedProjects(
            [In, Out][MarshalAs(UnmanagedType.U4)] UInt32 lpdwItems,
            [In] DM_ENUM_OPENED_PROJECTS_PROC lpfnEnum,
            [In] IntPtr lpvUser,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError
            );

        [DllImport("dmclient.dll", EntryPoint = "DMGetProjectDirectoryW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        internal static extern bool DMGetProjectDirectory(
            [In] string lpszAppName,
            [In] string lpszProjectFile,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] DM_DIRECTORY_INFO lpdmDirInfo,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError
            );

        [DllImport("dmclient.dll", EntryPoint = "DMOpenProjectDocW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        internal static extern bool DMOpenProjectDoc(
            [In] string lpszProjectFile,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError
            );

        [DllImport("dmclient.dll", EntryPoint = "GAPICreateNewProjectW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        internal static extern bool GAPICreateNewProject(
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] MCP_NEWPROJECT_DATA lpszProjectFile,
            [In, Out][MarshalAs(UnmanagedType.LPStruct)] CMN_ERROR lpdmError
            );
    }
}
