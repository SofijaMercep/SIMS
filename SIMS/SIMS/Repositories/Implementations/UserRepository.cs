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
    
    public class UserRepository : IUserRepository
    {
        private string file;

        public UserRepository(string file)
        {
            this.file = file;
        }

        private void SaveInFile(List<User> users)
        {

            using (StreamWriter sw = new StreamWriter(file, false))
            {
                sw.Write("");
            }

            using (StreamWriter sw = new StreamWriter(file, true))
            {

                users.ForEach(modifiedUser => {
                    string textualRepresentation = String.Format("{0}|{1}|{2}|{3}|{4}|{5}{6}|{7}", modifiedUser.Jmbg, modifiedUser.Name,
                        modifiedUser.LastName, modifiedUser.Role, modifiedUser.Email, modifiedUser.Password, modifiedUser.PhoneNumber, modifiedUser.Blocked);

                    sw.WriteLine(textualRepresentation);
                });
            }

        }

        public List<User> AllUsers()
        {
            if (!File.Exists(file))
            {
                using (File.Create(file)) ;
            }

            var users = new List<User>();

            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var parts = line.Split("|");

                    var user = new User();
                    user.Jmbg = parts[0];
                    user.Name = parts[1];
                    user.LastName = parts[2];
                    user.Role = (UserRole)Enum.Parse(typeof(UserRole), parts[3]);
                    user.Email = parts[4];
                    user.Password = parts[5];
                    user.PhoneNumber = parts[6];
                    user.Blocked = bool.Parse(parts[7]);

                    users.Add(user);
                }

            }

            return users;
        }

        public void Add(User newUser)
        {
            var users = AllUsers();

            users.ForEach(user =>
            {
                if (user.Jmbg == newUser.Jmbg || user.Email.Equals(newUser.Email))
                    throw new Exception();
            });

            users.Add(newUser);
            SaveInFile(users);
        }

        public void Update(User user)
        {
            var users = AllUsers();
            foreach (User u in users)
            {
                if (u.Jmbg.Equals(user.Jmbg))
                {
                    u.Name = user.Name;
                    u.LastName = user.LastName;
                    u.Role = user.Role;
                    u.PhoneNumber = user.PhoneNumber;
                    u.Blocked = user.Blocked;
                }
            }

            SaveInFile(users);
        }
    }
}
