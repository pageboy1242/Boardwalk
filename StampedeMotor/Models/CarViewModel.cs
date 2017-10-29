using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StampedeMotor.Repositories;

namespace StampedeMotor.Models
{
    public class CarViewModel
    {
        public CarViewModel()
        {
        }
        [Required]
        public IEnumerable<SelectListItem> Makes
        {
            get {
                var makeRepository = new MakeRepository();
                var makes = makeRepository.GetAll().Select(a => new SelectListItem
                {
                    Text = a.MakeName,
                    Value = a.Id.ToString()
                });
                return makes;
            }
        }
        [Required]
        public int SelectedMakeId { get; set; }

        [Required]
        public IEnumerable<SelectListItem> Models
        {
            get
            {
                var modelRepository = new CarModelRepository();
                var models = modelRepository.GetAll().Select(a => new SelectListItem
                {
                    Text = a.ModelName,
                    Value = a.Id.ToString()
                });
                return models;
            }
        }
        [Required]
        public int SelectedModelId { get; set; }

        public byte[] ImgBytes = new byte[0];

        [Required]
        [StringLength(400)]
        public string Description { get; set; }

        [Range(1,100000)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}