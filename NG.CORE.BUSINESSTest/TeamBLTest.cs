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
       static Mock<ITeamRepository> mockRepository;
       static  TeamBL team;
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            mockRepository = new Mock<ITeamRepository>();
            team = new TeamBL(mockRepository.Object);
        }

        [TestMethod]
        public void TeamBL_Get()
        {
            mockRepository.Setup(t => t.Get()).Returns(new List<TeamDTO>());
            var results = team.Get();
            Assert.IsNotNull(results);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TeamBL_Get_WithException()
        {
            mockRepository.Setup(t => t.Get()).Throws(new Exception("Test Exception!!"));
            var results = team.Get();
        }


    }
}
