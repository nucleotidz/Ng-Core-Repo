using CORE.NG.DATA.Repository;
using CORE.NG.DATA.DBModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            return Ok();
        }

        
        [HttpGet]
        [Produces(typeof(List<Team>))]
        [Route("Get")]
        public IActionResult GetTeam()
        {
            return Ok(this.userRepository.Get());
        }
    }
}
