using System;
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
    public class CarRepositoryTest
    {
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

            var carModelVM = new CarModelViewModel("Test CarModel");
            var modelRepository = new CarModelRepository();
            var carModel = modelRepository.Add(carModelVM);

            var car = new Car(make, carModel, imageByteArray, "Test Car", 1000.00m);

            carRepository.Add(car);
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
            
        }
    }
}
