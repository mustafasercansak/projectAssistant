using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using General;

namespace ProjectManager
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class PMPROJECT_INFO
    {
        public IntPtr hwndProjectWindow;

        public PMPRJ dwProjectState;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STDLIB._MAX_PATH)]
        public string szProjectName;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STDLIB._MAX_PATH)]
        public string szProjectPath;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STDLIB._MAX_PATH)]
        public string szApplicationPath;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STDLIB._MAX_PATH)]
        public string szGlobalLibDir;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STDLIB._MAX_PATH)]
        public string szProjectLibSubDir;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STDLIB._MAX_PATH)]
        public string szMachineName;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STDLIB._MAX_PATH)]
        public string szDSNName;

        public UInt32 dwMachineType;

    }
}
