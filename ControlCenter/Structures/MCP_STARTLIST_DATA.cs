using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class MCP_STARTLIST_DATA
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STDLIB._MAX_PATH + 1)]
        public string szProjectFile;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STDLIB.MAX_COMPUTERNAME_LENGTH + 1)]
        public string szMachineName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STDLIB._MAX_PATH + 1)]
        public string szApplication;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STDLIB._MAX_PATH + 1)]
        public string szParams;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STDLIB._MAX_PATH + 1)]
        public string szWorkingDir;
        [MarshalAs(UnmanagedType.Bool)]
        public bool fUseProjectDir;//If fUseProjectDir = TRUE, the project directory is to be used as working directory.
        public OpenMode nMode;
    }
}
