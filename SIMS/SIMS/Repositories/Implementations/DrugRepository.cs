using SIMS.Models;
using SIMS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repositories.Implementations
{
    public class DrugRepository : IDrugRepository
    {
        private string file;

        public DrugRepository(string file)
        {
            this.file = file;
        }

        private void Save(List<Drug> drugs)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, drugs);
            stream.Close();
        }

        public List<Drug> GetAll()
        {

            if (File.Exists(file) == false)
            {
                using (File.Create(file)) ;
            }

            IFormatter formatter = new BinaryFormatter();
            using (var stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                List<Drug> drugs;
                try
                {
                    drugs = (List<Drug>)formatter.Deserialize(stream);
                }
                catch
                {
                    drugs = new List<Drug>();
                }

                return drugs;
            }

        }

        public void Add(Drug newDrug)
        {
            var drugs = GetAll();

            drugs.ForEach(drug =>
            {
                if (drug.ID == newDrug.ID)
                    throw new Exception();
            });

            drugs.Add(newDrug);
            Save(drugs);
        }

        public void Update(Drug drug)
        {
            var drugs = GetAll();

            drugs.ForEach(d =>
            {
                if (d.ID == drug.ID)
                {
                    d.Price = drug.Price;
                    d.AvailableQuantity = drug.AvailableQuantity;
                    d.Producer = drug.Producer;
                    d.Components = drug.Components;
                    d.PersonWhoRejected = drug.PersonWhoRejected;
                    d.ReasonForRejection = drug.ReasonForRejection;
                    d.Rejected = drug.Rejected;
                    d.Accepted = drug.Accepted;
                }
            });

            Save(drugs);
        }
    }
}
