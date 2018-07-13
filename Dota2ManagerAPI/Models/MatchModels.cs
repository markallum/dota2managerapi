using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2ManagerAPI.Web.Models
{
    public class DraftSim
    {

        public List<Hero> AvailableHeroes { get; set; }

        public TeamInDraft TeamRadiant { get; set; }
        public TeamInDraft TeamDire { get; set; }

        public DraftSim()
        {
            AvailableHeroes = new List<Hero>();
            TeamRadiant = new TeamInDraft();
            TeamDire = new TeamInDraft();
        }
    }

    public class MatchSim
    {
        public TeamInMatch TeamRadiant { get; set; }
        public TeamInMatch TeamDire { get; set; }

        public bool IsRadiantWin { get; set; }

        public MatchSim()
        {
            TeamRadiant = new TeamInMatch();
            TeamDire = new TeamInMatch();
        }
    }











}
