using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce_Fawry_Task.CartModule;
using Ecommerce_Fawry_Task.ServiceAbstractions;

namespace Ecommerce_Fawry_Task.Services
{
    public class ReceiptPrinterService : IReceiptPrinterService
    {
        public void PrintReceipt(ICollection<CartItem> items, decimal subtotal, decimal shipping, decimal total, decimal remainingBalance)
        {
            Console.WriteLine("\n** Checkout receipt **");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Quantity}x {item.product.Name,-12} {item.product.Price * item.Quantity}");
            }
            Console.WriteLine("----------------------");
            Console.WriteLine($"Subtotal         {subtotal}");
            Console.WriteLine($"Shipping         {shipping}");
            Console.WriteLine($"Amount           {total}");
            Console.WriteLine($"Balance left     {remainingBalance}");
        }
    }
}
