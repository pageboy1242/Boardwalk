using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace StampedeMotor.Models
{
    public class Make
    {
        public Make(string name)
        {
            Id = 0;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}