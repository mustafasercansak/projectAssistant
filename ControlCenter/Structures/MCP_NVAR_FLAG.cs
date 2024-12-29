using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    internal enum MCP_NVAR_FLAG
    {
        NONE = 0,
        CREATE = 1, //Create tag
        MODIFY = 2, //Modify tag (do not use in Runtime)
        TEST =  3,  //Checks if a tag is available.
    }
}
