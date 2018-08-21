using CORE.NG.API.Controllers;
using CORE.NG.DATA.Repository;
using CORE.NG.MODELS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NG.CORE.BUSINESS;
using System.Collections.Generic;

namespace CORE.NG.APITests
{
    [TestClass]
    public class TeamControllerTest
    {
        [TestMethod]
        public void TeamController_GetTeams_Valid()
        {
            var teamBlMock = new Mock<ITeamBL>();
            teamBlMock.Setup(t => t.Get()).Returns(new List<TeamDTO>());
            var teamController = new TeamController(teamBlMock.Object);
          
        }
    }
}
