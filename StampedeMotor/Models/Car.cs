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
            Image = image ?? throw new ArgumentNullException();
            Description = description ?? throw new ArgumentNullException();
            Price = price <= 0 ? throw new ArgumentOutOfRangeException() : price;
        }

        public int Id { get; set; }

        public Make Make { get; }

        public Model Model { get; }

        public byte[] Image { get; }

        public string Description { get; }

        public decimal Price { get; }
    }
}