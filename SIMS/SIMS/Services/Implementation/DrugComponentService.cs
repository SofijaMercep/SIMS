using SIMS.Models;
using SIMS.Repositories.Interfaces;
using SIMS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Services.Implementation
{
    public class DrugComponentService : IDrugComponentService
    {
        private readonly IDrugComponentRepository drugComponentRepository;

        public DrugComponentService(IDrugComponentRepository drugComponentRepository)
        {
            this.drugComponentRepository = drugComponentRepository;
        }

        public List<DrugComponent> GetAll()
        {
            return drugComponentRepository.GetAll();
        }
    }
}
