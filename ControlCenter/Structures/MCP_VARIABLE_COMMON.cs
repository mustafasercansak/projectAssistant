using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class MCP_VARIABLE_COMMON
    {
        [MarshalAs(UnmanagedType.U4)]
        public DM_VARTYPES dwVarType;
        public UInt32 dwVarLength;
        [MarshalAs(UnmanagedType.U4)]
        public DM_VAR_PROPERTY dwVarProperty;
        public UInt32 dwFormat;
    }
}
