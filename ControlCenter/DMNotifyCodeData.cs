using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    public enum DMNotifyCodeData
    {
        APPLICATION_DATA = 0x00000001, // Class Data : Data sent by the application
        VARIABLE_DATA = 0x00000002, // Class Data : variable data
        //FIRE_DATA = 0x00004711, // Data sent by DMFireNotifyData
    }
}
