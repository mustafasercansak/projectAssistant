using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class AP_CYCLE_INDEX_STRUCT
    {
        public UInt32 dwPictureCycleIndex;

        public UInt32 dwWindowCycleIndex;

    }
}
