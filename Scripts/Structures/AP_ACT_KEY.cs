using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class AP_ACT_KEY
    {
        public UInt32 dwKeyType;
        UInt32 dwID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = AP_MAX.ACTION_NAME + 1)]
        public string szActionName;
        UInt32 dwCycle;
        IntPtr pVariant;
        UInt32 dwVariantItem;
        UInt32 dwerror;
        UInt32 lpvUser;
    }
}
