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
        private readonly CarModelRepository _carModelRepository;

        public ModelRepositoryTest()
        {
            _carModelRepository = new CarModelRepository();
        }

        [TestInitialize]
        public void Setup()
        {

        }

        [TestMethod]
        public void ModelRepository_TestAdd()
        {
            var carModelVM = new CarModelViewModel("500");

            var carModel = _carModelRepository.Add(carModelVM);

            Assert.IsTrue(carModel.Id > 0);
        }

        [TestMethod]
        public void ModelRepository_TestGetAll()
        {
            var carModelVM = new CarModelViewModel("Test CarModel");

            _carModelRepository.Add(carModelVM);

            var makes = _carModelRepository.GetAll();

            Assert.IsTrue(makes.Count > 0);
        }

        [TestMethod]
        public void ModelRepository_TestDelete()
        {
            var carModelVM = new CarModelViewModel("Test CarModel");

            var newCarModel = _carModelRepository.Add(carModelVM);
            
            var rowsAffected = _carModelRepository.Delete(newCarModel);

            Assert.IsTrue(rowsAffected == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModelRepository_TestAddWithNullArgument()
        {
            _carModelRepository.Add(null);

            Assert.Fail("Shouldn't get to this line.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModelRepository_TestDeleteWithNullArgument()
        {
            _carModelRepository.Delete(null);

            Assert.Fail("Shouldn't get to this line.");
        }

        /// <summary>
        /// Called after every test
        /// </summary>
        [TestCleanup]
        public void TearDown()
        {
            //var models = _carModelRepository.GetAll();

            //foreach (var carModel in models)
            //{
            //     _carModelRepository.Delete(carModel);
            //}
        }
    }
}
