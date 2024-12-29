using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    public enum MCP_NPRO_FLAG
    {
        CREATE = 1,
        MODIFY = 2,
        TEST = 3,//Checks if a project exists.If the project already exists, the DM_E_ALREADY_EXIST error is returned.

    }
}
