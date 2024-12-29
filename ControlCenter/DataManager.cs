using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text.RegularExpressions;
using System.Data.Common;
using System.Xml.Linq;
using Microsoft.CSharp.RuntimeBinder;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.IO.Ports;
using System.Runtime.Serialization;
using System.Runtime.InteropServices.WindowsRuntime;
using General;
using System.Text;

namespace ControlCenter
{
    public class DataManager
    {
        // event
        public event DataManagerNotifyEventHandler DataManagerNotify;
        public event DataManagerNotifyVariableEventHandler DataManagerNotifyVariable;
        string _appName;
        UInt32 _dwItems = 0;
        ProjectInfo projectInfo => Share.ProjectInfo;
        List<FileInfo> channels;
        private static UInt32 dwTAID;
        private Object waitLock = new Object();
        Action onProjectOpened, onProjectClosed;
        public DataManager(string appName)
        {
            this._appName = appName;
            CMN_ERROR error = new CMN_ERROR();           
        }
        ~DataManager()
        {
            CMN_ERROR error = new CMN_ERROR();
            if (ConnectionState(error)) StopAllUpdates(error);
            if (ConnectionState(error)) Disconnect(error);
        }
        protected virtual void OnDataManagerNotify(DataManagerNotifyEventArgs e)
        {
            switch ((DMNotify)e.NotifyCode)
            {
                case DMNotify.QUEUE_50_PERCENT:
                    break;
                case DMNotify.QUEUE_60_PERCENT:
                    break;
                case DMNotify.QUEUE_70_PERCENT:
                    break;
                case DMNotify.QUEUE_80_PERCENT:
                    break;
                case DMNotify.QUEUE_90_PERCENT:
                    break;
                case DMNotify.QUEUE_OVERFLOW:
                    break;
                case DMNotify.CYCLES_CHANGED:
                    break;
                case DMNotify.MACHINES_CHANGED:
                    break;
                case DMNotify.PROJECT_OPENED:
                    OnProjectOpenedInternal();
                    break;
                case DMNotify.PROJECT_CLOSED:
                    OnProjectClosedInternal();
                    break;
                case DMNotify.SYSTEM_LOCALE:
                    break;
                case DMNotify.DATA_LOCALE:
                    break;
                case DMNotify.PROJECT_RUNTIME:
                    projectInfo.RuntimeActive = true;
                    break;
                case DMNotify.PROJECT_EDIT:
                    projectInfo.RuntimeActive = false;
                    break;
                case DMNotify.HOTKEY_CHANGE:
                    break;
                case DMNotify.URSEL:
                    break;
                case DMNotify.BODO:
                    break;
                case DMNotify.BEGIN_PROJECT_EDIT:
                    break;
                case DMNotify.RT_LIC:
                    break;
                case DMNotify.CS_LIC:
                    break;
                default:
                    break;
            }
            DataManagerNotify?.Invoke(null, e);
        }
        void OnProjectOpenedInternal()
        {
            if(ProjectInfo(new CMN_ERROR(), projectInfo))
            {
                onProjectOpened?.Invoke();
            }
        }
        void OnProjectClosedInternal()
        {
            projectInfo.ProjectFile = "";
            onProjectClosed?.Invoke();
        }
        public ServiceController Service => ServiceController.GetServices().FirstOrDefault(z => z.ServiceName == "MSSQL$WINCC");
        public ServiceControllerStatus SQLServerStatus 
        {
            get
            {
                return Service.Status;
            }
        }

        public Action OnProjectOpened { set => onProjectOpened = value; }
        public Action OnProjectClosed { set => onProjectClosed = value; }

