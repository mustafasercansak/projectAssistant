using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    internal class Helper
    {
        static Type[] unmagedTypes =
        {
            typeof(sbyte),  typeof(byte),   typeof(short),  typeof(ushort), typeof(int),    
            typeof(uint),   typeof(long),   typeof(ulong),  typeof(char),   typeof(float),
            typeof(double), typeof(decimal),    typeof(bool),
            typeof(sbyte[]),  typeof(byte[]),   typeof(short[]),  typeof(ushort[]), typeof(int[]),
            typeof(uint[]),   typeof(long[]),   typeof(ulong[]),  typeof(char[]),   typeof(float[]),
            typeof(double[]), typeof(decimal[]),    typeof(bool[]),
        };

        public static IntPtr StringToPtr<T>(string[] items) where T : struct
        {
            int size = items.Length;
            //build array of pointers to string
            IntPtr[] InPointers = new IntPtr[size];
            int dim = IntPtr.Size * size;
            IntPtr rRoot = Marshal.AllocCoTaskMem(dim);
            for (int i = 0; i < size; i++)
            {
                if (typeof(T) == typeof(char))
                {
                    InPointers[i] = Marshal.StringToCoTaskMemUni(items[i]);
                }
                else if (typeof(T) == typeof(byte))
                {
                    InPointers[i] = Marshal.StringToCoTaskMemAnsi(items[i]);
                }
            }
            //copy the array of pointers
            Marshal.Copy(InPointers, 0, rRoot, size);
            return rRoot;
        }

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

        public static T[] Convert<T>(string[] tags) where T: DM_VARKEY, new()
        {
            T[] array = CreateArray<T>(tags.Length);
            for (int i = 0; i < tags.Length; i++)
            {
                array[i] = new T();
                if(typeof(T) == typeof(DM_VARKEY))
                {
                    array[i].dwID = 0;
                    array[i].dwKeyType = 2;
                    array[i].szName = tags[i];
                }                
            }
            return array;
        }

        static void CheckSubs(object o)
        {
            foreach (var item in o.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                Type t1 = item.FieldType;
                if (t1.IsClass && !t1.IsAnsiClass)
                {
                    item.SetValue(o, Create(item.FieldType));
                }
                else if (t1.IsAnsiClass)
                {
                    if (t1 == typeof(uint))
                    {
                        item.SetValue(o, (uint)0);
                    }
                    else if (t1 == typeof(string))
                    {
                        item.SetValue(o, "");
                    }
                }
            }
        }

        public static T Create<T>() where T: new ()
        {
            var o = new T();
            CheckSubs(o);
            return o;
        }

        public static object Create(Type type)
        {
            var o = Activator.CreateInstance(type);
            foreach (var item in type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                Type t1 = item.FieldType;
                if (t1.IsClass && !t1.IsAnsiClass)
                {
                    item.SetValue(o, Create(item.FieldType));
                } 
                else if(t1.IsAnsiClass)
                {
                    if (t1 == typeof(uint))
                    {
                        item.SetValue(o, (uint)0);
                    }                    
                }
            }
            return o;
        }

        public static T[] CreateArray<T>(int length) where T : new()
        {
            var items = new T[length];
            for (int i = 0; i < length; i++)
            {
                if(typeof(T).IsClass)
                {
                    items[i] = (T)Create(typeof(T));
                } 
            }
            return items;
        }

        static string SizeOf<T>() where T : unmanaged => $"{typeof(T)}->{Marshal.SizeOf<T>()}";

        public static string SizeOf(Type t)
        {
            string str = "";
            if(t.IsClass)
            {
                str = str;
            }
            try
            {
                str += $"{t.Name} => {Marshal.SizeOf(t)}\r\n";
            }
            catch (Exception)
            {
                str += $"{t.Name} => \r\n";
            }
            foreach (var item in t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                if (item.FieldType.IsNested)
                {
                    str += SizeOf(item.FieldType);
                }
                else
                {
                    try
                    {
                        str += $"{item.Name} => {Marshal.SizeOf(item)}{Environment.NewLine}";
                    }
                    catch (Exception)
                    {
                        str += $"{item.Name} => \r\n";
                    }
                }
            }

            return str;
        }

        public static Variant[] ToVariantArray(string[] values) => values.Select(z => new Variant(z)).ToArray();

        public static DM_VARKEY ToDMVarKey(string value) => new DM_VARKEY() { dwID = 0, dwKeyType = 2, lpvUserData = IntPtr.Zero, szName = value };
        public static DM_VARKEY[] ToDMVarKeys(string[] tags) => tags.Select(z => Helper.ToDMVarKey(z)).ToArray();
    }
}
