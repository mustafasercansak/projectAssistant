using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace General
{
    public class PointerHelper
    {
        public static IntPtr ArrayToPointer<T>(T[] items)
        {
            int num = 0;
            for (int i = 0; i < (int)items.Length; i++)
            {
                num += Marshal.SizeOf(items[i]);
            }
            IntPtr intPtr = Marshal.AllocHGlobal(num);
            int num1 = 0;
            byte[] numArray = new byte[num];
            for (int j = 0; j < (int)items.Length; j++)
            {
                int num2 = Marshal.SizeOf(items[j]);
                IntPtr intPtr1 = Marshal.AllocHGlobal(num2);
                Marshal.StructureToPtr(items[j], intPtr1, false);
                Marshal.Copy(intPtr1, numArray, num1, num2);
                Marshal.FreeHGlobal(intPtr1);
                num1 += num2;
            }
            Marshal.Copy(numArray, 0, intPtr, num);
            return intPtr;
        }

        public static T[] PointerToArray<T>(IntPtr pArray, int length)
        {
            T[] structure = new T[length];
            IntPtr intPtr = new IntPtr(pArray.ToInt64());
            for (int i = 0; i < length; i++)
            {
                structure[i] = (T)Marshal.PtrToStructure(intPtr, typeof(T));
                intPtr = IntPtr.Add(intPtr, Marshal.SizeOf(structure[i]));
            }
            return structure;
        }
    }
}
