using CORE.NG.DATA.DBModel;
using CORE.NG.MODELS;
using Microsoft.AspNetCore.Mvc;
using NG.CORE.BUSINESS;
using System.Collections.Generic;

namespace CORE.NG.API.Controllers
{
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        ITeamBL teamBL;

        public TeamController(ITeamBL _teamBL)
        {
            this.teamBL = _teamBL;
        }

        [HttpPost]
        [Produces(typeof(IActionResult))]
        [Route("Create")]
        public IActionResult Create(TeamDTO team)
        {          
            this.teamBL.Save(team);
            return Ok();
        }

        [HttpGet]
        [Produces(typeof(List<Team>))]
        [Route("Get")]
        public IActionResult GetTeams()
        {
            List<TeamDTO> team = this.teamBL.Get();
            return Ok(team);
        }
    }
}
