using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Models
{
    [Serializable]
    public class Drug
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int AvailableQuantity { get; set; }
        public bool Accepted { get; set; }
        public bool Rejected { get; set; }
        public string PersonWhoRejected { get; set; }
        public string ReasonForRejection{ get; set; }
        public string Producer { get; set; }
        public Dictionary<string, DrugComponent> Components { get; set; }
    }
}
