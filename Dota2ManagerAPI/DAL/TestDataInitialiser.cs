using Dota2ManagerAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2ManagerAPI.Web.DAL
{
    public class TestDataInitialiser
    {
        private DbService _dbService;

        public TestDataInitialiser(DbService dbService)
        {
            _dbService = dbService;
        }

        public async Task Seed()
        {
            if (!_dbService.Players.Any())
            {
                _dbService.Players.AddRange(getTestPlayers());
                await _dbService.SaveChangesAsync();
            }


        }

        private List<Player> getTestPlayers()
        {
            List<Player> TestPlayers = new List<Player>();

            // TEAM ONE
            Player JohnSmith = new Player()
            {
                Name = "John Smith",
                Age = 20,
                HasTeam = true,
                TeamID = 1,

                Efficiency = 8,
                Poise = 6,
                Speed = 5,
                Positioning = 6,
                Awareness = 5
            };
            TestPlayers.Add(JohnSmith);


            Player TerryJones = new Player()
            {
                Name = "Terry Jones",
                Age = 23,
                HasTeam = true,
                TeamID = 1,

                Efficiency = 5,
                Poise = 7,
                Speed = 6,
                Positioning = 4,
                Awareness = 5
            };
            TestPlayers.Add(TerryJones);

            Player TimBerry = new Player()
            {
                Name = "Tim Berry",
                Age = 19,
                HasTeam = true,
                TeamID = 1,

                Efficiency = 6,
                Poise = 5,
                Speed = 4,
                Positioning = 7,
                Awareness = 7
            };
            TestPlayers.Add(TimBerry);


            Player AdamSim = new Player()
            {
                Name = "Adam Sim",
                Age = 21,
                HasTeam = true,
                TeamID = 1,

                Efficiency = 7,
                Poise = 6,
                Speed = 5,
                Positioning = 4,
                Awareness = 4
            };
            TestPlayers.Add(AdamSim);

            Player GlennMiles = new Player()
            {
                Name = "Glenn Miles",
                Age = 24,
                HasTeam = true,
                TeamID = 1,

                Efficiency = 4,
                Poise = 6,
                Speed = 6,
                Positioning = 4,
                Awareness = 5
            };
            TestPlayers.Add(GlennMiles);



            // TEAM TWO
            Player SamLance = new Player()
            {
                Name = "Sam Lance",
                Age = 25,
                HasTeam = true,
                TeamID = 2,

                Efficiency = 7,
                Poise = 4,
                Speed = 5,
                Positioning = 5,
                Awareness = 4
            };
            TestPlayers.Add(SamLance);

            Player EricElrin = new Player()
            {
                Name = "Eric Elrin",
                Age = 17,
                HasTeam = true,
                TeamID = 2,

                Efficiency = 5,
                Poise = 6,
                Speed = 5,
                Positioning = 4,
                Awareness = 5
            };
            TestPlayers.Add(EricElrin);

            Player LennyJohnson = new Player()
            {
                Name = "Lenny Johnson",
                Age = 25,
                HasTeam = true,
                TeamID = 2,

                Efficiency = 8,
                Poise = 7,
                Speed = 3,
                Positioning = 4,
                Awareness = 4
            };
            TestPlayers.Add(LennyJohnson);

            Player CliveBell = new Player()
            {
                Name = "Clive Bell",
                Age = 21,
                HasTeam = true,
                TeamID = 2,

                Efficiency = 5,
                Poise = 5,
                Speed = 6,
                Positioning = 7,
                Awareness = 6
            };
            TestPlayers.Add(CliveBell);

            Player WinstonJames = new Player()
            {
                Name = "Winston James",
                Age = 23,
                HasTeam = true,
                TeamID = 2,

                Efficiency = 5,
                Poise = 5,
                Speed = 6,
                Positioning = 6,
                Awareness = 6
            };
            TestPlayers.Add(WinstonJames);
            return TestPlayers;
        }
    }
}

