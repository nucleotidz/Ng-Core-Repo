using CORE.NG.DATA.Repository;
using CORE.NG.MODELS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NG.CORE.BUSINESS;
using System;
using System.Collections.Generic;

namespace NG.CORE.BUSINESSTest
{
    [TestClass]
    public class TeamBLTest
    {


        [TestMethod]
        public void TeamBL_Get()
        {
            var teamBlMock = new Mock<ITeamRepository>();
            teamBlMock.Setup(t => t.Get()).Returns(new List<TeamDTO>());
            var teamBLObj = new TeamBL(teamBlMock.Object);
            var results = teamBLObj.Get();
            Assert.IsNotNull(results);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TeamBL_Get_WithException()
        {
            var teamBlMock = new Mock<ITeamRepository>();
            teamBlMock.Setup(t => t.Get()).Throws(new Exception("Test Exception!!"));
            var teamBLObj = new TeamBL(teamBlMock.Object);
            var results = teamBLObj.Get();
        }


    }
}
