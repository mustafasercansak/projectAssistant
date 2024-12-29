using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class CREATE_USER_HEADER_FILE
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszStartDir;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszHeaderFileName;
        [MarshalAs(UnmanagedType.Bool)]
        public bool bShowDlg;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszWindowText;
    }
}
