using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2ManagerAPI.Web.Models
{
    public class Team
    {
        public int id { get; set; }
        public string Name { get; set; }
    }

    public class TeamWithPlayers : Team
    {
        public List<Player> Players { get; set; }

        public TeamWithPlayers()
        {
            Players = new List<Player>();
        }
    }

    public class TeamInDraft : Team
    {
        public List<PlayerInDraft> Players { get; set; }

        public TeamInDraft()
        {
            Players = new List<PlayerInDraft>();
        }
    }

    public class TeamInMatch : Team
    {
        public List<PlayerInMatch> Players { get; set; }
        public double TotalInfluence { get; set; }

        public TeamInMatch()
        {
            Players = new List<PlayerInMatch>();
            TotalInfluence = 0;
        }

    }



}
