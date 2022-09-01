using SIMS.Models;
using SIMS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Controllers
{
    public class OrderController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public void IncreaseQuantitiesForOrders()
        {
            orderService.IncreaseQuantitiesForOrders();
        }

        public void CreateOrder(Order order)
        {
            orderService.CreateOrder(order);
        }
    }
}
