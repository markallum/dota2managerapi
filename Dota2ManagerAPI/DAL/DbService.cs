using Dota2ManagerAPI.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2ManagerAPI.Web.DAL
{
    public class DbService : DbContext
    {
        public DbService(DbContextOptions<DbService> options) : base(options) { }

        // Base
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<WinRatesVersus> WinRatesVersus { get; set; }

        // Teams
        public DbSet<Team> Teams { get; set; }

        // Players
        public DbSet<Player> Players { get; set; }
    }
}
