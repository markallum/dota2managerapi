using Dota2ManagerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2ManagerAPI.DAL
{
    public class TeamService
    {
        private DbService _dbService;

        public TeamService(DbService dbService)
        {
            _dbService = dbService;
        }
        public Team GetTeam(int TeamID)
        {
            var Team =  _dbService.Teams.Find(TeamID);
            Team.Players = _dbService.Players.Where(x => x.TeamID == Team.id).ToList();
            return _dbService.Teams.Find(TeamID);
        }
    }
}
