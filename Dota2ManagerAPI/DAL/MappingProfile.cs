using AutoMapper;
using Dota2ManagerAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2ManagerAPI.Web.DAL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Team, TeamInMatch>();
            CreateMap<Team, TeamWithPlayers>();
            CreateMap<Player, PlayerInMatch>();
            CreateMap<Hero, HeroInMatch>();
        }
    }
}
