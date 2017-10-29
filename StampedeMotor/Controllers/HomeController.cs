using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StampedeMotor.Models;
using StampedeMotor.Repositories;

namespace StampedeMotor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CarRepository carRepository = new CarRepository();

            List<Car> cars = carRepository.GetAll();

            return View(cars);
        }
    }
}