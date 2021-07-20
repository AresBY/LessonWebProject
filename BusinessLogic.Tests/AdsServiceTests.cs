using LessonWebProject.BusinessLogic.Implementations;
using LessonWebProject.BusinessLogic.Models;
using LessonWebProject.Data.Implementations.Repository;
using LessonWebProject.Data.Interfaces.Repository;
using LessonWebProject.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;


namespace LessonWebProject.BusinessLogic.Tests
{
    [TestClass]
    public class AdsServiceTests
    {
        private readonly AdsService _adsService;
        private readonly Mock<IAdsRepository> _adsRepoMock = new Mock<IAdsRepository>();
        public AdsServiceTests()
        {
            _adsService = new AdsService(_adsRepoMock.Object);
        }
        [TestMethod]
        public void GetAdsByTaskID_ShouldReturnAds_WhenExists()
        {
            //Arrange
            var taskID = 3;
            var dbo = new List<AdDBModel>()
            {
                 new AdDBModel(){ TaskID = 3, Description = "TestDescription3"},
                 new AdDBModel(){ TaskID = 3, Description = "TestDescription4"}
            };
            _adsRepoMock.Setup(x => x.GetAdsByIdTask(taskID)).Returns(dbo);


            IEnumerable<AdModel> expected = new List<AdModel>()
            {
                 new AdModel(){ TaskID = 3, Description = "TestDescription3"},
                 new AdModel(){ TaskID = 3, Description = "TestDescription4"}
            };

            ////Act
            IEnumerable<AdModel> actual = _adsService.GetAdsByTaskID(taskID);

            ////Assert
            Assert.AreEqual(expected.Count(), actual.Count());
        }
    }
}