        bool DataManagerNotifyProcIntern(UInt32 dwNotifyClass,UInt32 dwNotifyCode,IntPtr lpbyData,UInt32 dwItems,IntPtr lpvUser)
        {
            OnDataManagerNotify(new DataManagerNotifyEventArgs(dwNotifyClass, dwNotifyCode, lpbyData, dwItems, lpvUser));
            return true;
        }
        public bool Connect(CMN_ERROR error)
        {
            if(GeneralFunctions.DMConnect(_appName, DataManagerNotifyProcIntern, IntPtr.Zero, error))
            {
                OnProjectOpenedInternal();
                return true;
            }
            return false;
        }
        public bool ConnectionState(CMN_ERROR error) => GeneralFunctions.DMGetConnectionState(error);
        public bool Disconnect(CMN_ERROR error) => GeneralFunctions.DMDisConnect(error);
        public bool ProjectInfo(CMN_ERROR error, ProjectInfo projectInfo)
        {
            DM_PROJECT_INFO dM_PROJECT_INFO = new DM_PROJECT_INFO();
            DM_DIRECTORY_INFO dM_DIRECTORY_INFO = new DM_DIRECTORY_INFO();
            if (!ProjectAdministration.DMEnumOpenedProjects(_dwItems, (info, ptr) =>
            {
                dM_PROJECT_INFO = info;
                return true;
            }, IntPtr.Zero, error))
            {
                return false;
            }
            if (!ProjectAdministration.DMGetProjectDirectory(_appName, dM_PROJECT_INFO.szProjectFile, dM_DIRECTORY_INFO, error))
            {
                return false;
            }
            //WinCC Directory
            var dir = new DirectoryInfo(dM_DIRECTORY_INFO.szGlobalLibDir);
            if (dir.Parent == null) return false;
            dir = new DirectoryInfo($@"{dir.Parent.FullName}\bin");
            var fVersion = FileVersionInfo.GetVersionInfo($@"{dir.FullName}\WinCCExplorer.exe");
            channels = dir.GetFiles("*.chn").ToList();

            projectInfo.ProjectFile = dM_PROJECT_INFO.szProjectFile;
            projectInfo.DSNName = dM_PROJECT_INFO.szDSNName;
            projectInfo.DataLocale = new CultureInfo((int)dM_PROJECT_INFO.dwDataLocale);
            projectInfo.ProjectDir = dM_DIRECTORY_INFO.szProjectDir;
            projectInfo.ProjectAppDir = dM_DIRECTORY_INFO.szProjectAppDir;
            projectInfo.GlobalLibDir = dM_DIRECTORY_INFO.szGlobalLibDir;
            projectInfo.ProjectLibDir = dM_DIRECTORY_INFO.szProjectLibDir;
            projectInfo.LocalProjectAppDir = dM_DIRECTORY_INFO.szLokalProjectAppDir;
            projectInfo.Version = new Version(fVersion.FileMajorPart, fVersion.FileMinorPart, fVersion.FileBuildPart);
            projectInfo.Name = new FileInfo(dM_PROJECT_INFO.szProjectFile).Name;

            return true;
        }
        public bool ExitWinCC() => GeneralFunctions.DMExitWinCCEx(1);
        public bool CreateNewProject(CMN_ERROR error, string projectDirectory, string projectName)
        {
            string projectFile = $"{projectDirectory}\\{projectName}\\{projectName}.mcp";
            if (!Directory.Exists($"{projectDirectory}\\{projectName}"))
                Directory.CreateDirectory($"{projectDirectory}\\{projectName}");
            MCP_NEWPROJECT_DATA pData = new MCP_NEWPROJECT_DATA()
            {
                szProjectFile = projectFile,
                szEditor = "Project Assistant",
                szProducer = "Project Assistant",
                szComment = $"Automatically created by Project Assistant",
                szCreationDate = DateTime.Now.ToString(),
                szLastMod = DateTime.Now.ToString(),
                dwFlags =1,
                szVersion = ""
            };
            return ProjectAdministration.GAPICreateNewProject(pData, error);
        }
        public bool ModifyStartList(CMN_ERROR error, Startup startup)
        {
            GAPI_MODIFY_STARTLIST_ENTRY entry = new GAPI_MODIFY_STARTLIST_ENTRY()
            {
                dwIndex = 2,
                OnOff = 0,
                szComment = ""
            };
            return GeneralFunctions.GAPIModifyStartListEntry(   ""
                , Environment.MachineName, 1, entry, error);
        }
        public bool OpenProjectFolder(CMN_ERROR error)
        {
            if(string.IsNullOrEmpty(projectInfo.ProjectDir))
            {
                error.szErrorText = "There is no opened project.";
                return false;
            }
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = projectInfo.ProjectDir,
                UseShellExecute = true,
                Verb = "open"
            });
            return true;
        }
        public bool ResetWinCC()
        {
            Process scriptProc = new Process();
            scriptProc.StartInfo.FileName = @"cscript";
            scriptProc.StartInfo.WorkingDirectory = @"C:\Program Files (x86)\Siemens\WinCC\bin\"; //<---very important 
            scriptProc.StartInfo.Arguments = "Reset_WinCC.vbs";
            scriptProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; //prevent console window from popping up
            scriptProc.Start();
            scriptProc.WaitForExit(); // <-- Optional if you want program running until your script exit
            scriptProc.Close();
            return true;
        }
        #region CS
        public bool OpenProject(CMN_ERROR error, string projectFile) => ProjectAdministration.DMOpenProjectDoc(projectFile, error);
        public bool EnumObjects(CMN_ERROR error, UInt32 objectType, List<object> objects) => Objects.DMEnumObject((DMObjects)objectType, projectInfo.ProjectFile, IntPtr.Zero, (DMObjects dwObjectType, IntPtr lpvData, IntPtr lpvUser) => {
            switch (dwObjectType)
            {
                case DMObjects.PROJECT:
                    break;
                case DMObjects.CLIENTMACHINE:
                    break;
                case DMObjects.SERVERMACHINE:
                    break;
                case DMObjects.DRIVER:
                    objects.Add(Marshal.PtrToStructure<DM_ENUM_DRIVER_DATA>(lpvData));
                    break;
                case DMObjects.DRIVERUNIT:
                    objects.Add(Marshal.PtrToStructure<DM_ENUM_DRIVERUNIT_DATA>(lpvData));
                    break;
                case DMObjects.CONNECTION:
                    objects.Add(Marshal.PtrToStructure<DM_ENUM_CONNECTION_DATA>(lpvData));
                    break;
                case DMObjects.GROUP:
                    objects.Add(Marshal.PtrToStructure<DM_ENUM_GROUP_DATA>(lpvData));
                    break;
                case DMObjects.TAG:
                    break;
                case DMObjects.STARTLIST:
                    objects.Add(Marshal.PtrToStructure<MCP_STARTLIST_DATA>(lpvData));
                    break;
                case DMObjects.TYPE:
                    break;
                default:
                    break;
            }
            
            return true;
        }, IntPtr.Zero, 0, error);
        public bool EnumVariables(CMN_ERROR error, [In, Out] List<object> varDatas, string group = "", string name = "", string connection = "", EnumVariablesTypes[] variablesTypes = null)
        {
            DM_VARFILTER_TYPES varfilterTypes = DM_VARFILTER_TYPES.NONE;
            if (!string.IsNullOrEmpty(group)) varfilterTypes |= DM_VARFILTER_TYPES.GROUP;
            if (!string.IsNullOrEmpty(name)) varfilterTypes |= DM_VARFILTER_TYPES.NAME;
            if (!string.IsNullOrEmpty(connection)) varfilterTypes |= DM_VARFILTER_TYPES.CONNECTION;
            UInt32[] dwTypes = variablesTypes == null ? null : Array.ConvertAll(variablesTypes, z => (UInt32)z);

            DM_VARFILTER dmVarFilter = new DM_VARFILTER()
            {
                dwFlags = varfilterTypes,
                dwNumTypes = dwTypes == null ? 0 : (UInt32)dwTypes.Length,
                pdwTypes = dwTypes,
                lpszConn = connection,
                lpszGroup = group,
                lpszName = name
            };
            if (projectInfo.Version > new Version(600, 200))
            {
                return Tags.DMEnumVariables5(
                    "",
                    dmVarFilter,
                    uint.MaxValue,
                    (ref object lpvVariantData, IntPtr lpvUser) =>
                    {
                        varDatas.Add(lpvVariantData);
                        return true;
                    },
                    IntPtr.Zero,
                    error
                    );
            }
            return Tags.DMEnumVariables(
                "",
                dmVarFilter,
                (lpdmVarKey, lpvUser) =>
                {
                    varDatas.Add(lpdmVarKey);
                    return true;
                },
                IntPtr.Zero,
                error
                );
        }
        public bool EnumVarData(CMN_ERROR error, [In, Out] List<EnumVarData> varDatas)
        {
            DM_VARKEY[] dmVarKeys = new DM_VARKEY[]
            {
                new DM_VARKEY()
                {
                    dwKeyType = 4,
                    szName = "INT_TEST_VAR",
                    dwID =0,
                    lpvUserData = IntPtr.Zero,
                }
            };
            return Tags.DMEnumVarData4(
                "",
                null,
                0,
                (lpdmVarKey, lpdmVarData, lpvUser) =>
                {
                    varDatas.Add(new EnumVarData() { VarData = lpdmVarData, VarKey = lpdmVarKey });
                    return true;
                },
                IntPtr.Zero,
                error
                );
        }
        public bool CreateNewVaraible(CMN_ERROR error, string varName, DMVarTypes varType, string groupName = "", string connection = "", string specific = "", uint format = 0)
        {
            if(projectInfo.Version >= new Version(705, 0))
            {
                return Tags.GAPICreateNewVariableExStr75(
                    0,
                    new MCP_CREATENEWVARIABLE_DATA_EXSTR_75()
                    {
                        dwFlags = MCP_NVAR_FLAG.CREATE,
                        lpszProjectFile = "",
                        dwProjectFileCharCount = 0,
                        lpszConnection = connection,
                        dwConnectionCharCount = (UInt32)connection.Length,
                        lpszGroupName = groupName,
                        dwGroupNameCharCount = (UInt32)groupName.Length,
                        lpszVarName = varName,
                        dwVarNameCharCount = (UInt32)varName.Length,
                        Common = new MCP_VARIABLE_COMMON()
                        {
                            dwVarType = (DM_VARTYPES)varType,
                            dwVarLength = 0,
                            dwVarProperty = string.IsNullOrEmpty(specific) ? DM_VAR_PROPERTY.INTERNAL : DM_VAR_PROPERTY.EXTERNAL,
                            dwFormat = format,
                        },
                        Protocol = new MCP_VARIABLE_PROTOCOL(),
                        Limits = new MCP_VARIABLE_LIMITS5(),
                        lpszSpecific = specific,
                        dwSpecificCharCount = (UInt32)specific.Length,
                        Scaling = new MCP_VARIABLE_SCALES(),
                        dwVarProperty =0,
                        dwVarWeighting = 0,
                        lpszPLCVariableName = "",
                        dwPLCVariableNameCharCount = 0,
                        lpszPLCBlockName = "",
                        dwPLCBlockNameCharCount =0,
                        lpszComment = "",
                        dwCommentCharCount = 0,
                        dwVarFlags2 = 0,
                    },
                    error
                    );
            }
            else if(projectInfo.Version >= new Version(702, 0))
            {
                return Tags.GAPICreateNewVariableExStr(
                    0,
                    new MCP_CREATENEWVARIABLE_DATA_EXSTR ()
                    {
                        dwFlags = MCP_NVAR_FLAG.CREATE,
                        lpszProjectFile = "",
                        dwProjectFileCharCount = 0,
                        lpszConnection = connection,
                        dwConnectionCharCount = (UInt32)connection.Length,
                        lpszGroupName = groupName,
                        dwGroupNameCharCount = (UInt32)groupName.Length,
                        lpszVarName = varName,
                        dwVarNameCharCount = (UInt32)varName.Length,
                        Common = new MCP_VARIABLE_COMMON()
                        {
                            dwVarType = (DM_VARTYPES)varType,
                            dwVarLength = 0,
                            dwVarProperty = string.IsNullOrEmpty(specific) ? DM_VAR_PROPERTY.INTERNAL : DM_VAR_PROPERTY.EXTERNAL,
                            dwFormat = format,
                        },
                        Protocol = new MCP_VARIABLE_PROTOCOL(),
                        Limits = new MCP_VARIABLE_LIMITS5(),
                        lpszSpecific = specific,
                        dwSpecificCharCount = (UInt32)specific.Length,
                        Scaling = new MCP_VARIABLE_SCALES(),                        
                    },
                    error
                    );
            } 
            else
            {
                return Tags.GAPICreateNewVariable5(
                    0,
                    new MCP_NEWVARIABLE_DATA_5()
                    {
                        dwFlags = MCP_NVAR_FLAG.CREATE,
                        szProjectFile = "",
                        szConnection = connection,
                        szGroupName = groupName,
                        szVarName = varName,
                        Common = new MCP_VARIABLE_COMMON()
                        {
                            dwVarType = (DM_VARTYPES)varType,
                            dwVarLength = 0,
                            dwVarProperty = string.IsNullOrEmpty(specific) ? DM_VAR_PROPERTY.INTERNAL : DM_VAR_PROPERTY.EXTERNAL,
                            dwFormat = format,
                        },
                        Protocol = new MCP_VARIABLE_PROTOCOL(),
                        Limits = new MCP_VARIABLE_LIMITS5(),
                        szSpecific = specific,
                        Scaling = new MCP_VARIABLE_SCALES()
                    },
                    error
                    );
            }
        }
        public bool DeleteVariable(CMN_ERROR error, string name)
        {
            return Tags.GAPIDeleteVariable(
                new MCP_DELETEVARIABLE_DATA()
                {
                    dwFlags = MCP_DVAR_FLAG.DELETE,
                    szVarName = name
                },
                error
                );
        }

        #region Drivers
        public bool EnumDrivers(CMN_ERROR error, List<object> drivers) => Drivers.EnumDrivers(error, projectInfo.ProjectFile, drivers);
        public bool EnumAvailableDrivers(CMN_ERROR error, out List<object> drivers)
        {
            drivers = new List<object>();
            if (channels == null)
            {
                error.dwError1 = (uint)(DMError.NO_OPEN_PROJECT);
                error.szErrorText = "Could not find any drive files.";
                return false;
            }
            drivers = new List<object>(channels);
            return true;
        }
        public bool CreateDriver(CMN_ERROR error, string path) => Drivers.CreateDriver(error, projectInfo.ProjectFile, path);
        public bool DeleteDriver(CMN_ERROR error, string name) => Drivers.DeleteDriver(error, projectInfo.ProjectFile, name);
        #endregion

        #region Connections

        public bool EnumConnections(CMN_ERROR error, [In, Out] List<object> connections)
        {
            UInt32 dwConnectionCount = 0;
            if (projectInfo.Version > new Version(702, 000))
                return Connections.DMEnumConnectionDataExStr(
                    "",
                    (DM_CONNECTION_DATA_EXSTR lpdmConData, IntPtr lpvUser) =>
                    {
                        connections.Add(lpdmConData);
                        return true;
                    },
                    IntPtr.Zero,
                    dwConnectionCount,
                    error
                    );

            return Connections.DMEnumConnectionData(
            "",
            new DM_CONNKEY(),
            0,
            (DM_CONNECTION_DATA lpdmConData, IntPtr lpvUser) =>
            {
                connections.Add(lpdmConData);
                return true;
            },
            IntPtr.Zero,
            error
        );
        }
        public bool DeleteConnection(CMN_ERROR error, string connection)
        {
            return Connections.GAPIDeleteConnection(
                new MCP_DELETECONNECTION_DATA()
                {
                    dwFlags = MCPDCon.DELETE,
                    szConnection = connection
                }, error);
        }
        public bool CreateConnection(CMN_ERROR error, string connection, string unitName, string specific, MCPNCon flag = MCPNCon.CREATE)
        {
            if (this.projectInfo.Version > new Version(702, 0))
                return Connections.GAPICreateNewConnectionExStr(
                    new MCP_NEWCONNECTION_DATA_EXSTR()
                    {
                        dwFlags = flag,
                        lpszProjectFile = projectInfo.ProjectFile,
                        dwProjectFileCharCount = 0,
                        lpszUnitName = unitName,
                        dwUnitNameCharCount = (UInt32)unitName.Length,
                        lpszConnection = connection,
                        dwConnectionCharCount = (UInt32)connection.Length,
                        lpszCommon = "",
                        dwCommonCharCount = 0,
                        lpszSpecific = specific,
                        dwSpecificCharCount = (UInt32)specific.Length,
                        dwCreatorID = 0
                    }, error
                    );
            return Connections.GAPICreateNewConnection(
                    new MCP_NEWCONNECTION_DATA()
                    {
                        dwFlags = 1,
                        szProjectFile = projectInfo.ProjectFile,
                        szUnitName = @unitName,
                        szConnection = @connection,
                        szCommon = "",
                        szSpecific = @specific,
                    }, error
                    );
        }

        #endregion

        #region Drivers

        public bool EnumGroups(CMN_ERROR error, List<object> groups) => Groups.EnumGroups(error, projectInfo.ProjectFile, groups);
        public bool CreateGroup(CMN_ERROR error, string connetion, string groupName) => Groups.CreateGroup(error, projectInfo.ProjectFile, connetion, groupName);
        public bool RenameGroup(CMN_ERROR error, string oldName, string newName) => Groups.RenameGroup(error, $"{projectInfo.ProjectDir}{projectInfo.Name}", oldName, newName);
        public bool DeleteGroup(CMN_ERROR error, string groupName) => Groups.DeleteGroup(error, projectInfo.ProjectFile, groupName);

        #endregion

        #region Structure tag
        public bool EnumTypes(CMN_ERROR error, List<object> objects) => StructuredTags.GAPIEnumTypes(
            projectInfo.ProjectFile,
            (string lpszTypeName, uint dwTypeID, uint dwCreatorID, IntPtr lpvUser) =>
            {
                objects.Add(new
                {
                    Id = dwTypeID,
                    Name = lpszTypeName
                });
                return true;
            }, IntPtr.Zero, error);
        public bool EnumTypeMembers(CMN_ERROR error, string typeName, List<object> objects, bool showScales = true)
        {
            if(projectInfo.Version > new Version(700, 2000))
                return StructuredTags.GAPIEnumTypeMembersExStr(
                    projectInfo.ProjectFile, typeName,
                    (string lpszStructMemberName, UInt32 dwStructMemberUserTypeID, MCP_NEWVARIABLE_DATA_EXSTR lpdmVarDataEx, IntPtr lpvUser) =>
                    {
                        objects.Add(new
                        {
                            Name = lpszStructMemberName,
                            Type = dwStructMemberUserTypeID,
                            Data = lpdmVarDataEx,
                        });
                        return true;
                    }, IntPtr.Zero, error);
            if (projectInfo.Version > new Version(500, 2000) && showScales)
                return StructuredTags.GAPIEnumTypeMembersEx4(
                    projectInfo.ProjectFile, typeName,
                    (DM_VARKEY lpdmVarKey, MCP_NEWVARIABLE_DATA_EX4 lpdmVarDataEx, IntPtr lpvUser) =>
                    {
                        objects.Add(new
                        {
                            Var = lpdmVarKey,
                            Data = lpdmVarDataEx,
                        });
                        return true;
                    }, IntPtr.Zero, error);
            else if (projectInfo.Version > new Version(500,2000))
            return StructuredTags.GAPIEnumTypeMembersEx(
                projectInfo.ProjectFile, typeName,
                (DM_VARKEY lpdmVarKey, MCP_NEWVARIABLE_DATA_EX lpdmVarDataEx, IntPtr lpvUser) =>
                {
                    objects.Add(new
                    {
                        Var = lpdmVarKey,
                        Data = lpdmVarDataEx,
                    });
                    return true;
                }, IntPtr.Zero, error);
            return StructuredTags.GAPIEnumTypeMembers(
            projectInfo.ProjectFile, typeName,
            (string lpszMemberName, IntPtr lpvUser) =>
            {
                objects.Add(new
                {
                    Name = lpszMemberName
                });
                return true;
            }, IntPtr.Zero, error);
        }
        public bool DeleteType(CMN_ERROR error, string typeName) => StructuredTags.GAPIDeleteType(
            projectInfo.ProjectFile, 1, 0, typeName, error);
        public bool CreateType(CMN_ERROR error, string typeName)
        {
            var dmType = Helper.Create<DM_TYPE_DESCRIPTOR_EXSTR>();
            var dmMembers = Helper.CreateArray<MCP_NEWVARIABLE_DATA_EXSTR>(4);
            var chnConversion = Helper.Create<MCP_CHNCONVERSION_EXSTR>();
            UInt32 dwFlags = 1;
            UInt32 dwCreID = 0;
            dmType.dmTypeRef.dwType = DMVarTypes.STRUCT;
            dmType.dmTypeRef.dwSize = 16;
            dmType.dmType.dmStruct.dwNumMembers = 4;
            for (int i = 0; i < 4; i++)
            {
                dmMembers[i].Common.dwVarType = DM_VARTYPES.FLOAT;
                dmMembers[i].Common.dwVarLength = 4;
                dmMembers[i].Common.dwASOffset = (uint)i * 4;
                dmMembers[i].Common.dwFormat = 7;
            }
            var lpdmMembers = Helper.ArrayToPointer(dmMembers);
            bool ret = StructuredTags.GAPICreateTypeExStr(projectInfo.ProjectFile,
                dmType, 1,0 , lpdmMembers, chnConversion,error);
            Marshal.FreeHGlobal(lpdmMembers);
            return ret;
        }
        public bool CreateTypeInstance(CMN_ERROR error, string structureName, string varName, string connection = "", string groupName = "", string specific = "")
        {
            if (projectInfo.Version > new Version(700, 2000))
                return StructuredTags.GAPICreateTypInstanceExStr(
                    projectInfo.ProjectFile,
                    new MCP_NEWVARIABLE_DATA_EXSTR()
                    {
                        dwFlags = MCP_NVAR_FLAG.CREATE,
                        lpszProjectFile = projectInfo.ProjectFile,
                        dwProjectFileCharCount = (uint)projectInfo.ProjectFile.Length,
                        lpszConnection = connection,
                        dwConnectionCharCount = (uint)connection.Length,
                        lpszVarName = varName,
                        dwVarNameCharCount = (uint)varName.Length,
                        lpszGroupName = groupName,
                        dwGroupNameCharCount = (uint)groupName.Length,
                        lpszSpecific = specific,
                        dwSpecificCharCount = (uint)specific.Length,
                        Common = new MCP_VARIABLE_COMMON_EXSTR()
                        {
                            dwVarType = DM_VARTYPES.STRUCT,
                            dwVarLength = 0,
                            dwVarProperty = string.IsNullOrEmpty(connection) ? DM_VAR_PROPERTY.INTERNAL : DM_VAR_PROPERTY.EXTERNAL,
                            dwFormat = 0,
                            dwOSOffset = 0,
                            dwASOffset = 0,
                            szStructTypeName = structureName,
                            dwStructTypeNameCharCount = (uint)structureName.Length,
                            dwCreatorID = 0,                            
                        },
                        Protocol = new MCP_VARIABLE_PROTOCOL_EX()
                        {
                            dwProtocolFlags = MCP_VARPROT.NOSCALE
                        },
                        Scaling = new MCP_VARIABLE_SCALES()
                        {
                            dwVarScaleFlags = DM_VARSCALE.NOSCALE,
                        }
                    }, 1, 1,
                    new MCP_NEWVARIABLE_DATA_EXSTR()
                    {
                        Common = new MCP_VARIABLE_COMMON_EXSTR(),
                        Protocol = new MCP_VARIABLE_PROTOCOL_EX(),
                        Limits = new MCP_VARIABLE_LIMITS_EXSTR()
                    }, 0, error); ;
            if (projectInfo.Version > new Version(500,2000))
                return StructuredTags.GAPICreateTypInstance4(
                    projectInfo.ProjectFile,
                    new MCP_NEWVARIABLE_DATA_EX4()
                    {
                        dwFlags = MCP_NVAR_FLAG.CREATE,
                        szProjectFile = projectInfo.ProjectFile,
                        szConnection = connection,
                        szVarName = varName,
                        szGroupName = groupName,
                        szSpecific = specific,
                        Common = new MCP_VARIABLE_COMMON_EX()
                        {
                            dwVarType = DM_VARTYPES.STRUCT,
                            dwVarLength = 0,
                            dwVarProperty = string.IsNullOrEmpty(connection) ? DM_VAR_PROPERTY.INTERNAL : DM_VAR_PROPERTY.EXTERNAL,
                            dwFormat = 0,
                            dwOSOffset = 0,
                            dwASOffset = 0,
                            szStructTypeName = structureName
                        },
                        Protocol = new MCP_VARIABLE_PROTOCOL_EX()
                        {
                            dwProtocolFlags = MCP_VARPROT.NOSCALE
                        }
                    }, 1, 1,
                    new MCP_NEWVARIABLE_DATA_EX4()
                    {
                        Common = new MCP_VARIABLE_COMMON_EX(),
                        Protocol = new MCP_VARIABLE_PROTOCOL_EX(),
                        Limits = new MCP_VARIABLE_LIMITS_EX()
                    }, error);
            return StructuredTags.GAPICreateTypInstance(
                projectInfo.ProjectFile,
                new MCP_NEWVARIABLE_DATA_EX()
                { 
                    dwFlags = MCP_NVAR_FLAG.CREATE,
                    szProjectFile = projectInfo.ProjectFile,
                    szConnection = connection,
                    szVarName = varName,
                    szGroupName = groupName,
                    szSpecific = specific,
                    Common = new MCP_VARIABLE_COMMON_EX()
                    {
                        dwVarType = DM_VARTYPES.STRUCT,
                        dwVarLength = 0,
                        dwVarProperty = string.IsNullOrEmpty(connection) ? DM_VAR_PROPERTY.INTERNAL : DM_VAR_PROPERTY.EXTERNAL,
                        dwFormat = 0,
                        dwOSOffset = 0,
                        dwASOffset = 0,
                        szStructTypeName = structureName
                    },
                    Protocol = new MCP_VARIABLE_PROTOCOL_EX()
                    {
                        dwProtocolFlags = MCP_VARPROT.NOSCALE
                    }
                },1,1,
                new MCP_NEWVARIABLE_DATA_EX()
                {
                    Common = new MCP_VARIABLE_COMMON_EX(),
                    Protocol = new MCP_VARIABLE_PROTOCOL_EX(),
                    Limits = new MCP_VARIABLE_LIMITS_EX()
                }, error);

        }

        #endregion

        #endregion&

        #region RT
        public bool GetRuntimeProject(CMN_ERROR error, StringBuilder projectFile) => Runtime.DMGetRuntimeProject(projectFile, (UInt32)projectFile.Capacity, error);
        public bool ActivateRT(CMN_ERROR error) => GeneralFunctions.DMActivateRTProject(error);
        public bool DeactivateRT(CMN_ERROR error, DMDeactivate deactivate = DMDeactivate.Normal) => GeneralFunctions.DMDeactivateRTProjectEx(deactivate, error);
        public bool GetValue(CMN_ERROR error, string tag, List<object> updateData)
        {
            DM_VARKEY lpdmVarKey = new DM_VARKEY()
            {
                dwID = 0,
                dwKeyType = 2,
                lpvUserData = IntPtr.Zero,
                szName = tag
            };
            DM_VAR_UPDATE_STRUCT lpdmvus = new DM_VAR_UPDATE_STRUCT()
            {
                dmTypeRef = new DM_TYPEREF(),
                dmVarKey = new DM_VARKEY(),
                dmValue = null,
                dwState = DMVarState.NONE
            };
            if (Runtime.DMGetValue(lpdmVarKey, 1, lpdmvus, error))
            {
                updateData.Add(lpdmvus);
                return true;
            }
            return false;
        }
        public bool GetValue(CMN_ERROR error, string[] tags, List<object> updateData)
        {
            bool ret = false;
            IntPtr lpdmVarKey = IntPtr.Zero;
            IntPtr lpdmvus = IntPtr.Zero;
            if (projectInfo.Version > new Version(700, 2000))
            {
                //lpdmVarKey = Helper.ArrayToPointer(tags);
                var dmvus = Helper.CreateArray<DM_VAR_UPDATE_STRUCT_EXSTR>(tags.Length);
                lpdmvus = Helper.ArrayToPointer(dmvus);
                VariantArray variant = new VariantArray()
                {
                    parray = tags.Cast<object>().ToArray(),
                };
                if (ret = Runtime.DMGetValueExStr(0, variant, lpdmvus, (uint)tags.Length, error))
                {
                    Helper.PointerToArray<DM_VAR_UPDATE_STRUCT_EXSTR>(lpdmvus, dmvus.Length).ToList()
                                                .ForEach(z => updateData.Add(z));
                }
            }
            else
            {
                var dmVarKey = Helper.CreateArray<DM_VARKEY>(tags.Length);
                for (int i = 0; i < tags.Length; i++)
                {
                    dmVarKey[i].szName = tags[i];
                    dmVarKey[i].dwKeyType = 2;
                }
                lpdmVarKey = Helper.ArrayToPointer(dmVarKey);
                if (projectInfo.Version > new Version(600, 4000))
                {
                    var dmvus = Helper.CreateArray<DM_VAR_UPDATE_STRUCTEX>(tags.Length);
                    lpdmvus = Helper.ArrayToPointer(dmvus);                    
                    if (ret = Runtime.DMGetValueEx(lpdmVarKey, (uint)tags.Length, lpdmvus, error))
                    {
                        Helper.PointerToArray<DM_VAR_UPDATE_STRUCTEX>(lpdmvus, dmvus.Length).ToList()
                            .ForEach(z => updateData.Add(z));
                    }
                }
                else
                {
                    var dmvus = Helper.CreateArray<DM_VAR_UPDATE_STRUCT>(tags.Length);
                    lpdmvus = Helper.ArrayToPointer(dmvus);
                    if (ret = Runtime.DMGetValue(lpdmVarKey, (uint)tags.Length, lpdmvus, error))
                    {
                        Helper.PointerToArray<DM_VAR_UPDATE_STRUCT>(lpdmvus, dmvus.Length).ToList()
                            .ForEach(z => updateData.Add(z));                        
                    }
                }                
            }
            Marshal.FreeHGlobal(lpdmvus);
            Marshal.FreeHGlobal(lpdmVarKey);
            return ret;
        }
        public bool GetValueWait(CMN_ERROR error, string[] tags, List<object> updateData, bool waitForCompletition = true, UInt32 timeOut = 5000)
        {
            bool ret = false;
            UInt32 tagId = (uint)new Random().Next();
            if (projectInfo.Version > new Version(700, 2000))
            {
                VariantArray vdmVarKey = new VariantArray()
                {
                    parray = tags.Cast<object>().ToArray(),
                };
                VariantArray vCookie = new VariantArray()
                {
                    parray = new object[tags.Length],
                };
                return Runtime.DMGetValueWaitExStr(
                    ref tagId, 0,
                    vdmVarKey, vCookie,
                    waitForCompletition, timeOut,
                    (UInt32 dwTAID, IntPtr lpdmvus, UInt32 dwItems, IntPtr lpvUser) =>
                    {
                        updateData.Add(Helper.PointerToArray<DM_VAR_UPDATE_STRUCT_EXSTR>(lpdmvus, (int)dwItems));
                        return true;
                    },
                    IntPtr.Zero,
                    error
                    );
            } 
            else
            {
                DM_VARKEY[] dmVarKey = Helper.CreateArray<DM_VARKEY>(tags.Length);
                for (int i = 0; i < tags.Length; i++)
                {
                    dmVarKey[i].szName = tags[i];
                    dmVarKey[i].dwKeyType = 2;
                }
                var lpdmVarKey = Helper.ArrayToPointer(dmVarKey);
                if (projectInfo.Version > new Version(600, 4000))
                {
                    ret = Runtime.DMGetValueWaitEx(
                        ref tagId,
                        lpdmVarKey,
                        (UInt32)tags.Length,
                        waitForCompletition,
                        timeOut,
                        (UInt32 dwTAID, IntPtr lpdmvus, UInt32 dwItems, IntPtr lpvUser) =>
                        {
                            updateData.Add(Helper.PointerToArray<DM_VAR_UPDATE_STRUCTEX>(lpdmvus, (int)dwItems));
                            return true;
                        },
                        IntPtr.Zero,
                        error
                        );
                }
                else
                {
                    ret = Runtime.DMGetValueWait(
                        ref tagId,
                        lpdmVarKey,
                        (UInt32)tags.Length,
                        waitForCompletition,
                        timeOut,
                        (UInt32 dwTAID, IntPtr lpdmvus, UInt32 dwItems, IntPtr lpvUser) =>
                        {
                            updateData.Add(Helper.PointerToArray<DM_VAR_UPDATE_STRUCT>(lpdmvus, (int)dwItems));
                            return true;
                        },
                        IntPtr.Zero,
                        error
                        );
                }
                Marshal.FreeHGlobal(lpdmVarKey);
            }
            return ret;
        }
        public bool GetVarLimits(CMN_ERROR error, string[] tags, List<object> limits)
        {
            bool ret = false;
            DM_VARLIMIT[] dmVarLimit = Helper.CreateArray<DM_VARLIMIT>(tags.Length);
            var lpdmVarLimit = Helper.ArrayToPointer(dmVarLimit);
            if (projectInfo.Version > new Version(700, 2000))
            {
                VariantArray vdmVarKey = new VariantArray()
                {
                    parray = tags.Cast<object>().ToArray(),
                };
                ret = Runtime.DMGetVarLimitsExStr(projectInfo.ProjectFile,
                    vdmVarKey, lpdmVarLimit, error
                    );
            }
            else
            {
                DM_VARKEY[] dmVarKey = Helper.CreateArray<DM_VARKEY>(tags.Length);
                for (int i = 0; i < tags.Length; i++)
                {
                    dmVarKey[i].szName = tags[i];
                    dmVarKey[i].dwKeyType = 2;
                }
                var lpdmVarKey = Helper.ArrayToPointer(dmVarKey);
                ret = Runtime.DMGetVarLimits(projectInfo.ProjectFile,
                    lpdmVarKey, (uint)tags.Length,
                    lpdmVarLimit, error
                    );
                Marshal.FreeHGlobal(lpdmVarKey);
            }          
            dmVarLimit.ToList().ForEach(z => limits.Add(z));
            Marshal.FreeHGlobal(lpdmVarLimit);
            return ret;
        }
        public bool GetVarType(CMN_ERROR error, string[] tags, List<object> types)
        {
            bool ret = false;
            if (projectInfo.Version > new Version(700, 2000))
            {
                VariantArray vdmVarKey = new VariantArray()
                {
                    parray = tags.Cast<object>().ToArray()
                };
                var dmTypeRef = Helper.CreateArray<DM_TYPEREF_EXSTR>(tags.Length);
                var lpdmTypeRef = Helper.ArrayToPointer(dmTypeRef);
                ret = Runtime.DMGetVarTypeExStr(projectInfo.ProjectFile,
                    vdmVarKey,
                    lpdmTypeRef, error
                    );
                dmTypeRef = Helper.PointerToArray<DM_TYPEREF_EXSTR>(lpdmTypeRef, tags.Length);
                dmTypeRef.ToList().ForEach(z => types.Add(z));
                Marshal.FreeHGlobal(lpdmTypeRef);
            } 
            else
            {
                var dmTypeRef = Helper.CreateArray<DM_TYPEREF>(tags.Length);
                var lpdmTypeRef = Helper.ArrayToPointer(dmTypeRef);
                var dmVarKey = Helper.Convert<DM_VARKEY>(tags);
                var lpdmVarKey = Helper.ArrayToPointer(dmVarKey);
                ret = Runtime.DMGetVarType(projectInfo.ProjectFile,
                    lpdmVarKey, (uint)tags.Length,
                    lpdmTypeRef, error
                    );
                dmTypeRef.ToList().ForEach(z => types.Add(z));
                Marshal.FreeHGlobal(lpdmVarKey);
                Marshal.FreeHGlobal(lpdmTypeRef);
            }
            return ret;
        }
        public bool SetValue(CMN_ERROR error, string[] tags, string[] values, List<object> objects)
        {
            Variant[] varVal = Helper.ToVariantArray(values);
            var lpvarVal = Helper.ArrayToPointer(varVal);
            UInt32[] varState = new uint[values.Length];
            var lpvarState = Helper.ArrayToPointer(varState);
            bool ret = false;
            if (projectInfo.Version > new Version(700, 2000))
            {
                var vdmVarKey = Helper.ToVariantArray(tags);
                var lpvdmVarKey = Helper.ArrayToPointer(vdmVarKey);
                ret = Runtime.DMSetValueExStr(lpvdmVarKey, lpvarVal, lpvarState, error);
                Marshal.FreeHGlobal(lpvdmVarKey);
            }
            else
            {
                var dmVarKey = Helper.Convert<DM_VARKEY>(tags);
                var lpdmVarKey = Helper.ArrayToPointer(dmVarKey);
                ret = Runtime.DMSetValue(lpdmVarKey, (UInt32)values.Length, lpvarVal, lpvarState, error);
                Marshal.FreeHGlobal(lpdmVarKey);
            }

            varVal.ToList().ForEach(v => v.Clear());
            varState = Helper.PointerToArray<UInt32>(lpvarState, values.Length);
            varState.ToList().ForEach(z => objects.Add(z));
            Marshal.FreeHGlobal(lpvarState);
            Marshal.FreeHGlobal(lpvarVal);
            return ret;
        }
        public bool SetValueMessage(CMN_ERROR error, string tag, string value, string message) => Runtime.DMSetValueMessage(Helper.ToDMVarKey(tag), new Variant(value), DMSVM_OPERATION.MESSAGE, message, error);
        public bool SetValueWait(CMN_ERROR error, string[] tags, string[] values, List<object> objects, int timeout = 1000)
        {
            UInt32 tagId = (uint)new Random().Next();
            bool ret = false;
            if (projectInfo.Version > new Version(700, 2000)&&false)
            {
                VariantArray vdmVarKey = new VariantArray()
                {
                    parray = tags.Cast<object>().ToArray(),
                };
                VariantArray vdmValue = new VariantArray()
                {
                    parray = values.Cast<object>().ToArray(),
                };
                var dwState = new UInt32[values.Length];
                ret = Runtime.DMSetValueWaitExStr(ref tagId, vdmVarKey, (UInt32)values.Length, vdmValue,
                    ref dwState, (uint)timeout, (UInt32 dwTagId, IntPtr lpdmvus, UInt32 dwItems, IntPtr lpvUserr) =>
                    {
                        Helper.PointerToArray<UInt32>(lpdmvus, (int)dwItems).ToList().ForEach(z => objects.Add(z));
                        return true;
                    }, IntPtr.Zero, error);
            }
            else
            {
                var dmVarKey = Helper.Convert<DM_VARKEY>(tags);
                var lpdmVarKey = Helper.ArrayToPointer(dmVarKey);
                ret = Runtime.DMSetValueWait(ref tagId, lpdmVarKey, (UInt32)values.Length, lpdmVarKey, (uint)timeout
                    , (UInt32 dwTagId,IntPtr lpdmvus, UInt32 dwItems, IntPtr lpvUserr) =>
                    {
                        Helper.PointerToArray<UInt32>(lpdmvus, (int)dwItems).ToList().ForEach(z => objects.Add(z));
                        return true;
                    }, IntPtr.Zero, error);
                Marshal.FreeHGlobal(lpdmVarKey);
            }
            return ret;
        }
        public bool BeginStartVarUpdate(CMN_ERROR error, ref object transactionID)
        {
            if(Runtime.DMBeginStartVarUpdate(ref dwTAID, error))
            {
                transactionID = new {
                    transactionID = dwTAID
                };
                return true;
            } 
            else
            {
                dwTAID = 0;
                return false;
            }
        }
        public bool EndStartVarUpdate(CMN_ERROR error,uint? transactionID = null) => Runtime.DMEndStartVarUpdate(transactionID??dwTAID, error);
        public bool StartVarUpdate(CMN_ERROR error, string[] tags, ref object transactionID)
        {
            bool ret = false;
            if (!Runtime.DMBeginStartVarUpdate(ref dwTAID, error))
            {
                dwTAID = 0;
                return false;
            }
            var dmVarKey = Helper.ToDMVarKeys(tags);
            var lpdmVarKey = Helper.ArrayToPointer(dmVarKey);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            ret = Runtime.DMStartVarUpdate(dwTAID, lpdmVarKey, (UInt32)dmVarKey.Length, 4, DMNotifyVariableIntern, IntPtr.Zero, error);
            Marshal.FreeHGlobal(lpdmVarKey);
            if (!ret) return false;
            if(!Runtime.DMEndStartVarUpdate(dwTAID, error))
            {
                dwTAID = 0;
                return false;
            }
            transactionID = new
            {
                transactionID = dwTAID
            };
            return true;
        }
        protected virtual void OnDataManagerNotifyVariable(DataManagerNotifyVariableEventArgs e)
        {
            DataManagerNotifyVariable?.Invoke(null, e);
        }

        internal bool DMNotifyVariableIntern(UInt32 dwTAID,IntPtr lpdmvus,UInt32 dwItems,IntPtr lpvUser)
        {
            object[] values = Helper.PointerToArray<DM_VAR_UPDATE_STRUCT>(lpdmvus, (int)dwItems);
            OnDataManagerNotifyVariable(new DataManagerNotifyVariableEventArgs(dwTAID, values));
            return true;
        }
        public bool StopVarUpdate(CMN_ERROR error, uint? transactionID = null)
        {
            return Runtime.DMStopVarUpdate(transactionID ?? dwTAID, error);
        }
        public bool StopAllUpdates(CMN_ERROR error) => Runtime.DMStopAllUpdates(error);
        #endregion
    }
}
