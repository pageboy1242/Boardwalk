using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StampedeMotor.Models;

namespace StampedeMotor.Tests.Models
{
    [TestClass]
    public class CarTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Car_TestInvalidConstructorParams()
        {
            var car = new Car(null, null, null, "", 0.0m);

            Assert.Fail("Argument Exception expected.");
        }
    }
}
