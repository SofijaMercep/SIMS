using SIMS.Models;
using SIMS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Controllers
{
    public class DrugComponentController
    {
        private readonly IDrugComponentService drugComponentService;

        public DrugComponentController(IDrugComponentService drugComponentService)
        {
            this.drugComponentService = drugComponentService;
        }

        public List<DrugComponent> GetAllComponents()
        {
            return drugComponentService.GetAll();
        }
    }
}
