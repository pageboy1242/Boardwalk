using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StampedeMotor.Models;

namespace StampedeMotor.Tests.Models
{
    /// <summary>
    /// Summary description for MakeTest
    /// </summary>
    [TestClass]
    public class MakeTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Make_TestInvalidConstructorParams()
        {
            var make = new Make(0, "");

            Assert.Fail("Argument Exception expected.");
        }

        // Happy path
        [TestMethod]
        public void Make_VerifyConstructorAssignments()
        {
            var make = new Make(1, "Test Make");

            Assert.AreEqual(1, make.Id);
            Assert.AreEqual(make.MakeName, "Test Make");
        }
    }
}
