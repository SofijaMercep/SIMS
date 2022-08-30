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
    public class DrugService : IDrugService
    {
        private readonly IDrugRepository drugRepository;

        public DrugService(IDrugRepository drugRepository)
        {
            this.drugRepository = drugRepository;
        }

        public List<Drug> GetAccepted()
        {
            return drugRepository.GetAll().Where(drug => !drug.Rejected && drug.Accepted).ToList();
        }

        public List<Drug> GetPending(User user)
        {
            List<Drug> drugs = drugRepository.GetAll().Where(drug => !drug.Rejected && !drug.Accepted).ToList();
            drugs.ForEach(drug =>
            {
                //var acceptance = acceptanceService.GetAcceptanceByUserIdAndMedicineId(user.JMBG, medicine.Id);
                //drug.Accepted = acceptance != null;
            });

            return drugs;
        }

        public List<Drug> GetRejected()
        {
            return drugRepository.GetAll().Where(drug => drug.Rejected).ToList();
        }
        public List<Drug> Filter(string property, string text, bool onlyAccpted)
        {

            if (property.Equals("sifra"))
            {
                if (onlyAccpted == true)
                {
                    return GetAccepted().Where(drug => drug.ID.ToString().Contains(text)).ToList();
                } else
                {
                    return GetRejected().Where(drug => drug.ID.ToString().Contains(text)).ToList();
                }
            }
            else if (property.Equals("naziv"))
            {
                if (onlyAccpted)
                {
                    return GetAccepted().Where(drug => drug.Name.ToLower().Contains(text)).ToList();
                }
                else
                {
                    return GetRejected().Where(drug => drug.Name.ToLower().Contains(text)).ToList();
                }
            } else if (property.Equals("proizvodjac"))
            {
                if (onlyAccpted)
                {
                    return GetAccepted().Where(medicine => medicine.Producer.ToLower().Contains(text)).ToList();
                }
                  else
                {
                    return GetRejected().Where(medicine => medicine.Producer.ToLower().Contains(text)).ToList();
                }
            } else if (property.Equals("cena"))
            {
                var splittedString = text.Split(',');
                if (splittedString.Length != 2)
                {
                    try
                    {   
                        if (onlyAccpted)
                        {
                            return GetAccepted().Where(drug => int.Parse(splittedString[0]) <= drug.Price && drug.Price <= int.Parse(splittedString[1])).ToList();
                        } else
                        {
                            return GetRejected().Where(drug => int.Parse(splittedString[0]) <= drug.Price && drug.Price <= int.Parse(splittedString[1])).ToList();
                        }
                    }   
                    catch
                    {
                        if (onlyAccpted)
                        {
                            return GetAccepted();
                        }
                        else { 
                            return GetRejected();
                        }
                    }   

                }
                if (onlyAccpted)
                {
                    return GetAccepted();
                } else
                {
                    return GetRejected();
                }
            } else if (property.Equals("kolicina"))
            {
                if (onlyAccpted)
                {
                    return GetAccepted().Where(drug => drug.AvailableQuantity.ToString().Equals(text)).ToList();
                } else
                {
                    return GetRejected().Where(drug => drug.AvailableQuantity.ToString().Equals(text)).ToList();
                }
            } else if (property.Equals("sastojci"))
            {
                
            }
                
            return GetRejected();
            
        }

        public void Add(Drug drug)
        {
            drugRepository.Add(drug);
        }

        public void IncreaseStock(int id, int quantity)
        {
            Drug drug = drugRepository.GetAll().Where(drug => drug.ID == id).First();
            drug.AvailableQuantity = quantity;
            drugRepository.Update(drug);
        }

        public bool Accept(Drug drug, User user)
        {
            throw new NotImplementedException();
        }

        public void Reject(int id, string reason, string name)
        {
            var drug = drugRepository.GetAll().Where(drug => drug.ID == id).First();
            drug.Rejected = true;
            drug.Accepted = false;
            drug.ReasonForRejection = reason;
            drug.PersonWhoRejected = name;

            drugRepository.Update(drug);

            //acceptanceService.DeleteAllAcceptancesForMedicine(medicineId);
        }

        public void DeleteRefusedFlag (int id, User user)
        {
            var drug = drugRepository.GetAll().Where(drug => drug.ID == id).First();
            drug.Rejected = false;
            drug.PersonWhoRejected = "";
            drug.ReasonForRejection = "";

            //acceptanceService.AcceptMedicineByUser(user.JMBG, medicineId, user.Role == UserRole.Lekar);
        }

        public void DeleteAcceptedFlag(User user, Drug drug)
        {
            throw new NotImplementedException();
        }
    }
}
