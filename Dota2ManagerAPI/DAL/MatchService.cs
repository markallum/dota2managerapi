using Dota2ManagerAPI.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Match> SetupMatch()
        {
            Match Match = new Match();

            // Get test setups
            Match.TeamRadiant = await _testDataService.CreateRadiantTeam();
            Match.TeamDire = await _testDataService.CreateDireTeam();

            // Get matchup data
            //Match.TeamRadiant.Players = await GetMatchups(Match.TeamRadiant.Players, Match.TeamDire.Players);
            //Match.TeamDire.Players = await GetMatchups(Match.TeamDire.Players, Match.TeamRadiant.Players);


            return Match;
        }

 

        // TESTING
        public Match SimulateMatch(Match Match)
        {
            

            // Calculate Influence
            Match.TeamRadiant = calculateTeamInfluence(Match.TeamRadiant, Match.TeamDire);
            Match.TeamDire = calculateTeamInfluence(Match.TeamDire, Match.TeamRadiant);

            

            // Order by Hero ID (temporary, will likely be by position)
            Match.TeamRadiant.Players.OrderBy(x => x.Hero.HeroInfo.HeroID);
            Match.TeamDire.Players.OrderBy(x => x.Hero.HeroInfo.HeroID);

            // Calculate Winner
            if (Match.TeamRadiant.TotalInfluence > Match.TeamDire.TotalInfluence)
            {
                Match.IsRadiantWin = true;
            } else
            {
                Match.IsRadiantWin = false;
            }

            return Match;
        }

        public async Task<List<PlayerMatched>> GetMatchups(List<PlayerMatched> SourcePlayers, List<PlayerMatched> TargetPlayers)
        {
            foreach (var SourcePlayer in SourcePlayers)
            {
                foreach (var TargetPlayer in TargetPlayers)
                {
                    Matchup newMatchup = new Matchup();
                    newMatchup.TargetHeroID = TargetPlayer.Hero.HeroInfo.HeroID;
                    // Get disadvantage data
                    WinRatesVersus WinRateData = await _dbService.WinRatesVersus
                        .Where(x => x.BaseHeroID == SourcePlayer.Hero.HeroInfo.HeroID && x.TargetHeroID == newMatchup.TargetHeroID)
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

        public TeamMatched calculateTeamInfluence(TeamMatched SourceTeam, TeamMatched TargetTeam)
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
                SourcePlayer.Hero.InfluenceEfficiencyModifier = BaseModifier * SourcePlayer.Player.Efficiency * SourcePlayer.Hero.HeroInfo.Efficiency;
                SourcePlayer.Hero.InfluencePoiseModifier = BaseModifier * SourcePlayer.Player.Poise * SourcePlayer.Hero.HeroInfo.Poise;
                SourcePlayer.Hero.InfluenceSpeedModifier = BaseModifier * SourcePlayer.Player.Speed * SourcePlayer.Hero.HeroInfo.Speed;
                SourcePlayer.Hero.InfluencePositioningModifier = BaseModifier * SourcePlayer.Player.Positioning * SourcePlayer.Hero.HeroInfo.Positioning;
                SourcePlayer.Hero.InfluenceAwarenessModifier = BaseModifier * SourcePlayer.Player.Awareness * SourcePlayer.Hero.HeroInfo.Awareness;

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
