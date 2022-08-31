using SIMS.Models;
using SIMS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repositories.Implementations
{
    public class ConfirmationRepository : IConfrimationRepository
    {
        private string file;

        public ConfirmationRepository(string file)
        {
            this.file = file;
        }

        public void Save(List<Confirmation> confirmations)
        {
            using (StreamWriter sw = new StreamWriter(file, false))
            {
                sw.Write("");
            }

            using (StreamWriter sw = new StreamWriter(file, true))
            {
                confirmations.ForEach(c =>
                {
                    sw.WriteLine(c.UserJmbg + "|" + c.drugId + "|" + c.pharmacistConfirmed);
                });
            }
        }

        public List<Confirmation> GetAll()
        {
            if (!File.Exists(file))
            {
                using (File.Create(file)) ;
            }

            var confirmations = new List<Confirmation>();
            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var confirmation = new Confirmation();
                    var properties = line.Split("|");
                    confirmation.UserJmbg = properties[0];
                    confirmation.drugId = int.Parse(properties[1]);
                    confirmation.pharmacistConfirmed = bool.Parse(properties[2]);
                    confirmations.Add(confirmation);
                }
            }

            return confirmations;
        }

        public void Add(Confirmation confirmation)
        {
            var confirmations = GetAll();
            confirmations.Add(confirmation);
            Save(confirmations);
        }

        public void Delete(Confirmation confirmation)
        {
            var confirmations = GetAll();
            confirmations = confirmations.Where(c => c.UserJmbg.Equals(confirmation.UserJmbg) == false && c.drugId != confirmation.drugId).ToList();
            Save(confirmations);
        }
    }
}
