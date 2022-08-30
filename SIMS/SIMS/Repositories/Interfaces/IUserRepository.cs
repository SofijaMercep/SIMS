using SIMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<User> AllUsers();
        void Add(User user);
        void Update(User user);
    }
}
