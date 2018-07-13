using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2ManagerAPI.Web.Models
{
    public class Hero
    {
        public int id { get; set; }
        public int HeroID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool isMelee { get; set; }
        public int Efficiency { get; set; }
        public int Poise { get; set; }
        public int Speed { get; set; }
        public int Positioning { get; set; }
        public int Awareness { get; set; }
    }

    public class HeroInDraft : Hero
    {
        public bool isSelected { get; set; }
    }


    public class HeroInMatch : Hero
    {
        public List<Matchup> Matchups { get; set; }

        public double InfluenceEfficiencyModifier { get; set; }
        public double InfluencePoiseModifier { get; set; }
        public double InfluenceSpeedModifier { get; set; }
        public double InfluencePositioningModifier { get; set; }
        public double InfluenceAwarenessModifier { get; set; }
        public double InfluenceTotalModifier { get; set; }
        public double InfluenceMatchups { get; set; }

        public HeroInMatch()
        {
            Matchups = new List<Matchup>();
        }
    }

    public class Matchup
    {
        public int TargetHeroID { get; set; }
        public double Advantage { get; set; }
    }
}
