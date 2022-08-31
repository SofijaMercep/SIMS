using SIMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Services.Interface
{
    public interface IConfirmationService
    {
        List<Confirmation> GetAll();
        List<Confirmation> GetByUser(User user);
        Confirmation GetByUserAndMedicine(User user, Drug drug);
        bool Confirm(User user, Drug drug);
        void DeleteConfirmation(User user, Drug drug);
        void DeleteAll(Drug drug);
    }
}
