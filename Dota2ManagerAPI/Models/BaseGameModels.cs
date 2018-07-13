using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2ManagerAPI.Web.Models
{
    


    public class WinRatesVersus
    {
        public int id { get; set; }
        public int BaseHeroID { get; set; }
        public int TargetHeroID { get; set; }
        public double Advantage { get; set; }

        // look at puck vs pudge stats, puck was missing a value
        // 78 too
    }
}
