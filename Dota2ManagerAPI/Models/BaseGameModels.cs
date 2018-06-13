using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2ManagerAPI.Models
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


    public class WinRatesVersus
    {
        public int id { get; set; }
        public int BaseHeroID { get; set; }
        public int TargetHeroID { get; set; }
        public double Disadvantage { get; set; }

        // look at puck vs pudge stats, puck was missing a value
        // 78 too
    }
}
