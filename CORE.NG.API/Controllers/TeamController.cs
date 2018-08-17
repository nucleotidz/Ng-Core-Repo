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

        [HttpGet]
        [Produces(typeof(IActionResult))]
        [Route("Create")]
        public IActionResult Create()
        {
            this.teamBL.Save();
            return Ok();
        }


        [HttpGet]
        [Produces(typeof(List<Team>))]
        [Route("Get")]
        public IActionResult GetTeam()
        {
            List<TeamDTO> team = this.teamBL.Get();
            return Ok();
        }
    }
}
