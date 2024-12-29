using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [Flags]
    internal enum MCP_VARPROT
    {
        NOSCALE = 0,
        TOPLIMITERR                = 0x00000001,   // Verletzung Obergrenze
        BOTTEMLIMITERR             = 0x00000002,   // Verletzung Untergrenze
        TRANSFORMATIONERR          = 0x00000004,   // Wandlungsfehler
        WRITEERR                   = 0x00000010,   // Unzulässigem Schreibzugriff
        WRITEERRAPPLICATION        = 0x00000020,   // Schribzugriff Applikation
        WRITEERRPROCESS            = 0x00000040,   // Schreibzugriff Prozess
    }
}
