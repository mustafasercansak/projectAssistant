using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace General
{
    // The types are mapped to C# types as follows:
    //
    // byte <=> VT_UI1
    // sbyte <=> VT_I1
    // char <=> VT_LPSTR (size 1)
    // ushort <=> VT_UI2
    // short <=> VT_I2
    // String <=> VT_LPWSTR
    // uint <=> VT_UI4
    // int <=> VT_I4
    // UInt64 <=> VT_UI8
    // Int64 <=> VT_I8
    // float <=> VT_R4
    // double <=> VT_R8
    // Guid <=> VT_CLSID
    // bool <=> VT_BOOL
    // BitmapMetadata <=> VT_UNKNOWN (IWICMetadataQueryReader)
    // BitmapMetadataBlob <=> VT_BLOB
    //
    // For array types:
    //
    // byte[] <=> VT_UI1|VT_VECTOR
    // sbyte[] <=> VT_I1|VT_VECTOR
    // char[] <=> VT_LPSTR (size is length of array - treated as ASCII string) - read back is String, use ToCharArray().
    // char[][] <=> VT_LPSTR|VT_VECTOR (array of ASCII strings)
    // ushort[] <=> VT_UI2|VT_VECTOR
    // short[] <=> VT_I2|VT_VECTOR
    // String[] <=> VT_LPWSTR|VT_VECTOR
    // uint[] <=> VT_UI4|VT_VECTOR
    // int[] <=> VT_I4|VT_VECTOR
    // UInt64[] <=> VT_UI8|VT_VECTOR
    // Int64[] <=> VT_I8|VT_VECTOR
    // float[] <=> VT_R4|VT_VECTOR
    // double[] <=> VT_R8|VT_VECTOR
    // Guid[] <=> VT_CLSID|VT_VECTOR
    internal enum VARTYPE : short
    {
        VT_EMPTY = 0,
        VT_NULL = 1,
        VT_I2 = 2,
        VT_I4 = 3,
        VT_R4 = 4,
        VT_R8 = 5,
        VT_CY = 6,
        VT_DATE = 7,
        VT_BSTR = 8,
        VT_DISPATCH = 9,
        VT_ERROR = 10,
        VT_BOOL = 11,
        VT_VARIANT = 12,
        VT_UNKNOWN = 13,
        VT_DECIMAL = 14,
        VT_I1 = 16,
        VT_UI1 = 17,
        VT_UI2 = 18,
        VT_UI4 = 19,
        VT_I8 = 20,
        VT_UI8 = 21,
        VT_INT = 22,
        VT_UINT = 23,
        VT_VOID = 24,
        VT_HRESULT = 25,
        VT_PTR = 26,
        VT_SAFEARRAY = 27,
        VT_CARRAY = 28,
        VT_USERDEFINED = 29,
        VT_LPSTR = 30,
        VT_LPWSTR = 31,
        VT_RECORD = 36,
        VT_FILETIME = 64,
        VT_BLOB = 65,
        VT_STREAM = 66,
        VT_STORAGE = 67,
        VT_STREAMED_OBJECT = 68,
        VT_STORED_OBJECT = 69,
        VT_BLOB_OBJECT = 70,
        VT_CF = 71,
        VT_CLSID = 72,
        VT_VECTOR = 0x1000,
        VT_ARRAY = 0x2000,
        VT_BYREF = 0x4000
    }
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    internal struct CY
    {
        public uint Lo;
        public int Hi;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    internal struct BSTRBLOB
    {
        public uint cbSize;
        public IntPtr pData;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    internal struct CArray
    {
        public uint cElems;
        public IntPtr pElems;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    internal struct BLOB
    {
        public uint cbSize;
        public IntPtr pBlobData;
    }
    [StructLayout(LayoutKind.Explicit,Size = 8)]
    internal class VariantUnion
    {
        /// <summary>
        /// CHAR
        /// </summary>
        [FieldOffset(0)]
        internal sbyte cVal;

        /// <summary>
        /// UCHAR
        /// </summary>
        [FieldOffset(0)]
        internal byte bVal;

        /// <summary>
        /// SHORT
        /// </summary>
        [FieldOffset(0)]
        internal short iVal;

        /// <summary>
        /// USHORT
        /// </summary>
        [FieldOffset(0)]
        internal ushort uiVal;

        /// <summary>
        /// LONG
        /// </summary>
        [FieldOffset(0)]
        internal int lVal;

        /// <summary>
        /// ULONG
        /// </summary>
        [FieldOffset(0)]
        internal uint ulVal;

        /// <summary>
        /// INT
        /// </summary>
        [FieldOffset(0)]
        internal int intVal;

        /// <summary>
        /// UINT
        /// </summary>
        [FieldOffset(0)]
        internal uint uintVal;

        /// <summary>
        /// LARGE_INTEGER
        /// </summary>
        [FieldOffset(0)]
        internal Int64 hVal;

        /// <summary>
        /// ULARGE_INTEGER
        /// </summary>
        [FieldOffset(0)]
        internal UInt64 uhVal;

        /// <summary>
        /// FLOAT
        /// </summary>
        [FieldOffset(0)]
        internal float fltVal;

        /// <summary>
        /// DOUBLE
        /// </summary>
        [FieldOffset(0)]
        internal double dblVal;

        /// <summary>
        /// VARIANT_BOOL
        /// </summary>
        [FieldOffset(0)]
        internal short boolVal;

        /// <summary>
        /// SCODE
        /// </summary>
        [FieldOffset(0)]
        internal int scode;

        /// <summary>
        /// CY
        /// </summary>
        [FieldOffset(0)]
        internal CY cyVal;

        /// <summary>
        /// DATE
        /// </summary>
        [FieldOffset(0)]
        internal double date;

        /// <summary>
        /// FILETIME
        /// </summary>
        [FieldOffset(0)]
        internal System.Runtime.InteropServices.ComTypes.FILETIME filetime;


        /// <summary>
        /// CLSID*   
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr puuid;

        /// <summary>
        /// CLIPDATA*    
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr pclipdata;

        /// <summary>
        /// BSTR
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr bstrVal;

        /// <summary>
        /// BSTRBLOB   
        /// </summary>
        [FieldOffset(0)]
        internal BSTRBLOB bstrblobVal;

        /// <summary>
        /// BLOB
        /// </summary>
        [FieldOffset(0)]
        internal BLOB blob;

        /// <summary>
        /// LPSTR
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr pszVal;

        /// <summary>
        /// LPWSTR
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr pwszVal;

        /// <summary>
        /// IUnknown*
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr punkVal;

        /// <summary>
        /// IDispatch*
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr pdispVal;

        /// <summary>
        /// IStream*
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr pStream;

        /// <summary>
        /// IStorage*
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr pStorage;

        /// <summary>
        /// LPVERSIONEDSTREAM
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr pVersionedStream;

        /// <summary>
        /// LPSAFEARRAY 
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr parray;

        /// <summary>
        /// Placeholder for
        /// CAC, CAUB, CAI, CAUI, CAL, CAUL, CAH, CAUH; CAFLT,
        /// CADBL, CABOOL, CASCODE, CACY, CADATE, CAFILETIME, 
        /// CACLSID, CACLIPDATA, CABSTR, CABSTRBLOB, 
        /// CALPSTR, CALPWSTR, CAPROPVARIANT 
        /// </summary>
        [FieldOffset(0)]
        internal CArray cArray;

        /// <summary>
        /// CHAR*
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr pcVal;

        /// <summary>
        /// UCHAR* 
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr pbVal;

        /// <summary>
        /// SHORT* 
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr piVal;

        /// <summary>
        /// USHORT* 
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr puiVal;

        /// <summary>
        /// LONG* 
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr plVal;

        /// <summary>
        /// ULONG* 
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr pulVal;

        /// <summary>
        /// INT* 
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr pintVal;

        /// <summary>
        /// UINT* 
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr puintVal;

        /// <summary>
        /// FLOAT* 
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr pfltVal;

        /// <summary>
        /// DOUBLE* 
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr pdblVal;

        /// <summary>
        /// VARIANT_BOOL* 
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr pboolVal;

        /// <summary>
        /// DECIMAL* 
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr pdecVal;

        /// <summary>
        /// SCODE* 
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr pscode;

        /// <summary>
        /// CY* 
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr pcyVal;

        /// <summary>
        /// DATE* 
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr pdate;

        /// <summary>
        /// BSTR*
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr pbstrVal;

        /// <summary>
        /// IUnknown** 
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr ppunkVal;

        /// <summary>
        /// IDispatch** 
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr ppdispVal;

        /// <summary>
        /// LPSAFEARRAY* 
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr pparray;

        /// <summary>
        /// PROPVARIANT*
        /// </summary>
        [FieldOffset(0)]
        internal IntPtr pvarVal;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 0, Size = 16)]
    internal class Variant
    {
        internal VARTYPE vt = VARTYPE.VT_EMPTY;
        internal ushort wReserved1;
        internal ushort wReserved2;
        internal ushort wReserved3;
        internal VariantUnion u = new VariantUnion();
        public Variant()
        {
        }
        public Variant(VARTYPE vt, object value)
        {
            this.vt = vt;
            if (vt == VARTYPE.VT_BOOL)
                u.boolVal = (short)((bool)value ? 1: 0);
            else if(vt == VARTYPE.VT_UI1)
                u.bVal = (byte)value;
            else if (vt == VARTYPE.VT_I1)
                u.cVal = (sbyte)value;
            else if (vt == VARTYPE.VT_R4)
                u.fltVal = (float)value;
            else if (vt == VARTYPE.VT_R8)
                u.dblVal = (double)value;
            else if (vt == VARTYPE.VT_BSTR)
            {
                u.bstrVal = Marshal.StringToBSTR((string)value);
            }                
        }
        public Variant(bool boolVal) : this(VARTYPE.VT_BOOL, boolVal)
        {
        }
        public Variant(byte bVal) : this(VARTYPE.VT_UI1, bVal)
        {
        }
        public Variant(sbyte cVal) : this(VARTYPE.VT_I1, cVal)
        {
        }
        public Variant(float fltVal) : this(VARTYPE.VT_R4, fltVal)
        {
        }
        public Variant(double dblVal) : this(VARTYPE.VT_R8, dblVal)
        {
        }
        public Variant(string bstrVal) : this(VARTYPE.VT_BSTR, bstrVal)
        {
        }
        internal void Clear()
        {
            if(vt == VARTYPE.VT_BSTR)
            {
                if(u.bstrVal!= IntPtr.Zero)
                    Marshal.FreeBSTR(u.bstrVal);
            }
        }
    }
}
