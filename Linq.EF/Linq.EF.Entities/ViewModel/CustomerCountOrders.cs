using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.EF.Entities.ViewModel
{
    public class CustomerCountOrders
    {
        
        public Customers Customers { get; set; }
        public int CountOrders { get; set; }
        public CustomerCountOrders(Customers customers, int countOrders)
        {
            Customers = customers;
            CountOrders = countOrders;
        }

        
    }
}
