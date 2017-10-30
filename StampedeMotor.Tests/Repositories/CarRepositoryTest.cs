using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StampedeMotor.Models;
using StampedeMotor.Repositories;

namespace StampedeMotor.Tests.Repositories
{
    /// <summary>
    /// Integration Tests
    /// </summary>
    [TestClass]
    public class CarRepositoryTest : RepositoryTestBase
    {
        private readonly CarRepository _carRepository;
        private MakeRepository _makeRepository;
        private CarModelRepository _carModelRepository;

        private List<Make> _testMakes;
        private List<CarModel> _testCarModels;
        private List<Car> _testCars;

        public CarRepositoryTest()
        {
            _carRepository = new CarRepository();
            _makeRepository = new MakeRepository();
            _carModelRepository = new CarModelRepository();

            _testMakes = new List<Make>();
            _testCarModels = new List<CarModel>();
            _testCars = new List<Car>();
        }

        [TestMethod]
        [DeploymentItem(@"Repositories")]
        public void CarRepository_TestAdd()
        {
            var carRepository = new CarRepository();

            var dir = Directory.GetCurrentDirectory();
            Debug.WriteLine(dir);// Useful for debugging file path issues

            Image img = Image.FromFile(@"fiat-500.jpg");

            var converter = new ImageConverter();
            var imageByteArray = (byte[])converter.ConvertTo(img, typeof(byte[]));

            var makeVM = new MakeViewModel("Test Make");
            var makeRepository = new MakeRepository();
            var make = makeRepository.Add(makeVM);
            _testMakes.Add(make);

            var carModelVM = new CarModelViewModel("Test CarModel");
            var modelRepository = new CarModelRepository();
            var carModel = modelRepository.Add(carModelVM);
            _testCarModels.Add(carModel);

            var car = new Car(make, carModel, imageByteArray, "Test Car", 1000.00m);

            carRepository.Add(car);
            _testCars.Add(car);
        }

        [TestMethod]
        public void CarRepository_TestGetAll()
        {
            var carRepository = new CarRepository();

            var cars = carRepository.GetAll();

            Assert.IsTrue(cars.Count > 0);
        }

        [TestCleanup]
        public void TearDown()
        {
            foreach (var car in _testCars)
            {
                if (car != null)
                {
                    _carRepository.Delete(car);
                }
            }

            foreach (var make in _testMakes)
            {
                if (make != null)
                {
                    _makeRepository.Delete(make);
                }
            }

            foreach (var carModel in _testCarModels)
            {
                if (carModel != null)
                {
                    _carModelRepository.Delete(carModel);
                }
            }
        }
    }
}
