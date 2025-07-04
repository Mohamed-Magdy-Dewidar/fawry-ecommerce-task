using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce_Fawry_Task.CartModule;
using Ecommerce_Fawry_Task.CustomerModule;

namespace Ecommerce_Fawry_Task.ServiceAbstractions
{
    public interface ICheckOutService
    {
        public void Checkout(Customer customer, CustomerCart cart);
    }
}
