using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class GENERATE_FUNCTION
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszProjectName;

        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszGlobalLibDir;

        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszProjectLibDir;

        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszPathName;

        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszFileName;

        [MarshalAs(UnmanagedType.LPWStr)]        
        public string pszSourceCode;

        public IntPtr pAction;

        public UInt32 dwType;

    }
}
