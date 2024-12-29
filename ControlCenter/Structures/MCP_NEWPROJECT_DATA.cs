using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class MCP_NEWPROJECT_DATA
    {
        public UInt32 dwFlags;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STDLIB._MAX_PATH + 1)]
        public string szProjectFile;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.VAR_NAME + 1)]
        public string szProducer;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.VAR_NAME + 1)]
        public string szCreationDate;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.VAR_NAME + 1)]
        public string szEditor;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.VAR_NAME + 1)]
        public string szLastMod;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.VAR_NAME + 1)]
        public string szVersion;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.VAR_NAME + 1)]
        public string szComment;
    }
}
