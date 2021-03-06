using CORE.NG.DATA.DBModel;
using CORE.NG.LOGGER;
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
        ILoggerService logger;

        public TeamController(ITeamBL _teamBL,ILoggerService _logger)
        {
            this.teamBL = _teamBL;
            this.logger = _logger;
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

        [HttpGet]
        [Route("Error")]
        public IActionResult Error()
        {
            try
            {
                int j=0;
                var i = 10 / j;
            }
            catch (System.Exception ex)
            {

                logger.ErrorAsync(ex);
                return BadRequest(ex.ToString());
            }
            
            return Ok();
        }
    }
}
