using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StampedeMotor.Models;
using StampedeMotor.Repositories;

namespace StampedeMotor.Tests.Repositories
{
    [TestClass]
    public class ModelRepositoryTest
    {
        private readonly ModelRepository _modelRepository;

        public ModelRepositoryTest()
        {
            _modelRepository = new ModelRepository();
        }

        [TestInitialize]
        public void Setup()
        {

        }

        [TestMethod]
        public void ModelRepository_TestAdd()
        {
            var model = new Model("500");

            _modelRepository.Add(model);

            Assert.IsTrue(model.Id > 0);
        }

        [TestMethod]
        public void TestGetAll()
        {
            var model = new Model("Test Model");

            _modelRepository.Add(model);

            var makes = _modelRepository.GetAll();

            Assert.IsTrue(makes.Count > 0);
        }

        [TestMethod]
        public void TestDelete()
        {
            var make = new Model("Test Model");

            _modelRepository.Add(make);

            var makes = _modelRepository.GetAll();

            Assert.IsTrue(makes.Count > 0);

            var rowsAffected = _modelRepository.Delete(makes.FirstOrDefault());

            Assert.IsTrue(rowsAffected == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddWithNullArgument()
        {
            _modelRepository.Add(null);

            Assert.Fail("Shouldn't get to this line.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestDeleteWithNullArgument()
        {
            _modelRepository.Delete(null);

            Assert.Fail("Shouldn't get to this line.");
        }

        /// <summary>
        /// Called after every test
        /// </summary>
        [TestCleanup]
        public void TearDown()
        {
            //var models = _modelRepository.GetAll();

            //foreach (var model in models)
            //{
            //     _modelRepository.Delete(model);
            //}
        }
    }
}
