using General;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Scripts
{
    public class ApplicationManger
    {
        bool connected = false;
        string appName;
        UInt32 dwOrderId = 0;
        ProjectInfo projectInfo => Share.ProjectInfo;

        public event ApplicationNotifyEventHandler ApplicationNotify;
        public ApplicationManger(string appName)
        {
            this.appName = appName;
            CMN_ERROR error = new CMN_ERROR();
        }
        ~ApplicationManger()
        {
            CMN_ERROR error = new CMN_ERROR();
            if (connected) Disconnect(error);
        }
        void FreeAll(IntPtr[] pointers) => pointers.ToList().ForEach(z => Marshal.FreeHGlobal(z));
        protected virtual void OnApplicationNotify(ApplicationNotifyEventArgs e)
        {
            ApplicationNotify?.Invoke(null, e);
        }
        bool ApplicationNotifyProcIntern(UInt32 dwAPNotify, uint dwAPNotifyCode, uint dwError, IntPtr lpbyData, uint dwItems, uint dwOrderId, IntPtr lpvUser)
        {
            OnApplicationNotify(new ApplicationNotifyEventArgs(dwAPNotify, dwAPNotifyCode, dwError, lpbyData, dwItems, dwOrderId, lpvUser));
            return true;
        }
        IntPtr AllocateAppMem(int cb)
        {
            return Marshal.AllocHGlobal(cb);
        }
        public bool Connect(CMN_ERROR error) => connected = GlobalScirpts.APConnect(appName, ApplicationNotifyProcIntern, ref dwOrderId, IntPtr.Zero, error);
        public bool Disconnect(CMN_ERROR error) => GlobalScirpts.APDisconnect(ApplicationNotifyProcIntern, ref dwOrderId, IntPtr.Zero, error);
        public bool GetFunctions(CMN_ERROR error, List<object> functions)
        {
            if (!Directory.Exists(projectInfo.ProjectLibDir))
            {
                error.dwError1 = 0x00000014;
                error.szErrorText = "Directory not found.";
                return false;
            }
            functions.AddRange(Directory.GetFiles(projectInfo.ProjectLibDir, "*.FCT", SearchOption.AllDirectories));
            return true;
        }
        public bool GenGetSourceCode(CMN_ERROR error, string file, out string source)
        {
            source = "";
            var genGAS = new GET_ACTION_STREAM()
            {
                dwType = GSC_AP.PFCT,
                pszPathName = file
            };
            var pActionStream = GlobalScirpts.GSCGenGetActionStream(genGAS, AllocateAppMem, error);
            if (pActionStream == IntPtr.Zero)
            {
                error.szErrorText = $"Could not the file";
                return false;
            }
            source = GlobalScirpts.GSCGenGetSourceCode(pActionStream, AllocateAppMem, error);
            Marshal.FreeHGlobal(pActionStream);
            return true;
        }
        bool DirectoryExists(CMN_ERROR error, string fileName, string subDirectory, out string projectDir, bool create = true)
        {
            projectDir = $"{projectInfo.ProjectDir}{subDirectory}";
            if (!Directory.Exists(projectDir))
            {
                var dir = Directory.GetParent(projectDir).ToString();
                if (!Directory.Exists(dir))
                {
                    error.szErrorText = $"{dir} does not exist";
                    return false;
                }
                else
                {
                    if (create)
                    {
                        Directory.CreateDirectory(projectDir);
                    }
                    else
                    {
                        error.szErrorText = $"{projectDir} does not exist";
                        return false;
                    }
                }
            }
            return true;
        }
        public bool GenCreateAction(CMN_ERROR error, string sourceCode, string fileName, string subDirectory = "")
        {
            if (!DirectoryExists(error, fileName, subDirectory, out string projectDir)) return false;
            var source = GlobalScirpts.GSCGenInsertSourceCode(
                new INSERT_SOURCE_CODE()
                {
                    pAction = IntPtr.Zero,
                    pszSourceCode = sourceCode
                }, AllocateAppMem, error);
            if (source == IntPtr.Zero) return false;
            bool ret = GlobalScirpts.GSCGenCreateAction(new INSERT_ACTION()
            {
                pAction = source,
                pszProjectDir = projectDir,
                pszFileName = fileName,
                dwUserLevel = 0,
                pszUserLevel = ""
            }, error);
            Marshal.FreeHGlobal((IntPtr)source);
            return ret;
        }
        bool GetGSC_AP(string file, out GSC_AP type)
        {
            file = file.ToUpper();
            type = GSC_AP.UNKNOWN;
            if (!Path.HasExtension(file)) return false;
            if (Path.GetExtension(file) != ".FCT" && Path.GetExtension(file) != ".PAS") return false;
            else if (Path.GetExtension(file) == ".PAS")
            {
                type = GSC_AP.GSC;
                return true;
            };
            if (Path.GetExtension(file) == ".FCT") type = GSC_AP.PFCT;
            return true;
        }
        bool GetActionStream(CMN_ERROR error, out IntPtr stream, string fileName, string subDirectory = "")
        {
            stream = IntPtr.Zero;
            if (!DirectoryExists(error, fileName, subDirectory, out string projectDir)) return false;
            GetGSC_AP(fileName, out GSC_AP type);
            stream = GlobalScirpts.GSCGenGetActionStream(new GET_ACTION_STREAM()
            {
                pszPathName = fileName,
                dwType = type,
            }, AllocateAppMem, error);
            if (stream == IntPtr.Zero)
            {
                error.szErrorText = $"Could not the file";
                return false;
            }
            return true;
        }
        public bool GenAddTrigger(CMN_ERROR error, string fileName, string subDirectory = "")
        {
            if (!DirectoryExists(error, fileName, subDirectory, out string projectDir)) return false;
            GetGSC_AP(fileName, out GSC_AP type);
            var lpAction = GlobalScirpts.GSCGenGetActionStream(new GET_ACTION_STREAM()
            {
                pszPathName = $"{projectDir}{fileName}",
                dwType = type,
            }, AllocateAppMem, error);
            return false;
        }
        public bool GetAllocTrigger(CMN_ERROR error, List<object> list, string fileName, string subDirectory = "")
        {
            if (!GetActionStream(error, out IntPtr stream, fileName, subDirectory)) return false;
            uint readTrigger = 0;
            IntPtr pTrigger = IntPtr.Zero;
            var ret = GlobalScirpts.AP_GEN_GetAllocTrigger(stream, 0, ref readTrigger, ref pTrigger, error);
            Marshal.FreeHGlobal(stream);
            if (!ret) return false;
            var triggers = Helper.PointerToTrigger(pTrigger, (int)readTrigger);
            ret = GlobalScirpts.AP_GEN_FreeTrigger(readTrigger, ref pTrigger, error);
            if (!ret) return false;
            list.Add(triggers);
            return true;
        }
        public bool CreateAction(CMN_ERROR error, CAction action, string computerName = "")
        {
            bool ret = false;
            if (ret = InsertSource(error, action, out IntPtr source, out string directory, computerName))
            {
                if (ret = Compile(error, directory, source, out IntPtr compile, out uint errors, out uint warnings))
                {
                    if (ret = AddTriggers(error, action, compile, out TRIGGERS triggers, out IntPtr lptrigger, out IntPtr newstream, out UInt32 newstreamsize))
                    {
                        ret = GlobalScirpts.GSCGenCreateAction(new INSERT_ACTION()
                        {
                            pAction = newstream,
                            pszProjectDir = directory,
                            pszFileName = $"{action.Name}.pas",
                            dwUserLevel = 0,
                            pszUserLevel = ""
                        }, error);
                        if (!ret) error.szErrorText = "The file could not be created";
                    }
                    triggers.Free();
                    FreeAll(new IntPtr[] { lptrigger, newstream });
                }
                Marshal.FreeHGlobal((IntPtr)compile);
            }            
            Marshal.FreeHGlobal((IntPtr)source);
            return ret;
        }
        bool InsertSource(CMN_ERROR error, CAction action, out IntPtr source, out string directory, string computerName = "")
        {
            if (!string.IsNullOrEmpty(computerName)) computerName = $"{computerName}\\";
            directory = $"{projectInfo.ProjectDir}{computerName}PAS\\{action.Path}";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            source = GlobalScirpts.GSCGenInsertSourceCode(
            new INSERT_SOURCE_CODE()
            {
                pAction = IntPtr.Zero,
                pszSourceCode = action.Source,
            }, AllocateAppMem, error);
            if (source == IntPtr.Zero)
            {
                error.szErrorText = "The required memory space could not be created.";
                return false;
            }
            return true;
        }
        bool AddTriggers(CMN_ERROR error, CAction action, IntPtr source, out TRIGGERS triggers, out IntPtr lptrigger, out IntPtr newstream, out UInt32 newstreamsize)
        {
            newstream = IntPtr.Zero;
            newstreamsize = 0;
            triggers = new TRIGGERS(action.Triggers);
            lptrigger = PointerHelper.ArrayToPointer(triggers.ToArray());
            if (!GlobalScirpts.AP_GEN_AddTrigger(source, ref newstream, ref newstreamsize, (uint)triggers.Count(), lptrigger, error))
            {
                error.szErrorText = "There was a problem trying to add triggers.";
                return false;
            }
            return true;
        }
        bool Compile(CMN_ERROR error, string projectName, IntPtr source, out IntPtr compile, out uint errors, out uint warnings)
        {
            errors = warnings = 0;
            compile = GlobalScirpts.GSCGenCompile(new GENERATE_COMPILE()
            {
                pszProjectName = projectName,
                pAction = source
            }, IntPtr.Zero, ref errors, ref warnings, AllocateAppMem, error );
            if(compile == IntPtr.Zero)
            {
                error.szErrorText = $"The source could not be compiled.";
                return false;
            }
            return true;
        }
        bool Compile(CMN_ERROR error, CAction action, IntPtr source, out IntPtr compiled)
        {
            UInt32 plErrors = 0, plWarnings =0;
            compiled = GlobalScirpts.GSCGenCompile(
                new GENERATE_COMPILE()
                {
                    pAction = source,
                    pszProjectName = "BatchExplorer"
                }, IntPtr.Zero, ref plErrors, ref plWarnings, AllocateAppMem, error);
            if(compiled == IntPtr.Zero)
            {
                error.szErrorText = "The required memory space could not be created.";
                return false;
            }
            return true;
        }
        public bool CreateNewFunction(CMN_ERROR error, string pathName, string fileName, string sourceCode, bool global = false)
        {
            bool ret =  Functions.GSCGenCreateNewFunction(new GENERATE_FUNCTION()
            {
                dwType = (uint)(global ? 4 : 2),
                pszProjectName = projectInfo.Name,
                pszGlobalLibDir = projectInfo.GlobalLibDir,
                pszProjectLibDir = projectInfo.ProjectLibDir,
                pszPathName = pathName,
                pszFileName = fileName,
                pszSourceCode = sourceCode,

            }, IntPtr.Zero, error);
            return ret;
        }
    }
}
