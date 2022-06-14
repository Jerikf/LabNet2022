using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.EF.Entities
{
    public class CustomersOrders
    {
        Customers customer;
        Orders order;

        public CustomersOrders(Customers customer, Orders order)
        {
            this.customer = customer;
            this.order = order;
        }

        public Customers Customer { get => customer; set => customer = value; }
        public Orders Order { get => order; set => order = value; }
    }
}
