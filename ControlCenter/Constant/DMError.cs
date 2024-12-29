using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    public enum DMError
    {
        OK = 0,
        CANCEL = 1,
        FILE = 2,
        UPDATE = 3,
        NO_RT_PRJ = 4,
        NOT_SUPPORTED = 5,
        ALREADY_CONNECTED = 6,
        NOT_CONNECTED = 7,
        INVALID_TAID = 8,
        INVALID_KEY = 9,
        INVALID_TYPE = 10,
        MAX_LIMIT = 11,
        MIN_LIMIT = 12,
        MAX_RANGE = 13,
        MIN_RANGE = 14,
        ACCESS_FAULT = 15,
        TIMEOUT = 16,
        ALREADY_EXIST = 17,
        PARAM = 18,
        INV_PRJ = 19,
        UNKNOWN = 20,
        OOM = 21,
        NOT_CREATED = 22,
        MACHINE_NOT_FOUND = 23,
        NO_INFO_FOUND = 24,
        INTERNAL = 25,
        INVALID_LOCALE = 26,
        COMMUNICATION = 27,
        DONT_EXIST = 28,
        ALREADY_ACTIVATED = 29,
        NO_OPEN_PROJECT = 30,
        ALREADY_DEACTIVATED = 31,
        NO_RIGHTS = 32,
        NOT_DELETED = 33,
        LICENSE = 34,
        LICENSE_LIMIT = 35,
        INVALID_OBJECTTYPE = 36,
        OP_REQUIERES_PRJEDITMODE = 37,
        INTERFACE = 38,
        UNIT_NOT_FOUND = 39,
        CONNECTION_NOT_FOUND = 40,
        NODEFAULTSERVER = 257,
        NOLOCALSERVER = 258,
        NOSERVER = 259,
        NOMC = 260,
        NOMCDEFAULTSERVER = 261,
        SYS_ERROR = 268435456
    }
}
