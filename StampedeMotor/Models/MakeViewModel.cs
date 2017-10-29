using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace StampedeMotor.Models
{
    public class MakeViewModel
    {
        private string _makeName;

        public MakeViewModel(string makeName)
        {
            MakeName = makeName;
        }

        [Required]
        public string MakeName
        {
            get => _makeName;
            set => _makeName = value.IsNullOrWhiteSpace() ? throw new ArgumentNullException() : value;
        }
    }
}