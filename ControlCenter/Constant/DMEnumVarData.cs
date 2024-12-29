using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DMEnumVarData
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string lpszProjectFile;
        public UInt32 lpdmVarKey;
        public UInt32 dwItems;
        public DM_ENUM_VARIABLE_PROC lpfnEnum;
        public IntPtr lpvUser;

    }
}
