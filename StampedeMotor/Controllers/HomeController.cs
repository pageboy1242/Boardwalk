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
        private ICarRepository _carRepository;

        public HomeController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public ActionResult Index()
        {
           List<Car> cars = _carRepository.GetAll();

            return View(cars);
        }
    }
}