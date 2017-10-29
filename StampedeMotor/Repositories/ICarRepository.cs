using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StampedeMotor.Models;

namespace StampedeMotor.Repositories
{
    public interface ICarRepository
    {
        List<Car> GetAll();
        void Add(Car car);
        int Delete(Car car);
        void Update(Car car);
    }
}
