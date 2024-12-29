using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class AP_SERVER_CONTEXT
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszServerPrefix;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszTagPrefix;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszWindowName;
    }
}
