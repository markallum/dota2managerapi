using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dota2ManagerAPI.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Admin")]
    public class AdminController : Controller
    {
        [HttpGet]
        public async Task<string> RunParse()
        {
            //Grabber grabber = new Grabber();

            return "done";
        }
    }
}