using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCalculator.DataObjects;
using CoreCalculator.ServerDefinitions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreCalculator.Controllers
{
    
    [Route("[controller]")]
    public class CalculusController : ControllerBase
    {
        [HttpGet]
        public ActionResult<ICalculus> Get(string query) {
            if (query == "fail")
            {
                return new CalculusFail() { Error = true, Message = "fail"};
            }
            return new CalculusSuccess() { Result = 100 };
        }

    }
}
