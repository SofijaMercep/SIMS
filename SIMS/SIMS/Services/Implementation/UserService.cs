using SIMS.Models;
using SIMS.Repositories.Interfaces;
using SIMS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Services.Implementation
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User Login(string email, string password)
        {
            var users = userRepository.AllUsers().Where(user => !user.Blocked).ToList();
            var user = users.FirstOrDefault(user => user.Email == email && user.Password == password);
            return user;
        }

        public List<User> GetAll()
        {
            return userRepository.AllUsers();
        }

        public List<User> GetNonBlocked()
        {
            return userRepository.AllUsers().Where(user => !user.Blocked).ToList();
        }

        public void Add(User user)
        {
            userRepository.Add(user);
        }

        public void Block(User user)
        {
            user.Blocked = true;
            userRepository.Update(user);
        }

        public void Unblock(User user)
        {
            user.Blocked = false;
            userRepository.Update(user);
        }
    }
}
