using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    internal enum DM_VARIABLE_NOTIFY
    {
        MAX_LIMIT = 0x1,// when high limit is reached
        MIN_LIMIT = 0x2,// when low limit is reached
        FORMAT_ERROR  = 0x4,//if conversion error occurs
        ACCESS_FAULT = 0x8,//illegal write access
        APPLICATION_WRITE = 0x10,//write access by application
        PROCESS_WRITE = 0x20,//write access by process
    }
}
