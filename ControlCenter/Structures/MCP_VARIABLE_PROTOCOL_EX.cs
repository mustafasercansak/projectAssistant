﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class MCP_VARIABLE_PROTOCOL_EX
    {
        [MarshalAs(UnmanagedType.U4)]
        public MCP_VARPROT dwProtocolFlags;
    }
}
