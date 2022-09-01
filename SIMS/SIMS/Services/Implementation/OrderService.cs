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
    public class OrderService : IOrderService
    {
        private IOrderRepository orderRepository;
        private IDrugService drugService;

        public OrderService(IOrderRepository orderRepository, IDrugService drugService)
        {
            this.orderRepository = orderRepository;
            this.drugService = drugService;
        }

        public void CreateOrder(Order order)
        {
            orderRepository.Add(order);
        }

        public void IncreaseQuantitiesForOrders()
        {
            var orders = orderRepository.GetAll().Where(o => o.Date <= DateTime.Now).ToList();

            orders.ForEach(order =>
            {
                orderRepository.Delete(order);
                drugService.IncreaseStock(order.Drug, order.Quantity);
            });
        }
    }
}
