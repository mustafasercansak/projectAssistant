using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    public enum MCP_DVAR_FLAG
    {
        DELETE = 1,
        TEST = 2,//Checks if a project exists.If the project already exists, the DM_E_ALREADY_EXIST error is returned.2

    }
}
