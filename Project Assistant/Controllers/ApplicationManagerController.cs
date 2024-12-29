using General;
using Microsoft.AspNetCore.Mvc;
using ScriptText.Intake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Assistant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationManagerController : CCController
    {
        [HttpGet("Connect")]
        public ActionResult Connect() => Exec(() => applicationManger.Connect(error), true);

        [HttpGet("Disconnect")]
        public ActionResult Disconnect() => Exec(() => applicationManger.Disconnect(error), true);

        [HttpGet("GetFunctions")]
        public ActionResult GetFunctions() => Exec((error,ok) => applicationManger.GetFunctions(error, ok));

        [HttpGet("GenGetSourceCode")]
        public ActionResult GenGetSourceCode(string file) => Exec((CMN_ERROR error, out string value) => applicationManger.GenGetSourceCode(error, file, out value));

        [HttpPost("CreateAction")]
        public ActionResult CreateAction(string sourceCode, string fileName) => Exec((CMN_ERROR error) => applicationManger.GenCreateAction(error, sourceCode, fileName));

        [HttpPost("CreateIntakeActions")]
        public ActionResult CreateIntakeActions(string name, int profileId, int lineId, string computerName = "")
        {
            return Exec(new Func<CMN_ERROR, bool>[]
            {
                (error) => applicationManger.CreateAction(error, new LoadUnitDataIntake()
                    {
                        UnitName = name,
                        ProfileId = profileId,
                        LineId = lineId,
                    }.Action, computerName)}); ;
        }

        [HttpPost("GetAllocTrigger")]
        public ActionResult GetAllocTrigger(string fileName) => Exec((CMN_ERROR error, List<object> list) => applicationManger.GetAllocTrigger(error, list, fileName));
    }
}
