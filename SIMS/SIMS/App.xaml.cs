using SIMS.Controllers;
using SIMS.Models;
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
        public OrderController OrderController { get; set; }
        public DrugComponentController DrugComponentController { get; set; }
        public User LoggedUser { get; set; }

        public App()
        {
            IUserRepository userRepository = new UserRepository("user.txt");
            IUserService userService = new UserService(userRepository);
            UserController = new UserController(userService);

            IConfrimationRepository confrimationRepository = new ConfirmationRepository("confirmation.txt");
            IConfirmationService confirmationService = new ConfirmationService(confrimationRepository);

            IDrugRepository drugRepository = new DrugRepository("drugs.bin");
            IDrugService drugService = new DrugService(drugRepository, confirmationService);
            DrugController = new DrugController(drugService);

            IOrderRepository orderRepository = new OrderRepository("order.txt");
            IOrderService orderService = new OrderService(orderRepository, drugService);
            OrderController = new OrderController(orderService);

            IDrugComponentRepository drugComponentRepository = new DrugComponentRepository("drugComponent.txt");
            IDrugComponentService drugComponentService = new DrugComponentService(drugComponentRepository);
            DrugComponentController = new DrugComponentController(drugComponentService);

            //drugService.Add(new Drug()
            //{
            //    Accepted = false,
            //    AvailableQuantity = 0,
            //    Components = new Dictionary<string, DrugComponent>(),
            //    ID = 3,
            //    Name = "Neprihvacen",
            //    Price = 500,
            //    Producer = "west",
            //});
        }

    }
}
