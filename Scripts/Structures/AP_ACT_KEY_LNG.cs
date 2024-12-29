using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class AP_ACT_KEY_LNG
    {
        public UInt32 dwKeyType;
        public UInt32 dwID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = AP_MAX.ACTION_NAME + 1)]
        public string szActionName;
        public UInt32 dwScriptLocale;
        public UInt32 dwCycle;
        public IntPtr pVariant;
        public UInt32 dwVariantItem;
        public UInt32 dwerror;
        public UInt32 lpvUser;
    }
}
