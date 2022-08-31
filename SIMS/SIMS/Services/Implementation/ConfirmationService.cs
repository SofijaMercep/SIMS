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
    public class ConfirmationService : IConfirmationService
    {
        IConfrimationRepository confrimationRepository;

        public ConfirmationService(IConfrimationRepository confrimationRepository)
        {
            this.confrimationRepository = confrimationRepository;
        }

        public bool Confirm(User user, Drug drug)
        {
            Confirmation confirmation = new Confirmation();
            confirmation.UserJmbg = user.Jmbg;
            confirmation.pharmacistConfirmed = user.Role.Equals(UserRole.Farmaceut);
            confirmation.drugId = drug.ID;
                
            confrimationRepository.Add(confirmation);

            var confirmations = GetAll().Where(c => c.drugId == drug.ID).ToList();

            int acceptedByPharmacists = 0;
            int acceptedByDoctors = 0;
            confirmations.ForEach(c =>
            {
                if (c.pharmacistConfirmed)
                {
                    acceptedByPharmacists++;
                } else
                {
                    acceptedByDoctors++;
                }
            });

            return acceptedByPharmacists >= 2 && acceptedByDoctors >= 1;
        }

        public void DeleteAll(Drug drug)
        {
            GetAll().ForEach(c =>
            {
                if (c.drugId.Equals(drug.ID))
                {
                    confrimationRepository.Delete(c);
                }
            });
        }

        public List<Confirmation> GetAll()
        {
            return confrimationRepository.GetAll();
        }

        public List<Confirmation> GetByUser(User user)
        {
            return GetAll().Where(c => c.UserJmbg.Equals(user.Jmbg)).ToList();
        }

        public Confirmation GetByUserAndMedicine(User user, Drug drug)
        {
            return GetAll().Where(c => c.UserJmbg.Equals(user.Jmbg) && c.drugId == drug.ID).FirstOrDefault();
        }

        public void DeleteConfirmation(User user, Drug drug)
        {
            var confirmation = GetAll().Where(c => c.UserJmbg.Equals(user.Jmbg) && c.drugId == drug.ID).FirstOrDefault();
            confrimationRepository.Delete(confirmation);
        }
    }
}
