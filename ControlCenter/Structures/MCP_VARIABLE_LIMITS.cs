using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class MCP_VARIABLE_LIMITS
    {
        [MarshalAs(UnmanagedType.R8)]
        public double dTopLimit;
        [MarshalAs(UnmanagedType.R8)]
        public double dBottomLimit;
        [MarshalAs(UnmanagedType.R8)]
        public double dStartValue;
        [MarshalAs(UnmanagedType.R8)]
        public double dSubstituteValue;
        [MarshalAs(UnmanagedType.Bool)]
        public bool bTopLimit;
        [MarshalAs(UnmanagedType.Bool)]
        public bool bBottomLimit;
        [MarshalAs(UnmanagedType.Bool)]
        public bool bStartValue;
        [MarshalAs(UnmanagedType.Bool)]
        public bool bConnectionErr;
        [MarshalAs(UnmanagedType.Bool)]
        public bool bTopLimitValid;
        [MarshalAs(UnmanagedType.Bool)]
        public bool bBottomLimitValid;
        [MarshalAs(UnmanagedType.Bool)]
        public bool bStartValueValid;
        [MarshalAs(UnmanagedType.Bool)]
        public bool bSubstValueValid;
    }
}
