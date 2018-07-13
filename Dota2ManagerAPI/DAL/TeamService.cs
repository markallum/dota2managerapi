using AutoMapper;
using Dota2ManagerAPI.Web.DAL;
using Dota2ManagerAPI.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2ManagerAPI.Web.DAL
{
    public interface ITeamService
    {
        Task<Team> GetTeam(int id);
        Task<TeamWithPlayers> GetTeamWithPlayers(int id);
    }
    public class TeamService : ITeamService
    {
        private DbService _dbService;
        public TeamService(DbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<Team> GetTeam(int id)
        {
            var Team = await _dbService.Teams.FindAsync(id);
            return Team;
        }

        public async Task<TeamWithPlayers> GetTeamWithPlayers(int id)
        {
            var BaseTeam = await _dbService.Teams.FindAsync(id);
            TeamWithPlayers TeamWP = new TeamWithPlayers();
            Mapper.Map(BaseTeam, TeamWP);
            TeamWP.Players = await _dbService.Players.Where(x => x.TeamID == id).ToListAsync();
            return TeamWP;
        }
    }
}
