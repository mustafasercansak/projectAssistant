using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    internal enum GSC_AP: UInt32
    {
        UNKNOWN = 0,
        SFCT = 0x11, // Standart functions
        PFCT = 0x12, // Project  Function
        GSC = 0x14, // GSC - Action
    }
}
