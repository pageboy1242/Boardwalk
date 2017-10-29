using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StampedeMotor.Controllers;
using StampedeMotor.Models;
using StampedeMotor.Repositories;

namespace StampedeMotor.Tests.Controllers
{
    [TestClass]
    public class CarListControllerTest
    {
        [TestMethod]
        public void CarListController_TestAddCarValidation()
        {
            var carRepositoryMock = new Mock<ICarRepository>();
            var makeRepositoryMock = new Mock<IMakeRepository>();
            var carModelRepositoryMock = new Mock<ICarModelRepository>();

            var controller = new CarListController(carRepositoryMock.Object, makeRepositoryMock.Object, carModelRepositoryMock.Object);

            CarViewModel carVM = new CarViewModel();
            
            controller.AddCar(carVM, "Create", null);

            var context = new ValidationContext(carVM, null, null);
            var results = new List<ValidationResult>();

            var isModelStateValid = Validator.TryValidateObject(carVM, context, results, true);

            Assert.IsFalse(isModelStateValid);  // Car View Model has required fields missing, so model state is invalid
        }
    }
}
