using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class MCP_VARIABLE_SCALES
    {
        [MarshalAs(UnmanagedType.U4)]
        public DM_VARSCALE dwVarScaleFlags;
        [MarshalAs(UnmanagedType.R8)]
        public double doMinProc;
        [MarshalAs(UnmanagedType.R8)]
        public double doMaxProc;
        [MarshalAs(UnmanagedType.R8)]
        public double doMinVar;
        [MarshalAs(UnmanagedType.R8)]
        public double doMaxVar;
    }
}
