﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class MCP_VARIABLE_LIMITS_EXSTR
    {
        [MarshalAs(UnmanagedType.R8)]
        public double dTopLimit;
        [MarshalAs(UnmanagedType.R8)]
        public double dBottomLimit;
        [MarshalAs(UnmanagedType.R8)]
        public double dStartValue;
        [MarshalAs(UnmanagedType.R8)]
        public double dSubstituteValue;
        [MarshalAs(UnmanagedType.U4)]
        public MCPVarLim dwLimitFlags;
        public UInt32 dwTextBibStartText;//The parameter is only relevant for text tags. If you want to use a start-up value contained in the text library, the ID of that text should be entered here.
        [MarshalAs(UnmanagedType.LPWStr)]
        public string szTextStartText;
        public UInt32 dwStartTextCharCount;
        public string dwTextBibSubstitude;//The parameter is only relevant for text tags. Enter the text to be used as substitute value in szTextSubstitude.
        [MarshalAs(UnmanagedType.LPWStr)]
        public string szTextSubstitude;
        public UInt32 dwSubstitudeTextCharCount;
    }
}
