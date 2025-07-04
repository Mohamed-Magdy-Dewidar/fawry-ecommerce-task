using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce_Fawry_Task.CartModule;

namespace Ecommerce_Fawry_Task.CustomerModule
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Balance { get; set; }

        public CustomerCart Cart { get; set; } = new CustomerCart();
    
 
    }

}
