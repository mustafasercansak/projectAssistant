using General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    internal class Drivers: Objects
    {
        public static bool EnumDrivers(CMN_ERROR error, string projectFile, List<object> drivers) => Drivers.DMEnumObject(
            DMObjects.DRIVER,
            projectFile,
            IntPtr.Zero,
            (DMObjects dwObjectType, IntPtr lpvData, IntPtr lpvUser) =>
            {
                drivers.Add(Marshal.PtrToStructure<DM_ENUM_DRIVER_DATA>(lpvData));
                return true;
            },
            IntPtr.Zero,
            0,
            error
            );
        public static bool CreateDriver(CMN_ERROR error, string projectFile ,string path)
        {
            MCP_NEWDRIVER_DATA driverData = new MCP_NEWDRIVER_DATA()
            {
                szPath = path,
            };
            driverData.dwSize = (uint)Marshal.SizeOf(driverData);
            IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(driverData));
            Marshal.StructureToPtr(driverData, intPtr, false);
            return DMCreateObject(DMObjects.DRIVER, projectFile, intPtr, 1, 0, error);
        }
        public static bool DeleteDriver(CMN_ERROR error, string projectFile, string name) => DMDeleteObject(DMObjects.DRIVER, projectFile, name, 1, 0, error);
    }
}
