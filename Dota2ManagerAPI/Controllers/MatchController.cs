using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dota2ManagerAPI.DAL;
using Dota2ManagerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dota2ManagerAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Match")]
    public class MatchController : Controller
    {
        private readonly MatchService _matchService;

        public MatchController(MatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpGet]
        public async Task<Match> Get()
        {
            return _matchService.runMatch();
        }
    }
}