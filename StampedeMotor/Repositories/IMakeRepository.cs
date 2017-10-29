using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StampedeMotor.Models;

namespace StampedeMotor.Repositories
{
    public interface IMakeRepository
    {
        void Add(Make make);
        int Delete(Make make);
        List<Make> GetAll();
        Make Find(int id);
    }
}
