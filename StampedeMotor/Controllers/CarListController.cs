using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using StampedeMotor.Models;
using StampedeMotor.Repositories;

namespace StampedeMotor.Controllers
{
    public class CarListController : Controller
    {
        private ICarRepository _carRepository;
        private IMakeRepository _makeRepository;
        private ICarModelRepository _carModelRepository;

        public CarListController(ICarRepository carRepository, IMakeRepository makeRepository, ICarModelRepository carModelRepository)
        {
            _carRepository = carRepository;
            _makeRepository = makeRepository;
            _carModelRepository = carModelRepository;
        }

        // GET: CarList REST API
        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult CarList()
        {
           List<Car> cars = _carRepository.GetAll();

            return Json(cars, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddCar()
        {
            var carViewModel = new CarViewModel();

            return View(carViewModel);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult AddCar(CarViewModel carViewModel, string Create, HttpPostedFileBase fileUpload)
        {
            if (!string.IsNullOrEmpty(Create))
            {
                if (fileUpload == null || fileUpload.ContentLength == 0)
                {
                    ModelState.AddModelError("ImgBytes", "Please select upload file");
                }

                if (ModelState.IsValid)
                {
                    if (fileUpload != null && fileUpload.ContentLength > 0)
                    {
                        using (var reader = new System.IO.BinaryReader(fileUpload.InputStream))
                        {
                            carViewModel.ImgBytes = reader.ReadBytes(fileUpload.ContentLength);
                        }
                    }

                    var make = _makeRepository.Find(carViewModel.SelectedMakeId);

                    var model = _carModelRepository.Find(carViewModel.SelectedModelId);

                    var car = new Car(make, model, carViewModel.ImgBytes, carViewModel.Description, carViewModel.Price);
                    
                    try
                    {
                        _carRepository.Add(car);
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", e.Message);
                        return View(carViewModel);
                    }
                    

                    return RedirectToAction("Index", "Home");
                }
            }

            return View(carViewModel);
        }
    }
}