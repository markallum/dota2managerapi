using Dota2ManagerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2ManagerAPI.DAL
{
    public class BaseService
    {
        private DbService _dbService;
        public BaseService(DbService dbService)
        {
            _dbService = dbService;
        }

        public Hero GetHero(int HeroID)
        {
            Hero hero = _dbService.Heroes.Where(x => x.HeroID == HeroID).FirstOrDefault();

            return hero;
        }
    }
}
