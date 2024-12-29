using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class GET_ACTION_STREAM
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszPathName;
        [MarshalAs(UnmanagedType.U4)]
        public GSC_AP dwType;
    }
}
