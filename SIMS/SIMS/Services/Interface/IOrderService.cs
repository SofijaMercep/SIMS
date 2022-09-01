using SIMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Services.Interface
{
    public interface IOrderService
    {
        void IncreaseQuantitiesForOrders();
        void CreateOrder(Order order);
    }
}
