using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    internal static class Converter
    {
        public static VarEnum ToVarEnum(this DMVarTypes varType)
        {
            switch (varType)
            {
                case DMVarTypes.BIT:
                    return VarEnum.VT_BOOL;
                case DMVarTypes.SBYTE:
                    return VarEnum.VT_I1; ;
                case DMVarTypes.BYTE:
                    return VarEnum.VT_UI1;
                case DMVarTypes.SWORD:
                    return VarEnum.VT_I2;
                case DMVarTypes.WORD:
                    return VarEnum.VT_UI2;
                case DMVarTypes.SDWORD:
                    return VarEnum.VT_I4;
                case DMVarTypes.DWORD:
                    return VarEnum.VT_UI4;
                case DMVarTypes.FLOAT:
                    return VarEnum.VT_R4;
                case DMVarTypes.DOUBLE:
                    return VarEnum.VT_R8;
                case DMVarTypes.TEXT_8:
                    return VarEnum.VT_BSTR;
                case DMVarTypes.TEXT_16:
                    return VarEnum.VT_BSTR;
                case DMVarTypes.RAW:
                    return VarEnum.VT_VARIANT;
                case DMVarTypes.ARRAY:
                    return VarEnum.VT_ARRAY;
                case DMVarTypes.STRUCT:
                    return VarEnum.VT_USERDEFINED;
                case DMVarTypes.BITFIELD_8:
                    return VarEnum.VT_VARIANT;
                case DMVarTypes.BITFIELD_16:
                    return VarEnum.VT_VARIANT;
                case DMVarTypes.BITFIELD_32:
                    return VarEnum.VT_VARIANT; ;
                case DMVarTypes.TEXTREF:
                    return VarEnum.VT_LPWSTR;
                case DMVarTypes.DATETIME:
                    return VarEnum.VT_DATE;
                case DMVarTypes.SQWORD:
                    return VarEnum.VT_I8;
                case DMVarTypes.QWORD:
                    return VarEnum.VT_UI8;
                default:
                    return VarEnum.VT_VARIANT;
            }
        }
    }
}
