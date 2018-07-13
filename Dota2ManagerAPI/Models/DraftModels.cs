using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2ManagerAPI.Web.Models
{
        public class Draft
        {

            public List<Hero> AvailableHeroes { get; set; }

            public TeamInDraft TeamRadiant { get; set; }
            public TeamInDraft TeamDire { get; set; }

            public Draft()
            {
                AvailableHeroes = new List<Hero>();
                TeamRadiant = new TeamInDraft();
                TeamDire = new TeamInDraft();
            }
        }
   
}
