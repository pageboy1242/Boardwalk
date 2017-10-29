using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace StampedeMotor.Models
{
    public class Car
    {
        public Car(Make make, Model model, byte[] image, string description, decimal price)
        {
            Make = make ?? throw new ArgumentNullException();
            Model = model ?? throw new ArgumentNullException();
            Image = image;
            Description = description;
            Price = price;
        }

        public int Id { get; set; }

        public Make Make { get; set; }

        public Model Model { get; set; }

        public byte[] Image { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}