using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class GENERATE_HEADER_FILES
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszProjectName;

        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszGlobalLibDir;

        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszProjectLibDir;

        public UInt32 dwType;

        [MarshalAs(UnmanagedType.Bool)]
        public bool bShowDlg;

        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszWindowText;
    }
}
