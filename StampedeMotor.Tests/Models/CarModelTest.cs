using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StampedeMotor.Models;

namespace StampedeMotor.Tests.Models
{
    [TestClass]
    public class CarModelTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CarModel_TestInvalidConstructorParams()
        {
            var carModel = new CarModel(0, "");

            Assert.Fail("Argument Exception expected.");
        }

        // Happy path
        [TestMethod]
        public void Make_VerifyConstructorAssignments()
        {
            var carModel = new CarModel(1, "Test Model");

            Assert.AreEqual(1, carModel.Id);
            Assert.AreEqual(carModel.ModelName, "Test Model");
        }
    }
}
