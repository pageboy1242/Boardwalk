using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StampedeMotor.Models
{
    public class Model
    {
        public Model(string name)
        {
            Id = 0;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}