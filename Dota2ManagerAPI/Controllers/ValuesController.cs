using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dota2ManagerAPI.Web.DAL;
using Dota2ManagerAPI.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dota2ManagerAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private DbService _dbService;

        public ValuesController(DbService dbService)
        {
            _dbService = dbService;
        }

        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "value";
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
