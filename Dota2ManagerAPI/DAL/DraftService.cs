using Dota2ManagerAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2ManagerAPI.Web.DAL
{
    public interface IDraftService
    {
        Task<DraftSim> SetupDraft();
        
    }

    

    

    public class DraftService : IDraftService
    {
        private ITestDataService _testDataService;

        public DraftService(ITestDataService testDataService)
        {
            _testDataService = testDataService;
        }


        public async Task<DraftSim> SetupDraft()
        {
            DraftSim DraftSimVM = new DraftSim();


            // Get test setups
            DraftSimVM.TeamRadiant = await _testDataService.CreateTestTeam(1);
            DraftSimVM.TeamDire = await _testDataService.CreateTestTeam(2);

            // Get matchup data
            //Match.TeamRadiant.Players = await GetMatchups(Match.TeamRadiant.Players, Match.TeamDire.Players);
            //Match.TeamDire.Players = await GetMatchups(Match.TeamDire.Players, Match.TeamRadiant.Players);


            return DraftSimVM;
        }
    }
}
