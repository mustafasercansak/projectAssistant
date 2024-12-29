using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace General
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    public class DM_VARKEY
    {
        public UInt32 dwKeyType;
        public UInt32 dwID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128 + 1)]
        public string szName;
        public IntPtr lpvUserData;
        public DM_VARKEY()
        {

        }
        public DM_VARKEY(string name)
        {
            szName = name;
            dwKeyType = 0x2;
            dwID = 0;
            lpvUserData = IntPtr.Zero;
        }
    }
}
