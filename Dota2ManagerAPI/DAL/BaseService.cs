using Dota2ManagerAPI.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2ManagerAPI.Web.DAL
{
    public interface IBaseService
    {
        Task<Hero> GetHero(int HeroID);
        Task<List<Hero>> GetHeroes();
    }

    public class BaseService : IBaseService
    {
        private DbService _dbService;
        public BaseService(DbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<Hero> GetHero(int HeroID)
        {
            

            return await _dbService.Heroes.Where(x => x.HeroID == HeroID).FirstOrDefaultAsync();
        }

        public async Task<List<Hero>> GetHeroes()
        {
            return await _dbService.Heroes.OrderBy(x => x.Name).ToListAsync();
        }


    }
}