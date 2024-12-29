using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class MCP_NEWVARIABLE_DATA_EX
    {
        [MarshalAs(UnmanagedType.U4)]
        public MCP_NVAR_FLAG dwFlags;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STDLIB._MAX_PATH+1)]
        public string szProjectFile;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.CONNECTION_NAME + 3)]
        public string szConnection;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.VAR_NAME + 1)]
        public string szVarName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.GROUP_NAME + 1)]
        public string szGroupName;
        [MarshalAs(UnmanagedType.Struct)]
        public MCP_VARIABLE_COMMON_EX Common;
        [MarshalAs(UnmanagedType.Struct)]
        public MCP_VARIABLE_PROTOCOL_EX Protocol;
        [MarshalAs(UnmanagedType.Struct)]
        public MCP_VARIABLE_LIMITS_EX Limits;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.VAR_SPECIFIC + 1)]
        public string szSpecific;
    }
}
