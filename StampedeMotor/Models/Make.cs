using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace StampedeMotor.Models
{
    public class Make
    {
        private int _id;
        private string _makeName;

        public Make(int id, string name)
        {
            _id = id > 0 ? id : throw new ArgumentOutOfRangeException();
            MakeName = name;
        }

        public int Id
        {
            get => _id;
        }

        public string MakeName
        {
            get => _makeName;
            set => _makeName = value;
        }
    }
}