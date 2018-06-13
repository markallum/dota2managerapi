using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dota2ManagerAPI.Models;

namespace Dota2ManagerAPI.DAL
{
    public class TestDataService
    {
        private BaseService _baseService;

        public TestDataService(BaseService baseService)
        {
            _baseService = baseService;
        }



        // test lineups
        public Lineup CreateRadiantLineup()
        {
            Lineup RadiantLineup = new Lineup();

            // Kotl
            HeroMatched Kotl = new HeroMatched()
            {
                HeroInfo = _baseService.GetHero(42),
                PlayedByPlayerID = 2
                
            };
            RadiantLineup.Heroes.Add(Kotl);

            // Earthshaker
            HeroMatched Earthshaker = new HeroMatched()
            {
                HeroInfo = _baseService.GetHero(30),
                PlayedByPlayerID = 3
            };
            RadiantLineup.Heroes.Add(Earthshaker);

            // Storm Spirit
            HeroMatched StormSpirit = new HeroMatched()
            {
                HeroInfo = _baseService.GetHero(90),
                PlayedByPlayerID = 4
            };
            RadiantLineup.Heroes.Add(StormSpirit);

            // Slark
            HeroMatched Slark = new HeroMatched()
            {
                HeroInfo = _baseService.GetHero(86),
                PlayedByPlayerID = 5
            };
            RadiantLineup.Heroes.Add(Slark);

            // Sven
            HeroMatched Sven = new HeroMatched()
            {
                HeroInfo = _baseService.GetHero(91),
                PlayedByPlayerID = 6
            };
            RadiantLineup.Heroes.Add(Sven);

            return RadiantLineup;
        }




        // test team
        public Lineup CreateDireLineup()
        {
            Lineup DireLinup = new Lineup();

            // Rubick
            HeroMatched Rubick = new HeroMatched()
            {
                HeroInfo = _baseService.GetHero(78),
                PlayedByPlayerID = 6
            };
            DireLinup.Heroes.Add(Rubick);

            // Tidehunter
            HeroMatched Tidehunter = new HeroMatched()
            {
                HeroInfo = _baseService.GetHero(95),
                PlayedByPlayerID = 8
            };
            DireLinup.Heroes.Add(Tidehunter);

            // Queen of Pain
            HeroMatched QueenOfPain = new HeroMatched()
            {
                HeroInfo = _baseService.GetHero(75),
                PlayedByPlayerID = 9
            };
            DireLinup.Heroes.Add(QueenOfPain);

            // Juggernaut
            HeroMatched Juggernaut = new HeroMatched()
            {
                HeroInfo = _baseService.GetHero(41),
                PlayedByPlayerID = 10
            };
            DireLinup.Heroes.Add(Juggernaut);

            // Sniper
            HeroMatched Sniper = new HeroMatched()
            {
                HeroInfo = _baseService.GetHero(87),
                PlayedByPlayerID = 11
            };
            DireLinup.Heroes.Add(Sniper);

            return DireLinup;
        }

    }
}
