using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class MCP_VARIABLE_COMMON_EX
    {
        [MarshalAs(UnmanagedType.U4)]
        public DM_VARTYPES dwVarType;
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dwCreatorID;
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dwVarLength;
        [MarshalAs(UnmanagedType.U4)]
        public DM_VAR_PROPERTY dwVarProperty;
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dwFormat;
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dwOSOffset;
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dwASOffset;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.VAR_NAME + 1)]
        public string szStructTypeName;
    }
}
