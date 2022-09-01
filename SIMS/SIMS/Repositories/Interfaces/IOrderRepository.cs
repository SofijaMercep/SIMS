using SIMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        void Add(Order order);
        void Delete(Order order);
    }
}
