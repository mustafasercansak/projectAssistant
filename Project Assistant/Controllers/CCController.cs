using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlCenter;
using General;

namespace Project_Assistant.Controllers
{
    public delegate T FuncOut<U,T>(CMN_ERROR error, out U value);
    public  class CCController: ControllerBase
    {
        internal CMN_ERROR error = new CMN_ERROR();
        internal DataManager datamanager => Program.DataManager;
        internal Scripts.ApplicationManger applicationManger => Program.ApplicationManger;
        internal ActionResult Exec(Func<bool> func, object ok)
        {
            if(func())
            {
                return Ok(ok);
            }
            else
            {
                return BadRequest(error);
            }
        }
        internal ActionResult Exec(Func<CMN_ERROR, List<object>, bool> func)
        {
            List<object> ok = new List<object>();
            if (!func(error, ok))
            {
                return BadRequest(error);
            }
            return Ok(ok);
        }
        internal ActionResult Exec(Func<CMN_ERROR, bool> func)
        {
            if (!func(error))
            {
                return BadRequest(error);
            }
            return Ok(true);
        }
        internal ActionResult Exec<T>(FuncOut<T,bool> func)
        {
            if (!func(error, out T value))
            {
                return BadRequest(error);
            }
            return Ok(value);
        }
        internal delegate bool FuncWithRefObject(CMN_ERROR error, ref object value);
        internal ActionResult Exec(FuncWithRefObject func)
        {
            object ok = null;
            if (!func(error, ref ok))
            {
                return BadRequest(error);
            }
            return Ok(ok);
        }
        internal ActionResult Exec(Func<CMN_ERROR, bool>[] funcs)
        {
            foreach (var func in funcs)
            {
                if(!func(error))
                {
                    return BadRequest(error);
                }
            }
            return Ok(true);
        }
    }
}
