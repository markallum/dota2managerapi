using Dota2ManagerAPI.Models;
using Microsoft.EntityFrameworkCore;
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
        public async Task<Team> GetTeam(int TeamID)
        {
            var Team = await _dbService.Teams.FindAsync(TeamID);
            Team.Players = await _dbService.Players.Where(x => x.TeamID == TeamID).ToListAsync();
            return Team;
        }
    }
}
