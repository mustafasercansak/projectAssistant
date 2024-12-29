using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    internal enum DM_SD
    {
        LOCAL= 0x00000001, // only to local applications (excludes all other flags !!)
        ALL_MACHINES= 0x00000002, // To all machines in the project
        ALL_SERVERS= 0x00000004, // To all servers in the project
        ALL_CLIENTS= 0x00000008, // To all clients in the project
        RELATED_MACHINES= 0x00000010, // To all clients that belong to the same server as the local machine
        FIRST_SERVER= 0x00000020, // To the first available server on the local machine
        PRIMARY_SERVER= 0x00000040, // To the local machine's primary server
        EXCEPT_LOCAL= 0x00000080, // To all hosts that match the address description, except local ones
    }
}
