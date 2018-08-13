using CORE.NG.DATA.Repository;
using CORE.NG.DATA.DBModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CORE.NG.CACHE;

namespace CORE.NG.API.Controllers
{
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        ITeamRepository userRepository;
        public TeamController(ITeamRepository _userRepository)
        {
            this.userRepository = _userRepository;
        }

        [HttpGet]
        [Produces(typeof(IActionResult))]
        [Route("Create")]
        public IActionResult Create()
        {           
            this.userRepository.Save();
            CacheManager.Remove("teams");
            return Ok();
        }

        
        [HttpGet]
        [Produces(typeof(List<Team>))]
        [Route("Get")]
        public IActionResult GetTeam()
        {
            List<Team> team = CacheManager.Get<List<Team>>("teams");
            if (team == null)
            {
                team = this.userRepository.Get();
                CacheManager.Set<List<Team>>("teams", team);
            }          
            return Ok(team);
        }
    }
}
