using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    [CompilerGenerated]
    internal class DM_VARIABLE_DATA4
    {
        public DM_TYPEREF dmTypeRef;
        public DM_VARLIMIT dmVarLimit;
        [MarshalAs(UnmanagedType.Struct)]
        public Object dmStart;
        [MarshalAs(UnmanagedType.Struct)]
        public Object dmDefault;
        public UInt32 dwNotify;
        public UInt32 dwFlags;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.VAR_SPECIFIC + 1)]
        public string szSpecific;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.GROUP_NAME + 1)]
        public string szGroup; 
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.CONNECTION_NAME + 1)]
        public string szConnection;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STDLIB._MAX_PATH + 1)]
        public string szChannel;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.UNIT_NAME + 1)]
        public string szUnit;
        public MCP_VARIABLE_SCALES Scaling;
        public UInt32 dwASDataSize;
        public UInt32 dwOSDataSize;
        public UInt32 dwVarProperty;
        public UInt32 dwFormat;
    }
}
