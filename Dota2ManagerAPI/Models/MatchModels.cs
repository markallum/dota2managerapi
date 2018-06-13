using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2ManagerAPI.Models
{
    public class Lineup
    {
        public List<HeroMatched> Heroes { get; set; }

        public Lineup()
        {
            Heroes = new List<HeroMatched>();
        }
    }

    public class Match
    {

        public TeamMatched TeamRadiant { get; set; }
        public TeamMatched TeamDire { get; set; }

        public double RadiantBaseHeroInfluence { get; set; }
        public double DireBaseHeroInfluence { get; set; }

        public double RadiantBaseChance { get; set; }
        public double DireBaseChance { get; set; }

        public Match()
        {
            TeamRadiant = new TeamMatched();
            TeamDire = new TeamMatched();
            RadiantBaseChance = 50;
            DireBaseChance = 50;
        }
    }

    public class Matchup
    {
        public int TargetHeroID { get; set; }
        public double Disadvantage { get; set; }
    }


    public class TeamMatched
    {
        public Team TeamInfo { get; set; }
        public List<PlayerMatched> Players { get; set; }
        
        public TeamMatched()
        {
            TeamInfo = new Team();
            Players = new List<PlayerMatched>();
        }
        
    }

    public class PlayerMatched
    {
        public Player Player { get; set; }
        public HeroMatched Hero { get; set; }
        public double Influence { get; set; }
    }

    public class HeroMatched
    {
        public Hero HeroInfo { get; set; }
        public List<Matchup> Matchups { get; set; }
        
        public int PlayedByPlayerID { get; set; }

        public HeroMatched()
        {
            HeroInfo = new Hero();
            Matchups = new List<Matchup>();
        }
    }
}
