using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    public enum DMGroupFilter
    {
        DRIVER =         0x00000001,    // ...Drivername
        UNIT    =       0x00000002 ,   // .. Unitname
        CONNECTION =     0x00000002,    // .. Connectionname
    }
}
