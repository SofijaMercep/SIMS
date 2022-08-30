using SIMS.Models;
using SIMS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Controllers
{
    public class UserController
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public User Login(string username, string password)
        {
            return userService.Login(username, password);
        }

        public List<User> GetAllUsers()
        {
            return userService.GetAll();
        }

        public void Save(User user)
        {
            userService.Add(user);
        }

        public void BlockUser(User user)
        {
            userService.Block(user);
        }

        public void UnblockUser(User user)
        {
            userService.Unblock(user);
        }
    }
}
