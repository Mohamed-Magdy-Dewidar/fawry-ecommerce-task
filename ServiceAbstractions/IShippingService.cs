using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce_Fawry_Task.Shipping;

namespace Ecommerce_Fawry_Task.ServiceAbstractions
{
    public interface IShippingService
    {
        void Ship(List<IShippable> items);
        decimal CalculateShippingFee(List<IShippable> items);
    }
}
