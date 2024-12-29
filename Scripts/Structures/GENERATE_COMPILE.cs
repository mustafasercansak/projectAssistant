using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class GENERATE_COMPILE
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszProjectName;
        public IntPtr pAction;
    }
}
