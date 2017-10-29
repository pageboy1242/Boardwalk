using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace StampedeMotor.Models
{
    public class CarModelViewModel
    {
        private string _modelName;

        public CarModelViewModel(string modelName)
        {
            ModelName = modelName;
        }

        [Required]
        public string ModelName
        {
            get => _modelName;
            set => _modelName = value;
        }
    }
}