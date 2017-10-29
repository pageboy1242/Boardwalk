using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StampedeMotor.Controllers;
using StampedeMotor.Repositories;

namespace StampedeMotor.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void HomeController_VerifyCallsGetAll()
        {
            // Arrange
            var repositoryMock = new Mock<ICarRepository>();

            var controller = new HomeController(repositoryMock.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            repositoryMock.Verify(m => m.GetAll());
            Assert.IsNotNull(result);
        }
    }
}
