using SIMS.Models;
using SIMS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Controllers
{
    public class DrugController
    {
        private readonly IDrugService drugService;

        public DrugController(IDrugService drugService)
        {
            this.drugService = drugService;
        }

        public List<Drug> GetAllAccepted()
        {
            return drugService.GetAccepted();
        }

        public List<Drug> GetPending(User user)
        {
            return drugService.GetPending(user);
        }

        public List<Drug> GetRejected()
        {
            return drugService.GetRejected();
        }

        public List<Drug> FilterDrugs(string searchBy, string searchText, bool flag)
        {
            return drugService.Filter(searchBy, searchText, flag);
        }
        public void Add(Drug drug)
        {
            drugService.Add(drug);
        }

        public void IncreaseStock(int id, int quantity)
        {
            drugService.IncreaseStock(id, quantity);
        }

        public bool Accept(Drug drug, User user)
        {
            return drugService.Accept(drug, user);
        }

        public void RemoveAcceptedFlag(User user, Drug drug)
        {
            drugService.DeleteAcceptedFlag(user, drug);
        }

        public void Reject(int medicineId, string reason, string name)
        {
            drugService.Reject(medicineId, reason, name);
        }

        public void RemoveRefusedFlag(int medicineId, User user)
        {
            drugService.DeleteRefusedFlag(medicineId, user);
        }
    }
}
