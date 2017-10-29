using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StampedeMotor.Models;

namespace StampedeMotor.Repositories
{
    interface IModelRepository
    {
        void Add(Model model);
        int Delete(Model model);
        List<Model> GetAll();
        Model Find(int id);
    }
}
