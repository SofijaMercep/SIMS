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
    public class OrderRepository : IOrderRepository
    {
        private string file;

        public OrderRepository(string file)
        {
            this.file = file;
        }

        public void Save(List<Order> orders)
        {
            using (StreamWriter sw = new StreamWriter(file, false))
            {
                sw.Write("");
            }

            using (StreamWriter sw = new StreamWriter(file, true))
            {
                orders.ForEach(order =>
                {
                    sw.WriteLine(String.Format("{0}|{1}|{2}|{3}", order.Id, order.Drug, order.Quantity, order.Date));
                });
            }
        }

        public List<Order> GetAll()
        {
            if (!File.Exists(file))
            {
                using (File.Create(file)) ;
            }

            var orders = new List<Order>();

            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var order = new Order();
                    var properties = line.Split("|");
                    order.Id = properties[0];
                    order.Drug = int.Parse(properties[1]);
                    order.Quantity = int.Parse(properties[2]);
                    order.Date = DateTime.Parse(properties[3]);

                    orders.Add(order);
                }

            }

            return orders;
        }

        public void Add(Order order)
        {
            order.Date = DateTime.Now;
            order.Id = Guid.NewGuid().ToString();
            var orders = GetAll();
            orders.Add(order);
            Save(orders);
        }

        public void Delete(Order order)
        {
            var orders = GetAll();
            orders = orders.Where(o => !o.Id.Equals(order.Id)).ToList();
            Save(orders);
        }
    }
}
