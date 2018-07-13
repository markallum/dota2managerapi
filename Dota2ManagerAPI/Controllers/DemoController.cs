using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dota2ManagerAPI.Web.DAL;
using Dota2ManagerAPI.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dota2ManagerAPI.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/demo")]
    public class DemoController : Controller
    {
        private IMatchService _matchService;
        private IDraftService _draftService;
        private IBaseService _baseService;

        public DemoController(IMatchService matchService, IDraftService draftService, IBaseService baseService)
        {
            _matchService = matchService;
            _draftService = draftService;
            _baseService = baseService;
        }
        
        [HttpGet]
        public async Task<Draft> Get()
        {
            var DraftVM = await _draftService.SetupDraft();
            DraftVM.AvailableHeroes = await _baseService.GetHeroes();

            return DraftVM;
        }
        /*
        [HttpGet]
        public string Get()
        {
            return "it works!";
        }
        */
        
    }
}