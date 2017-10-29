using System.Collections.Generic;
using StampedeMotor.Models;

namespace StampedeMotor.Repositories
{
    public interface IModelRepository
    {
        void Add(Model model);
        int Delete(Model model);
        List<Model> GetAll();
        Model Find(int id);
    }
}
