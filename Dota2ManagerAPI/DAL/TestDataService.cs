using AutoMapper;
using Dota2ManagerAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2ManagerAPI.Web.DAL
{
    public interface ITestDataService
    {
        Task<TeamInDraft> CreateTestTeam(int TestTeamID);
        /*
        Task<TeamInMatch> CreateRadiantTeam();
        Task<TeamInMatch> CreateDireTeam();
        
        Task<TeamInMatch> CreateRadiantTeamInMatch();
        Task<TeamInMatch> CreateDireTeamInMatch();
        List<HeroInMatch> CreateRadiantLineup();
        List<HeroInMatch> CreateDireLineup();
        */

    }
    public class TestDataService : ITestDataService
    {
        private IBaseService _baseService;
        private ITeamService _teamService;

        public TestDataService(IBaseService baseService, ITeamService teamService)
        {
            _baseService = baseService;
            _teamService = teamService;
        }

        

        public async Task<TeamInDraft> CreateTestTeam(int TestTeamID)
        {
            TeamInDraft TestTeamIM = new TeamInDraft();

            TeamWithPlayers TeamWP = await _teamService.GetTeamWithPlayers(TestTeamID);
            TestTeamIM.id = TeamWP.id;
            TestTeamIM.Name = TeamWP.Name;

            foreach (var Player in TeamWP.Players)
            {
                var newPlayer = new PlayerInDraft();
                Mapper.Map(Player, newPlayer);
                TestTeamIM.Players.Add(newPlayer);
            }

            return TestTeamIM;
        }

        /*
        public async Task<TeamInMatch> CreateRadiantTeam()
        {
            TeamInMatch Radiant = new TeamInMatch();

            Team TestTeam = await _teamService.GetTeam(1);
            Radiant.id = TestTeam.id;
            Radiant.Name = TestTeam.Name;

            foreach (var Player in TestTeam.Players)
            {
                var newPlayer = new PlayerInMatch();
                Mapper.Map(Player, newPlayer);
                Radiant.Players.Add(newPlayer);
            }

            return Radiant;
        }

        public async Task<TeamInMatch> CreateDireTeam()
        {
            TeamInMatch Dire = new TeamInMatch();

            Team TestTeam = await _teamService.GetTeam(2);
            Dire.id = TestTeam.id;
            Dire.Name = TestTeam.Name;

            foreach (var Player in TestTeam.Players)
            {
                var newPlayer = new PlayerInMatch();
                Mapper.Map(Player, newPlayer);
                Dire.Players.Add(newPlayer);
            }

            return Dire;
        }

        */

        /*
        public async Task<TeamInMatch> CreateRadiantTeamInMatch()
        {
            TeamInMatch Radiant = new TeamInMatch();

            Team RadiantTeam = await _teamService.GetTeam(1);
            List<HeroInMatch> RadiantLineup = CreateRadiantLineup();

            Radiant.TeamInfo = new TeamInfo()
            {
                id = RadiantTeam.id,
                Name = RadiantTeam.Name
            };


            for (var i = 0; i < 5; i++)
            {
                var PlayerInMatch = new PlayerInMatch();
                PlayerInMatch.Player = RadiantTeam.Players[i];
                PlayerInMatch.Hero = RadiantLineup[i];
                Radiant.Players.Add(PlayerInMatch);
            }

            return Radiant;

        }

        public async Task<TeamInMatch> CreateDireTeamInMatch()
        {
            TeamInMatch Dire = new TeamInMatch();

            Team DireTeam = await _teamService.GetTeam(2);
            List<HeroInMatch> DireLineup = CreateDireLineup();

            Dire.TeamInfo = new TeamInfo()
            {
                id = DireTeam.id,
                Name = DireTeam.Name
            };

            for (var i = 0; i < 5; i++)
            {
                var PlayerInMatch = new PlayerInMatch();
                PlayerInMatch.Player = DireTeam.Players[i];
                PlayerInMatch.Hero = DireLineup[i];
                Dire.Players.Add(PlayerInMatch);
            }

            return Dire;

        }

        // test lineups
        public List<HeroInMatch> CreateRadiantLineup()
        {
            var RadiantLineup = new List<HeroInMatch>();

            HeroInMatch Five = new HeroInMatch()
            {
                HeroInfo = _baseService.GetHero(42), // Kotl
            };
            RadiantLineup.Add(Five);

            HeroInMatch Four = new HeroInMatch()
            {
                HeroInfo = _baseService.GetHero(30), // Earthshaker
            };
            RadiantLineup.Add(Four);

            HeroInMatch Three = new HeroInMatch()
            {
                HeroInfo = _baseService.GetHero(86), // Clockwerk
            };
            RadiantLineup.Add(Three);

            HeroInMatch Two = new HeroInMatch()
            {
                HeroInfo = _baseService.GetHero(87), // Sniper
            };
            RadiantLineup.Add(Two);

            HeroInMatch One = new HeroInMatch()
            {
                HeroInfo = _baseService.GetHero(91), // Sven
            };
            RadiantLineup.Add(One);

            return RadiantLineup;
        }

        // test team
        public List<HeroInMatch> CreateDireLineup()
        {
            var DireLinup = new List<HeroInMatch>();

            HeroInMatch Five = new HeroInMatch()
            {
                HeroInfo = _baseService.GetHero(78), // Rubick
            };
            DireLinup.Add(Five);

            HeroInMatch Four = new HeroInMatch()
            {
                HeroInfo = _baseService.GetHero(29), // Earth Spirit
            };
            DireLinup.Add(Four);

            HeroInMatch Three = new HeroInMatch()
            {
                HeroInfo = _baseService.GetHero(95), // Tidehunter
            };
            DireLinup.Add(Three);

            HeroInMatch Two = new HeroInMatch()
            {
                HeroInfo = _baseService.GetHero(24), // Death Prophet
            };
            DireLinup.Add(Two);

            HeroInMatch One = new HeroInMatch()
            {
                HeroInfo = _baseService.GetHero(41), // Juggernaut
            };
            DireLinup.Add(One);

            return DireLinup;
        }
        */
    }

}
