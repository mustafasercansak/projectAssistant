using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class MCP_CREATENEWVARIABLE_DATA_EXSTR_7
    {
        [MarshalAs(UnmanagedType.U4)]
        public MCP_NVAR_FLAG dwFlags;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszProjectFile;
        public UInt32 dwProjectFileCharCount;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszConnection;
        public UInt32 dwConnectionCharCount;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszVarName;
        public UInt32 dwVarNameCharCount;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszGroupName;
        public UInt32 dwGroupNameCharCount;
        public MCP_VARIABLE_COMMON Common;
        public MCP_VARIABLE_PROTOCOL Protocol;
        public MCP_VARIABLE_LIMITS5 Limits;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszSpecific;
        public UInt32 dwSpecificCharCount;
        public MCP_VARIABLE_SCALES Scaling;
        public UInt32 dwVarWeighting;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszPLCVariableName;
        public UInt32 dwPLCVariableNameCharCount;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszPLCBlockName;
        public UInt32 dwPLCBlockNameCharCount;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszComment;
        public UInt32 dwCommentCharCount;
    }
}
