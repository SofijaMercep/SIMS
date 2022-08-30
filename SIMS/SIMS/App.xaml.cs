using SIMS.Controllers;
using SIMS.Repositories.Implementations;
using SIMS.Repositories.Interfaces;
using SIMS.Services.Implementation;
using SIMS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SIMS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    { 

        public UserController UserController { get; set; }
        public DrugController DrugController { get; set; }

        public App()
        {
            IUserRepository userRepository = new UserRepository("user.txt");
            IUserService userService = new UserService(userRepository);
            UserController = new UserController(userService);

            IDrugRepository drugRepository = new DrugRepository("drugs.bin");
            IDrugService drugService = new DrugService(drugRepository);
            DrugController = new DrugController(drugService);

        }

    }
}
