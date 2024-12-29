using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    public enum DMVarTypes
    {
        BIT = 1, /* binary variable */
        SBYTE = 2, /* Signed 8-bit value */
        BYTE = 3, /* Unsigned 8-bit value */
        SWORD = 4, /* Signed 16-bit value */
        WORD = 5, /* Unsigned 16-bit value */
        SDWORD = 6, /* Signed 32-bit value */
        DWORD = 7, /* Unsigned 32-bit value */
        FLOAT = 8, /* floating point number 32-bit IEEE 754 */
        DOUBLE = 9, /* Floating point number 64-bit IEEE 754 */
        TEXT_8 = 10, /* Text variable 8-bit character set */
        TEXT_16 = 11, /* Text variable 16-bit character set */
        RAW = 12, /* raw data type */
        ARRAY = 13, /* array variable */
        STRUCT = 14, /* structure variable */
        BITFIELD_8 = 15,    /* 8-bit bit field variable */
        BITFIELD_16 = 16,   /* 16-bit bit field variable */
        BITFIELD_32 = 17,   /* 32-bit bit field variable */
        TEXTREF = 18,       /* Text reference from text library */
        DATETIME = 19,      /* Date/Time */
        SQWORD = 20,        /* Signed 64-Bit value */
        QWORD = 21,         /* Unsigned 64-bit value */
    }
}
