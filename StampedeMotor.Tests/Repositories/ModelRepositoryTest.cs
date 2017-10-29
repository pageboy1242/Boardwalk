using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StampedeMotor.Models;
using StampedeMotor.Repositories;

namespace StampedeMotor.Tests.Repositories
{
    [TestClass]
    public class ModelRepositoryTest
    {
        private readonly CarModelRepository _carModelRepository;
        private List<CarModel> _testCarModels;

        public ModelRepositoryTest()
        {
            _carModelRepository = new CarModelRepository();
            _testCarModels = new List<CarModel>();
        }

        [TestInitialize]
        public void Setup()
        {

        }

        [TestMethod]
        public void ModelRepository_TestAdd()
        {
            var carModelVm = new CarModelViewModel("Test CarModel");

            var carModel = _carModelRepository.Add(carModelVm);
            _testCarModels.Add(carModel);

            Assert.IsTrue(carModel.Id > 0);
        }

        [TestMethod]
        public void ModelRepository_TestGetAll()
        {
            var carModelVm = new CarModelViewModel("Test CarModel");

            var carModel = _carModelRepository.Add(carModelVm);
            _testCarModels.Add(carModel);

            var makes = _carModelRepository.GetAll();

            Assert.IsTrue(makes.Count > 0);
        }

        [TestMethod]
        public void ModelRepository_TestDelete()
        {
            var carModelVm = new CarModelViewModel("Test CarModel");

            var newCarModel = _carModelRepository.Add(carModelVm);
            
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
            foreach (var carModel in _testCarModels)
            {
                if(carModel != null)
                    _carModelRepository.Delete(carModel);
            }
        }
    }
}
