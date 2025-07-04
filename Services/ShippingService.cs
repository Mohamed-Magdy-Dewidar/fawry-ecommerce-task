using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce_Fawry_Task.ServiceAbstractions;
using Ecommerce_Fawry_Task.Shipping;

namespace Ecommerce_Fawry_Task.Services
{
    class ShippingService : IShippingService
    {
        public void Ship(List<IShippable> items)
        {
            double totalWeight = items.Sum(i => i.GetWeight());

            Console.WriteLine("\n** Shipment notice **");
            foreach (var group in items.GroupBy(i => i.GetName()))
            {
                double groupWeight = group.Sum(i => i.GetWeight());
                Console.WriteLine($"{group.Count()}x {group.Key,-12} {groupWeight * 1000}g");
            }
            Console.WriteLine($"Total package weight {totalWeight:F1}kg\n");
        }

        public decimal CalculateShippingFee(List<IShippable> items)
        {
            double totalWeight = items.Sum(p => p.GetWeight());
            return (decimal)(totalWeight * 10); // 10 EGP per kg
        }
    }
}
