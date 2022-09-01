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
    public class DrugComponentRepository : IDrugComponentRepository
    {
        private readonly string file;

        public DrugComponentRepository(string file)
        {
            this.file = file;
        }

        public List<DrugComponent> GetAll()
        {
            if (!File.Exists(file))
            {
                using (File.Create(file)) ;
            }

            var drugComponents = new List<DrugComponent>();

            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var drugComponent = new DrugComponent();
                    var properties = line.Split("|");
                    var name = properties[0];
                    var description = properties[1];

                    drugComponent.Name = name;
                    drugComponent.Description = description;
                    drugComponents.Add(drugComponent);
                }

            }

            return drugComponents;
        }
    }
}
