using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_VARKEY_EXSTR
    {
        public UInt32 dwKeyType;
        public UInt32 dwID;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string szName;
        public UInt32 dwNameCharCount;
        public IntPtr lpvUserData;
    }
}
