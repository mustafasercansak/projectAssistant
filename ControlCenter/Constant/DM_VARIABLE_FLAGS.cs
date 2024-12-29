using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [Flags]
    internal enum DM_VARIABLE_FLAGS
    {
        HAS_MIN_LIMIT = 0x8, // Tag has fixed low limit
        HAS_MAX_LIMIT = 0x10, // Tag has fixed high limit
        HAS_DEFAULT_VALUE = 0x00000020, // Tag has default value
        HAS_STARTUP_VALUE = 0x00000040, // Tag has start-up value

    }
}
