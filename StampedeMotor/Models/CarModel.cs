using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StampedeMotor.Models
{
    public class CarModel
    {
        private int _id;
        private string _modelName;

        public CarModel(int id, string name)
        {
            _id = id > 0 ? id : throw new ArgumentOutOfRangeException();
            ModelName = name;
        }

        public int Id
        {
            get => _id;
        }

        public string ModelName
        {
            get => _modelName;
            set => _modelName = value;
        }
    }
}