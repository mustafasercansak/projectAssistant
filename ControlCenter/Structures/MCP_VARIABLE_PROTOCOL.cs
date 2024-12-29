using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class MCP_VARIABLE_PROTOCOL
    {
        [MarshalAs(UnmanagedType.Bool)]
        public bool bTopLimitErr;
        [MarshalAs(UnmanagedType.Bool)]
        public bool bBottomLimitErr;
        [MarshalAs(UnmanagedType.Bool)]
        public bool bTransformationErr;
        [MarshalAs(UnmanagedType.Bool)]
        public bool bWriteErr;
        [MarshalAs(UnmanagedType.Bool)]
        public bool bWriteErrApplication;
        [MarshalAs(UnmanagedType.Bool)]
        public bool bWriteErrProzess;
    }
}
