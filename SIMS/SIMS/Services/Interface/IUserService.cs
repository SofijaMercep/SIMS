using SIMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Services.Interface
{
    public interface IUserService
    {
        User Login(string username, string password);
        List<User> GetAll();
        List<User> GetNonBlocked();
        void Add(User user);
        void Block(User user);
        void Unblock(User user);
    }
}
