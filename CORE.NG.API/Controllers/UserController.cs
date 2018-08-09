using CORE.NG.API.Context;
using CORE.NG.API.DBModel;
using CORE.NG.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CORE.NG.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        ITeamRepository userRepository;
        public UserController(ITeamRepository _userRepository)
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
        [Produces(typeof(List<user>))]
        [Route("Get")]
        public IActionResult GetUsers()
        {
            return Ok(this.userRepository.Get());
        }
    }
}
