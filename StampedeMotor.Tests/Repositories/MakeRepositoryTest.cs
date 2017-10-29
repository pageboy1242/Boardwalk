using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StampedeMotor.Models;
using StampedeMotor.Repositories;

namespace StampedeMotor.Tests.Repositories
{
    /// <summary>
    /// Integration Tests
    /// </summary>
    [TestClass]
    public class MakeRepositoryTest
    {
        private readonly MakeRepository _makeRepository;

        public MakeRepositoryTest()
        {
            _makeRepository = new MakeRepository();
        }

        [TestInitialize]
        public void Setup()
        {
            
        }

        [TestMethod]
        public void MakeRepository_TestAdd()
        {
            var makeVM = new MakeViewModel("Test Make");

            var newMake = _makeRepository.Add(makeVM);

            Assert.IsTrue(newMake.Id > 0);
        }

        [TestMethod]
        public void MakeRepository_TestGetAll()
        {
            var makeVM = new MakeViewModel("Test Make");

            _makeRepository.Add(makeVM);

            var makes = _makeRepository.GetAll();

            Assert.IsTrue(makes.Count > 0);
        }

        [TestMethod]
        public void MakeRepository_TestDelete()
        {
            var makeVM = new MakeViewModel("Test Make");

            var newMake = _makeRepository.Add(makeVM);

            var rowsAffected = _makeRepository.Delete(newMake);

            Assert.IsTrue(rowsAffected == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MakeRepository_TestAddWithNullArgument()
        {
            _makeRepository.Add(null);

            Assert.Fail("Shouldn't get to this line.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MakeRepository_TestDeleteWithNullArgument()
        {
            _makeRepository.Delete(null);

            Assert.Fail("Shouldn't get to this line.");
        }

        /// <summary>
        /// Called after every test
        /// </summary>
        [TestCleanup]
        public void TearDown()
        {
            //var makes = _makeRepository.GetAll();

            //foreach (var make in makes)
            //{
            //    _makeRepository.Delete(make);
            //}
        }
    }
}
