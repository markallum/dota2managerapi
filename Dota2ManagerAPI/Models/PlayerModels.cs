using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2ManagerAPI.Web.Models
{
    public class Player
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Efficiency { get; set; }
        public int Poise { get; set; }
        public int Speed { get; set; }
        public int Positioning { get; set; }
        public int Awareness { get; set; }
        //public List<PlayerTraits> Traits { get; set; }
        public bool HasTeam { get; set; }
        public int TeamID { get; set; }
        public int Position { get; set; }
    }

    public class PlayerInDraft : Player
    {
        public bool HasPickedHero { get; set; }
        public Hero Hero { get; set; }
    }

    public class PlayerInMatch : Player
    {
        public bool HasPickedHero { get; set; }
        public HeroInMatch Hero { get; set; }
        public double Influence { get; set; }

        public PlayerInMatch()
        {
            Influence = 0;
        }
    }

    public class PlayerSkills
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }

    public class PlayerTraits
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
