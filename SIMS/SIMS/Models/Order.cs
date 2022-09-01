using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Models
{
    public class Order
    {
        public string Id { get; set; }
        public int Drug { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
    }
}
