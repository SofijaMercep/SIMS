using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Models
{
    public class User
    {
        public string Jmbg{ get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public UserRole Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool Blocked { get; set; }
    }
}
