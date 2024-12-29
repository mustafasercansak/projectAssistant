using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlCenter;
using System.ServiceProcess;
using System.Runtime.Remoting.Contexts;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using General;
using System.Data.SqlTypes;

namespace Project_Assistant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataManagerController : CCController
    {
        [HttpGet("GetRuntimeProject")]
        public ActionResult GetRuntimeProject()
        {
            var sb = new StringBuilder(255);
            if (!datamanager.GetRuntimeProject(error, sb))
                return BadRequest(error);
            return Ok(sb.ToString());
        }
        [HttpGet("Test")]
        public ActionResult Test()
        {
            Object a = 1;
            object b = (UInt64)2;
            string str = $"Object {Marshal.SizeOf(a)}";
            str += $"object {Marshal.SizeOf(b)}";
            double c = 2;
            str += $"object {Marshal.SizeOf(c)}";

            return Ok(str);
        }

        [HttpGet("ConnectionState")]
        public ActionResult ConnectionState() => Exec(() => datamanager.ConnectionState(error), true);

        [HttpGet("Connect")]
        public ActionResult Connect() => Exec(() => datamanager.Connect(error), true);

        [HttpGet("Disconnect")]
        public ActionResult Disconnect() => Exec(() => datamanager.Disconnect(error), true);

        [HttpGet("ProjectInfo")]
        public ActionResult ProjectInfo()
        {
            ProjectInfo projectInfo = new ProjectInfo();
            CMN_ERROR error = new CMN_ERROR();
            if (datamanager.ProjectInfo(error, projectInfo))
            {
                return Ok(projectInfo);
            }
            return BadRequest(error);
        }

        [HttpGet("OpenProjectFolder")]
        public  ActionResult OpenProjectFolder() => Exec(() => datamanager.OpenProjectFolder(error), true);

        [HttpGet("ResetWinCC")]
        public ActionResult ResetWinCC() => Exec(() => datamanager.ResetWinCC(), true);

        [HttpGet("WinCCExit")]
        public ActionResult WinCCExit() => Ok(datamanager.ExitWinCC());

        [HttpGet("CreateProject")]
        public ActionResult CreateProject(string projectDirectory, string projectName) => Exec((error) => datamanager.CreateNewProject(error, projectDirectory, projectName));

        [HttpGet("DeactivateRT")]
        public ActionResult DeactivateRT() => Exec(() => datamanager.DeactivateRT(error), true);
        [HttpGet("ActivateRT")]
        public ActionResult ActivateRT() => Exec(() => datamanager.ActivateRT(error), true);

        [HttpPost("OpenProject")]
        public ActionResult OpenProject(string projectFile) => Exec(() => datamanager.OpenProject(error, projectFile), true);

        [HttpPost("EnumVariables")]
        public ActionResult EnumVariables(string group = "", string name = "", string connection = "")
        {
            CMN_ERROR error = new CMN_ERROR();
            List<object> varNames = new List<object>();
            if (!datamanager.EnumVariables(error, varNames, group, name, connection))
            {
                return BadRequest(error);
            }
            return Ok(varNames);
        }

        [HttpPost("EnumVarData")]
        public ActionResult EnumVarData()
        {
            CMN_ERROR error = new CMN_ERROR();
            List<EnumVarData> data = new List<EnumVarData>();
            if (!datamanager.EnumVarData(error, data))
            {
                return BadRequest(error);
            }
            return Ok(data);
        }

        [HttpGet("SQLServiceStatus")]
        public ActionResult SQLServiceStatus() => Ok(datamanager.Service.Status.ToString());

        [HttpGet("StartSQLService")]
        public ActionResult StartSQLService()
        {
            try
            {
                ServiceController service = datamanager.Service;
                if (service.Status != ServiceControllerStatus.Running)
                {
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running);
                }
                return Ok(service.Status.ToString());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost("ModifyStartup")]
        public ActionResult ModifyStartup(ControlCenter.Startup startup) => Exec((error) => datamanager.ModifyStartList(error, startup));

        [HttpPost("Objects")]
        public ActionResult Objects(uint objectType) => Exec((error, objects) => datamanager.EnumObjects(error, objectType, objects));

        [HttpPost("NewVariable")]
        public ActionResult NewVariable(string name, DMVarTypes varType, string groupName = "", string connection = "", string specific = "") => Exec(() => datamanager.CreateNewVaraible(error, name, varType, groupName, connection), true);

        [HttpDelete( "Variable")]
        public ActionResult Variable(string name) => Exec(() => datamanager.DeleteVariable(error, name), true);

        [HttpPost("Connections")]
        public ActionResult Connections()
        {
            CMN_ERROR error = new CMN_ERROR();
            List<object> connections = new List<object>();
            if(!datamanager.EnumConnections(error, connections))
            {
                return BadRequest(error);
            }
            return Ok(connections); 
        }

        [HttpDelete( "Connection")]
        public ActionResult Connection(string connection)
        {
            CMN_ERROR error = new CMN_ERROR();
            if (!datamanager.DeleteConnection(error, connection))
            {
                return BadRequest(error);
            }
            return Ok(true);
        }

        [HttpPost("Connection")]
        public ActionResult Connection(string connection, string unitName, string specific, MCPNCon flag = MCPNCon.CREATE)
        {
            CMN_ERROR error = new CMN_ERROR();
            if (!datamanager.CreateConnection(error, connection, unitName, specific, flag))
            {
                return BadRequest(error);
            }
            return Ok(true);
        }

        [HttpPost("Drivers")]
        public ActionResult Drivers()
        {
            CMN_ERROR error = new CMN_ERROR();
            List<object> drivers = new List<object>();
            if(!datamanager.EnumDrivers(error, drivers))
            {
                return BadRequest(error);
            }
            return Ok(drivers);
        }

        [HttpPost("AvailableDrivers")]
        public ActionResult AvailableDrivers()
        {
            CMN_ERROR error = new CMN_ERROR();
            if (!datamanager.EnumAvailableDrivers(error, out List<object> drivers))
            {
                return BadRequest(error);
            }
            return Ok(drivers);
        }

        [HttpPost("Driver")]
        public ActionResult Driver(string path) => Exec((error) => datamanager.CreateDriver(error, path));

        [HttpDelete( "DeleteDriver")]
        public ActionResult DeleteDriver(string name) => Exec(() => datamanager.DeleteDriver(error, name), true);

        [HttpPost("Groups")]
        public ActionResult Groups() => Exec(datamanager.EnumGroups);

        [HttpPost("Group")]
        public ActionResult Group(string connection , string groupName) => Exec((error) => datamanager.CreateGroup(error, connection, groupName));

        [HttpPost("RenameGroup")]
        public ActionResult RenameGroup(string oldName, string newName) => Exec((error) => datamanager.RenameGroup(error, oldName, newName));

        [HttpDelete( "Group")]
        public ActionResult Group(string groupName) => Exec((error) => datamanager.DeleteGroup(error, groupName));

        [HttpPost("CreateStructuredTag")]
        public ActionResult CreateStructuredTag(string typeName) => Exec((error) => datamanager.CreateType(error, typeName));

        [HttpPost("StructuredTags")]
        public ActionResult StructuredTags() => Exec((error, objects) => datamanager.EnumTypes(error, objects));

        [HttpPost("StructuredTagsMembers")]
        public ActionResult StructuredTagsMembers(string typeName) => Exec((error, objects) => datamanager.EnumTypeMembers(error, typeName, objects));

        [HttpDelete( "StructuredTag")]
        public ActionResult StructuredTag(string typeName) => Exec((error) => datamanager.DeleteType(error, typeName));

        [HttpPost("StructuredTagInstance")]
        public ActionResult StructuredTagInstance(string structureName, string varName, string connection = "", string groupName = "", string specific = "") 
            => Exec((error) => datamanager.CreateTypeInstance(error, structureName, varName, connection, groupName, specific));

        [HttpPost("GetValue")]
        public ActionResult GetValue(string tag) => Exec((error, ok) => datamanager.GetValue(error, tag, ok));
        
        [HttpPost("GetValues")]
        public ActionResult GetValues(List<string> tags) => Exec((error, objects) => datamanager.GetValue(error, tags.ToArray(), objects));

        [HttpPost("GetValueWait")]
        public ActionResult GetValueWait(List<string> tags) => Exec((error, ok) => datamanager.GetValueWait(error, tags.ToArray(), ok));

        [HttpPost("GetVarLimits")]
        public ActionResult GetVarLimits(List<string> tags) => Exec((error, ok) => datamanager.GetVarLimits(error, tags.ToArray(), ok));

        [HttpPost("GetVarType")]
        public ActionResult GetVarType(List<string> tags) => Exec((error, ok) => datamanager.GetVarType(error, tags.ToArray(), ok));

        [HttpPost("SetValue")]
        public ActionResult SetValue(Dictionary<string, string> body) => Exec((error, objects) => datamanager.SetValue(error, body.Keys.ToArray(), body.Values.ToArray() ,objects));

        [HttpPost("SetValueMessage")]
        public ActionResult SetValueMessage(string tag, string value, string message) => Exec((error) => datamanager.SetValueMessage(error, tag, value, message));

        [HttpPost("SetValueWait")]
        public ActionResult SetValueWait(Dictionary<string, string> body) => Exec((error, objects) => datamanager.SetValueWait(error, body.Keys.ToArray(), body.Values.ToArray(), objects));

        [HttpPost("BeginStartVarUpdate")]
        public ActionResult BeginStartVarUpdate() => Exec((CMN_ERROR error, ref object ok) => datamanager.BeginStartVarUpdate(error, ref ok));

        [HttpPost("StartVarUpdate")]
        public ActionResult StartVarUpdate(string[] tags)
        {
            object ok = null;
            if(!datamanager.StartVarUpdate(error, tags,ref ok))
            {
                return BadRequest(error);
            }
            return Ok(ok);
        }

        [HttpPost("EndStartVarUpdate")]
        public ActionResult EndStartVarUpdate(uint? transactionID = null) => Exec((error) => datamanager.EndStartVarUpdate(error, transactionID));

        [HttpPost("StopVarUpdate")]
        public ActionResult StopVarUpdate(uint? transactionID = null) => Exec((error) => datamanager.StopVarUpdate(error, transactionID));

        [HttpPost("StopAllUpdates")]
        public ActionResult StopAllUpdates() => Exec((error) => datamanager.StopAllUpdates(error));
    }
}
