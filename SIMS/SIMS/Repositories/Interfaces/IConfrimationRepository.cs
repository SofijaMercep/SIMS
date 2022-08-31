using SIMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repositories.Interfaces
{
    public interface IConfrimationRepository
    {
        List<Confirmation> GetAll();
        void Add(Confirmation confirmation);
        void Delete(Confirmation confirmation);
    }
}
