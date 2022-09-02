using SIMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Services.Interface
{
    public interface IDrugService
    {
        List<Drug> GetAccepted();
        List<Drug> GetPending(User user);
        List<Drug> GetRejected();
        List<Drug> Filter(string property, string text, bool onlyAccepted);
        void Add(Drug drug);
        bool Accept(Drug drug, User user);
        void DeleteAcceptedFlag(User user, Drug drug);
        void Reject(int id, string reason, string rejectedBy);
        void DeleteRefusedFlag(int id, User user);
        void IncreaseStock(int id, int quantity);
        
    }
}
