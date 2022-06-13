using Linq.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.EF.Logic
{
    public class CustomerLogic : BaseLogic
    {
        public Customers GetCustomerByID(string id)
        {
            return context.Customers.First(customer => customer.CustomerID == id);
        }

        public List<Customers> GetCustomersByRegionWA()
        {
            var query = from customer in context.Customers
                        where(customer.Region == "WA")
                        select customer;
            return query.ToList();
        }

        public List<String> GetCustomerName()
        {
            var query = from customer in context.Customers
                        select  customer.CompanyName;
            return query.ToList();
        }

        //POS : Devuelve la unión entre Customer y Orders, donde Customer sea de la region WA y Orders sea mayor a 1/1/1997
        public List<CustomersOrders> GetJoinCustomerAndOrders()
        {
            var query = from customer in context.Customers
                        join order in context.Orders
                        on customer.CustomerID equals order.CustomerID
                        where customer.Region == "WA" && DateTime.Compare((DateTime)order.OrderDate, new DateTime(1997, 1, 1)) > 0
                        select new CustomersOrders(customer,  order);
            return query.ToList();
        }
            
    }
}
