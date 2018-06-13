using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2ManagerAPI.Models
{
    public class Team
    {
        public int id { get; set; }
        public string Name { get; set; }
        public List<Player> Players { get; set; }

        public Team()
        {
            Players = new List<Player>();
        }
    }

    public class Player
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public int Efficiency { get; set; }
        public int Poise { get; set; }
        public int Speed { get; set; }
        public int Positioning { get; set; }
        public int Awareness { get; set; }
        //public List<PlayerTraits> Traits { get; set; }
        public bool HasTeam { get; set; }
        public int TeamID { get; set; }
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
