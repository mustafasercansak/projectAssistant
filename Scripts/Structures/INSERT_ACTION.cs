using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class INSERT_ACTION
    {
        public IntPtr pAction;

        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszProjectDir;

        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszFileName;

        public UInt32 dwUserLevel;

        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszUserLevel;

    }
}
