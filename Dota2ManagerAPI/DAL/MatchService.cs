using Dota2ManagerAPI.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2ManagerAPI.Web.DAL
{
    public interface IMatchService
    {
        Task<MatchSim> SetupMatchWithHeroes();
        Task<MatchSim> SetupMatchWithMatchups();
        MatchSim SimulateMatch(MatchSim matchSim);
        //Task<List<PlayerInMatch>> GetMatchups();
        //TeamInMatch calculateTeamInfluence();
    }


    public class MatchService : IMatchService
    {
        private DbService _dbService;
        private ITestDataService _testDataService;
        private ITeamService _teamService;

        public MatchService(DbService dbService, ITestDataService testDataService, ITeamService teamService)
        {
            _dbService = dbService;
            _testDataService = testDataService;
            _teamService = teamService;
        }

       


        public async Task<MatchSim> SetupMatchWithHeroes()
        {
            return new MatchSim();
        }

        public async Task<MatchSim> SetupMatchWithMatchups()
        {
            return new MatchSim();
        }




        public MatchSim SimulateMatch(MatchSim MatchSim)
        {


            // Calculate Influence
            MatchSim.TeamRadiant = calculateTeamInfluence(MatchSim.TeamRadiant, MatchSim.TeamDire);
            MatchSim.TeamDire = calculateTeamInfluence(MatchSim.TeamDire, MatchSim.TeamRadiant);



            // Order by Hero ID (temporary, will likely be by position)
            MatchSim.TeamRadiant.Players.OrderBy(x => x.Hero.HeroID);
            MatchSim.TeamDire.Players.OrderBy(x => x.Hero.HeroID);

            // Calculate Winner
            if (MatchSim.TeamRadiant.TotalInfluence > MatchSim.TeamDire.TotalInfluence)
            {
                MatchSim.IsRadiantWin = true;
            }
            else
            {
                MatchSim.IsRadiantWin = false;
            }

            return MatchSim;
        }

        public async Task<List<PlayerInMatch>> GetMatchups(List<PlayerInMatch> SourcePlayers, List<PlayerInMatch> TargetPlayers)
        {
            foreach (var SourcePlayer in SourcePlayers)
            {
                foreach (var TargetPlayer in TargetPlayers)
                {
                    Matchup newMatchup = new Matchup();
                    newMatchup.TargetHeroID = TargetPlayer.Hero.HeroID;
                    // Get disadvantage data
                    WinRatesVersus WinRateData = await _dbService.WinRatesVersus
                        .Where(x => x.BaseHeroID == SourcePlayer.Hero.HeroID && x.TargetHeroID == newMatchup.TargetHeroID)
                        .FirstOrDefaultAsync();

                    newMatchup.Advantage = WinRateData.Advantage;

                    //newMatchup.Disadvantage = await _dbService.WinRatesVersus
                    //    .Where(x => x.BaseHeroID == SourcePlayer.Hero.HeroInfo.HeroID && x.TargetHeroID == newMatchup.TargetHeroID)
                    //    .FirstOrDefaultAsync().Result.Disadvantage;
                    SourcePlayer.Hero.Matchups.Add(newMatchup);
                    SourcePlayer.Hero.InfluenceMatchups += newMatchup.Advantage;
                    //SourcePlayer.Influence += newMatchup.Disadvantage;
                    SourcePlayer.Hero.InfluenceMatchups = Math.Round(SourcePlayer.Hero.InfluenceMatchups, 4);
                }
            }

            return SourcePlayers;
        }

        public TeamInMatch calculateTeamInfluence(TeamInMatch SourceTeam, TeamInMatch TargetTeam)
        {
            // This should be put in a global setting somewhere
            double BaseModifier = 0.005;

            foreach (var SourcePlayer in SourceTeam.Players)
            {
                //foreach (var TargetPlayer in TargetTeam.Players)
                //{
                //    Matchup newMatchup = new Matchup();
                //    newMatchup.TargetHeroID = TargetPlayer.Hero.HeroInfo.HeroID;
                //    // Get disadvantage data
                //    newMatchup.Disadvantage = _dbService.WinRatesVersus.Where(x => x.BaseHeroID == SourcePlayer.Hero.HeroInfo.HeroID && x.TargetHeroID == newMatchup.TargetHeroID).FirstOrDefault().Disadvantage;
                //    SourcePlayer.Hero.Matchups.Add(newMatchup);
                //    SourcePlayer.Influence += newMatchup.Disadvantage;
                //}

                // Amplify Influence by skills
                // Base Modifier * Player Skill * Hero Skill
                SourcePlayer.Hero.InfluenceEfficiencyModifier = BaseModifier * SourcePlayer.Efficiency * SourcePlayer.Hero.Efficiency;
                SourcePlayer.Hero.InfluencePoiseModifier = BaseModifier * SourcePlayer.Poise * SourcePlayer.Hero.Poise;
                SourcePlayer.Hero.InfluenceSpeedModifier = BaseModifier * SourcePlayer.Speed * SourcePlayer.Hero.Speed;
                SourcePlayer.Hero.InfluencePositioningModifier = BaseModifier * SourcePlayer.Positioning * SourcePlayer.Hero.Positioning;
                SourcePlayer.Hero.InfluenceAwarenessModifier = BaseModifier * SourcePlayer.Awareness * SourcePlayer.Hero.Awareness;

                SourcePlayer.Hero.InfluenceTotalModifier = SourcePlayer.Hero.InfluenceEfficiencyModifier + SourcePlayer.Hero.InfluencePoiseModifier + SourcePlayer.Hero.InfluenceSpeedModifier + SourcePlayer.Hero.InfluencePositioningModifier + SourcePlayer.Hero.InfluenceAwarenessModifier;
                SourcePlayer.Influence = SourcePlayer.Hero.InfluenceMatchups + ((SourcePlayer.Hero.InfluenceMatchups * SourcePlayer.Hero.InfluenceTotalModifier) / 100);


                // Sorts matchups by hero ID, testing only - makes for easier comparison
                SourcePlayer.Hero.Matchups.OrderBy(x => x.TargetHeroID);


                SourceTeam.TotalInfluence += SourcePlayer.Influence;
            }




            return SourceTeam;
        }





    }
}
