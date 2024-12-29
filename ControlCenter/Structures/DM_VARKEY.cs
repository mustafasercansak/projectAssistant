using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_VARKEY
    {
        public UInt32 dwKeyType;
        public UInt32 dwID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.VAR_NAME + 1)]
        public string szName;
        public IntPtr lpvUserData;
    }
}
