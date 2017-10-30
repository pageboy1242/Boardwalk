using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StampedeMotor.Models;
using StampedeMotor.Repositories;

namespace StampedeMotor.Tests.Repositories
{
    /// <summary>
    /// Integration Tests
    /// </summary>
    [TestClass]
    public class MakeRepositoryTest : RepositoryTestBase
    {
        private readonly MakeRepository _makeRepository;
        private List<Make> _testMakes;

        public MakeRepositoryTest()
        {
            _makeRepository = new MakeRepository();
            _testMakes = new List<Make>();
        }

        [TestInitialize]
        public void Setup()
        {
            
        }

        [TestMethod]
        public void MakeRepository_TestAdd()
        {
            var makeVm = new MakeViewModel("Test Make");
            
            var newMake = _makeRepository.Add(makeVm);
            _testMakes.Add(newMake);

            Assert.IsTrue(newMake.Id > 0);
        }

        [TestMethod]
        public void MakeRepository_TestGetAll()
        {
            var makeVm = new MakeViewModel("Test Make");

            var newMake = _makeRepository.Add(makeVm);
            _testMakes.Add(newMake);

            var makes = _makeRepository.GetAll();

            Assert.IsTrue(makes.Count > 0);
        }

        [TestMethod]
        public void MakeRepository_TestDelete()
        {
            var makeVm = new MakeViewModel("Test Make");

            var newMake = _makeRepository.Add(makeVm);

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
            foreach (var make in _testMakes)
            {
                if(make != null)
                {
                    _makeRepository.Delete(make);
                }
            }
        }
    }
}
