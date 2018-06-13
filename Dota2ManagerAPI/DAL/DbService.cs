using Dota2ManagerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2ManagerAPI.DAL
{
    public class DbService : DbContext
    {
        public DbService(DbContextOptions<DbService> options) : base(options) { }

        // Base Tables
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<WinRatesVersus> WinRatesVersus { get; set; }

        // Teams
        public DbSet<Team> Teams { get; set; }

        // Players
        public DbSet<Player> Players { get; set; }

    }
}
