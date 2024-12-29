using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    public enum MCPVarProt
    {
        TOPLIMITERR = 0x00000001, // violation upper limit
        BOTTEMLIMITERR = 0x00000002, // violation lower limit
        TRANSFORMATIONERR = 0x00000004, // Conversion error
        WRITEERR = 0x00000010, // Illegal write access
        WRITEERRAPPLICATION = 0x00000020, // Write access application
        WRITEERRPROCESS = 0x00000040, // Write access process
    }
}
