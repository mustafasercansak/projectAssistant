using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [Flags]
    internal enum DM_VARFILTER_TYPES
    {
        NONE = 0x00000000, // No filter
        TYPE = 0x00000001, // Use filter criterion type
        GROUP = 0x00000002, // .. group name
        NAME = 0x00000004, // .. variable name
        CONNECTION = 0x00000008, // .. log. connection (name)
        NAME_WILDCARD = 0x00000010, // Name with wildcard (* and ?)
        TYPENAME = 0x00000020, // Type is specified via name
        FAST_CALLBACK = 0x00010000,
        LOCAL_ONLY = 0x00020000,
    }
}
