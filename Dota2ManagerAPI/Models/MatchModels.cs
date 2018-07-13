using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2ManagerAPI.Web.Models
{
    

    public class Match
    {
        public TeamInMatch TeamRadiant { get; set; }
        public TeamInMatch TeamDire { get; set; }

        public bool IsRadiantWin { get; set; }

        public Match()
        {
            TeamRadiant = new TeamInMatch();
            TeamDire = new TeamInMatch();
        }
    }











}
