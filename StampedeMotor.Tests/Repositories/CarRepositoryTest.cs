﻿using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StampedeMotor.Models;
using StampedeMotor.Repositories;

namespace StampedeMotor.Tests.Repositories
{
    [TestClass]
    public class CarRepositoryTest
    {
        [TestMethod]
        public void TestAdd()
        {
            var carRepository = new CarRepository();
            Image img = Image.FromFile("C:\\Boardwalk-Quadrus\\StampedeMotor.Tests\\Repositories\\aston-martin.jpg");

            var converter = new ImageConverter();
            var imageByteArray = (byte[])converter.ConvertTo(img, typeof(byte[]));

            var make = new Make("Test Make");
            var makeRepository = new MakeRepository();
            makeRepository.Add(make);

            var model = new Model("Test Model");
            var modelRepository = new ModelRepository();
            modelRepository.Add(model);

            var car = new Car(make, model, imageByteArray, "Test Car", 1000.00m);

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