using System.Collections.Generic;
using StampedeMotor.Models;

namespace StampedeMotor.Repositories
{
    public interface ICarModelRepository
    {
        CarModel Add(CarModelViewModel carModelViewModel);
        int Delete(CarModel carModel);
        List<CarModel> GetAll();
        CarModel Find(int id);
    }
}
