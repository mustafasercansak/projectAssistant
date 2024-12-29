using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_VARGRPKEY_EXSTR
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszVarGrpName;
        public UInt32 dwVarGrpNameCharCount;
        public UInt32 dwVarGrpID;
        public IntPtr lpvUserData;
    }
}
