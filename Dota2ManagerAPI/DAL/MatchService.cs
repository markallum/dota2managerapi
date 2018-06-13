using Dota2ManagerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2ManagerAPI.DAL
{
    public class MatchService
    {
        private DbService _dbService;
        private TestDataService _testDataService;
        private TeamService _teamService;

        public MatchService(DbService dbService, TestDataService testDataService, TeamService teamService)
        {
            _dbService = dbService;
            _testDataService = testDataService;
            _teamService = teamService;
        }

        // TESTING
        public Match runMatch()
        {
            Match Match = new Match();



            Random rnd = new Random();

            //// Generate random lineups
            //for (var i = 0; i < 5; i++)
            //{
            //    HeroMatched newHero = new HeroMatched();
            //    newHero.HeroInfo = _baseService.GetHero(rnd.Next(1, 115));
            //    Match.RadiantLineup.Heroes.Add(newHero);
            //}

            //for (var i = 0; i < 5; i++)
            //{
            //    HeroMatched newHero = new HeroMatched();
            //    newHero.HeroInfo = _baseService.GetHero(rnd.Next(1, 115));
            //    Match.DireLineup.Heroes.Add(newHero);
            //}


            Match.TeamRadiant.Lineup = _testDataService.CreateRadiantLineup();
            Match.TeamDire.Lineup = _testDataService.CreateDireLineup();

            Match.TeamRadiant.TeamInfo = _teamService.GetTeam(1);
            Match.TeamDire.TeamInfo = _teamService.GetTeam(2);

            double RadiantBaseHeroInfluenceCounter = 0;
            // Get winrate statistics RADIANT
            foreach (var bhero in Match.TeamRadiant.Lineup.Heroes)
            {
                foreach (var thero in Match.TeamDire.Lineup.Heroes)
                {
                    Matchup newMatchup = new Matchup();
                    newMatchup.TargetHeroID = thero.HeroInfo.HeroID;
                    newMatchup.Disadvantage = _dbService.WinRatesVersus.Where(x => x.BaseHeroID == bhero.HeroInfo.HeroID && x.TargetHeroID == newMatchup.TargetHeroID).FirstOrDefault().Disadvantage;
                    bhero.Matchups.Add(newMatchup);
                    bhero.Influence += newMatchup.Disadvantage;
                }

                bhero.Matchups.OrderBy(x => x.TargetHeroID);
                RadiantBaseHeroInfluenceCounter += bhero.Influence;
            }

            double DireBaseHeroInfluenceCounter = 0;
            // Get winrate statistics DIRE
            foreach (var bhero in Match.TeamDire.Lineup.Heroes)
            {
                foreach (var thero in Match.TeamRadiant.Lineup.Heroes)
                {
                    Matchup newMatchup = new Matchup();
                    newMatchup.TargetHeroID = thero.HeroInfo.HeroID;
                    newMatchup.Disadvantage = _dbService.WinRatesVersus.Where(x => x.BaseHeroID == bhero.HeroInfo.HeroID && x.TargetHeroID == newMatchup.TargetHeroID).FirstOrDefault().Disadvantage;
                    bhero.Matchups.Add(newMatchup);
                    bhero.Influence += newMatchup.Disadvantage;
                }

                bhero.Matchups.OrderBy(x => x.TargetHeroID);
                DireBaseHeroInfluenceCounter += bhero.Influence;
            }

            Match.RadiantBaseChance -= RadiantBaseHeroInfluenceCounter;
            Match.DireBaseChance -= DireBaseHeroInfluenceCounter;

            // Calculate winrate

            Match.TeamRadiant.Lineup.Heroes.OrderBy(x => x.HeroInfo.HeroID);
            Match.TeamDire.Lineup.Heroes.OrderBy(x => x.HeroInfo.HeroID);


            return Match;
        } 






    }
}
