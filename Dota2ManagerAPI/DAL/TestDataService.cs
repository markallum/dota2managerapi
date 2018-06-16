using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dota2ManagerAPI.Models;

namespace Dota2ManagerAPI.DAL
{
    public class TestDataService
    {
        private BaseService _baseService;
        private TeamService _teamService;

        public TestDataService(BaseService baseService, TeamService teamService)
        {
            _baseService = baseService;
            _teamService = teamService;
        }

        public async Task<TeamMatched> CreateRadiantTeam()
        {
            TeamMatched Radiant = new TeamMatched();

            Team TestTeam = await _teamService.GetTeam(1);
            Radiant.TeamInfo.id = TestTeam.id;
            Radiant.TeamInfo.Name = TestTeam.Name;

            foreach (var Player in TestTeam.Players)
            {
                var newPlayer = new PlayerMatched();
                newPlayer.Player = Player;
                Radiant.Players.Add(newPlayer);
            }

            return Radiant;
        }

        public async Task<TeamMatched> CreateDireTeam()
        {
            TeamMatched Dire = new TeamMatched();

            Team TestTeam = await _teamService.GetTeam(2);
            Dire.TeamInfo.id = TestTeam.id;
            Dire.TeamInfo.Name = TestTeam.Name;

            foreach (var Player in TestTeam.Players)
            {
                var newPlayer = new PlayerMatched();
                newPlayer.Player = Player;
                Dire.Players.Add(newPlayer);
            }

            return Dire;
        }

        public async Task<TeamMatched> CreateRadiantTeamMatched()
        {
            TeamMatched Radiant = new TeamMatched();

            Team RadiantTeam = await _teamService.GetTeam(1);
            List<HeroMatched> RadiantLineup = CreateRadiantLineup();

            Radiant.TeamInfo = new TeamInfo()
            {
                id = RadiantTeam.id,
                Name = RadiantTeam.Name
            };


            for (var i = 0; i < 5; i++)
            {
                var playerMatched = new PlayerMatched();
                playerMatched.Player = RadiantTeam.Players[i];
                playerMatched.Hero = RadiantLineup[i];
                Radiant.Players.Add(playerMatched);
            }

            return Radiant;
            
        }

        public async Task<TeamMatched> CreateDireTeamMatched()
        {
            TeamMatched Dire = new TeamMatched();

            Team DireTeam = await _teamService.GetTeam(2);
            List<HeroMatched> DireLineup = CreateDireLineup();

            Dire.TeamInfo = new TeamInfo()
            {
                id = DireTeam.id,
                Name = DireTeam.Name
            };

            for (var i = 0; i < 5; i++)
            {
                var playerMatched = new PlayerMatched();
                playerMatched.Player = DireTeam.Players[i];
                playerMatched.Hero = DireLineup[i];
                Dire.Players.Add(playerMatched);
            }

            return Dire;

        }



        // test lineups
        public List<HeroMatched> CreateRadiantLineup()
        {
            var RadiantLineup = new List<HeroMatched>();
            
            HeroMatched Five = new HeroMatched()
            {
                HeroInfo = _baseService.GetHero(42), // Kotl
            };
            RadiantLineup.Add(Five);
            
            HeroMatched Four = new HeroMatched()
            {
                HeroInfo = _baseService.GetHero(30), // Earthshaker
            };
            RadiantLineup.Add(Four);

            HeroMatched Three = new HeroMatched()
            {
                HeroInfo = _baseService.GetHero(86), // Clockwerk
            };
            RadiantLineup.Add(Three);
            
            HeroMatched Two = new HeroMatched()
            {
                HeroInfo = _baseService.GetHero(87), // Sniper
            };
            RadiantLineup.Add(Two);

            HeroMatched One = new HeroMatched()
            {
                HeroInfo = _baseService.GetHero(91), // Sven
            };
            RadiantLineup.Add(One);

            return RadiantLineup;
          }




        // test team
        public List<HeroMatched> CreateDireLineup()
        {
            var DireLinup = new List<HeroMatched>();

            HeroMatched Five = new HeroMatched()
            {
                HeroInfo = _baseService.GetHero(78), // Rubick
            };
            DireLinup.Add(Five);

            HeroMatched Four = new HeroMatched()
            {
                HeroInfo = _baseService.GetHero(29), // Earth Spirit
            };
            DireLinup.Add(Four);

            HeroMatched Three = new HeroMatched()
            {
                HeroInfo = _baseService.GetHero(95), // Tidehunter
            };
            DireLinup.Add(Three);

            HeroMatched Two = new HeroMatched()
            {
                HeroInfo = _baseService.GetHero(24), // Death Prophet
            };
            DireLinup.Add(Two);

            HeroMatched One = new HeroMatched()
            { 
                HeroInfo = _baseService.GetHero(41), // Juggernaut
            };
            DireLinup.Add(One);

            return DireLinup;
        }

    }
}
