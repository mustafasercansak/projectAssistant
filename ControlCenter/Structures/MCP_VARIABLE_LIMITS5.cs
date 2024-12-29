using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class MCP_VARIABLE_LIMITS5
    {
        [MarshalAs(UnmanagedType.Struct)]
        public object varTopLimit;
        [MarshalAs(UnmanagedType.Struct)]
        public object varBottomLimit;
        [MarshalAs(UnmanagedType.Struct)]
        public object varStartValue;
        [MarshalAs(UnmanagedType.Struct)]
        public object varSubstituteValue;
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
