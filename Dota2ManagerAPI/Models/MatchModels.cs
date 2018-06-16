using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2ManagerAPI.Models
{

    public class Match
    {

        public TeamMatched TeamRadiant { get; set; }
        public TeamMatched TeamDire { get; set; }

        public bool IsRadiantWin { get; set; }

        public Match()
        {
            TeamRadiant = new TeamMatched();
            TeamDire = new TeamMatched();
        }
    }

    public class Matchup
    {
        public int TargetHeroID { get; set; }
        public double Advantage { get; set; }
    }


    public class TeamMatched
    {
        public TeamInfo TeamInfo { get; set; }
        public List<PlayerMatched> Players { get; set; }
        public double TotalInfluence { get; set; }
        
        public TeamMatched()
        {
             TeamInfo = new TeamInfo();
            Players = new List<PlayerMatched>();
            TotalInfluence = 0;
        }
        
    }

    public class PlayerMatched
    {
        public Player Player { get; set; }
        public HeroMatched Hero { get; set; }
        public double Influence { get; set; }

        public PlayerMatched()
        {
            Influence = 0;
        }
    }

    public class HeroMatched
    {
        public Hero HeroInfo { get; set; }
        public List<Matchup> Matchups { get; set; }

        public double InfluenceEfficiencyModifier { get; set; }
        public double InfluencePoiseModifier { get; set; }
        public double InfluenceSpeedModifier { get; set; }
        public double InfluencePositioningModifier { get; set; }
        public double InfluenceAwarenessModifier { get; set; }
        public double InfluenceTotalModifier { get; set; }
        public double InfluenceMatchups { get; set; }

        public HeroMatched()
        {
            HeroInfo = new Hero();
            Matchups = new List<Matchup>();
        }
    }
}
