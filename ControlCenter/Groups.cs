using General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    internal class Groups : Objects
    {
        public static bool EnumGroups(CMN_ERROR error, string projectFile, List<object> groups) => DMEnumObject(
            DMObjects.GROUP, 
            projectFile,
            IntPtr.Zero,
            (DMObjects dwObjectType, IntPtr lpvData, IntPtr lpvUser) =>
            {
                groups.Add(Marshal.PtrToStructure<DM_ENUM_GROUP_DATA>(lpvData));
                return true;
            }, IntPtr.Zero, 0, error);

        public static bool CreateGroup(CMN_ERROR error, string projectFile, string connection, string groupName)
        {
            MCP_NEWGROUP_DATA groupData = new MCP_NEWGROUP_DATA()
            {
                szConnection = connection,
                szGroupName = groupName
            };
            groupData.dwSize = (uint)Marshal.SizeOf(groupData);
            IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(groupData));
            Marshal.StructureToPtr(groupData, intPtr, false);
            return DMCreateObject(DMObjects.GROUP, projectFile, intPtr, 1, 0, error);
        }

        public static bool RenameGroup(CMN_ERROR error, string projectFile, string oldName, string newName) => DMRenameObject(DMObjects.GROUP, projectFile, oldName, newName, 1, 0, error);

        public static bool DeleteGroup(CMN_ERROR error, string projectFile, string groupName) => DMDeleteObject(DMObjects.GROUP, projectFile, groupName, 1, 0, error);
    }
}
