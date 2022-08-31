using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Models
{
    public class Confirmation
    {
        public int drugId { get; set; }
        public string UserJmbg { get; set; }
        public bool pharmacistConfirmed { get; set; }
    }
}
