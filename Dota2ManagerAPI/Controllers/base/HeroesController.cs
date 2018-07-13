using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dota2ManagerAPI.Web.DAL;
using Dota2ManagerAPI.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dota2ManagerAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/base/heroes")]
    public class HeroesController : Controller
    {
        private readonly DbService _dbService;

        public HeroesController(DbService dbService)
        {
            _dbService = dbService;
        }


        [HttpGet]
        public async Task<List<Hero>> Get()
        {
            List<Hero> Heroes = await _dbService.Heroes.OrderBy(x => x.Name).ToListAsync();
            return Heroes;
        }


    }
}