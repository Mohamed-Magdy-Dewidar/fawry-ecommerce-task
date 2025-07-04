using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce_Fawry_Task.CartModule;
using Ecommerce_Fawry_Task.CustomerModule;
using Ecommerce_Fawry_Task.ProductModule;
using Ecommerce_Fawry_Task.ServiceAbstractions;
using Ecommerce_Fawry_Task.Shipping;

namespace Ecommerce_Fawry_Task.Services
{
    public class CheckoutService : ICheckOutService
    {
        private readonly IShippingService _shippingService;
        private readonly IReceiptPrinterService _receiptPrinter;

        public CheckoutService(IShippingService shippingService, IReceiptPrinterService receiptPrinter)
        {
            _shippingService = shippingService;
            _receiptPrinter = receiptPrinter;
        }

        public void Checkout(Customer customer, CustomerCart cart)
        {
            if (cart == null || cart.Items.Count == 0)
                throw new Exception("Cart is empty");

            decimal subtotal = 0;
            var shippableItems = new List<IShippable>();

            foreach (var item in cart.Items)
            {
                var product = item.product;

                if (product.IsExpired())
                    throw new Exception($"{product.Name} is expired");

                if (item.Quantity > product.Quantity)
                    throw new Exception($"{product.Name} is out of stock");

                subtotal += product.Price * item.Quantity;

                if (product is IShippable shippable)
                {
                    Console.WriteLine($"{product.Name} is shippable.");
                    for (int i = 0; i < item.Quantity; i++)
                        shippableItems.Add(shippable);
                }
                else
                {
                    Console.WriteLine($"{product.Name} is not shippable.");
                }
            }

            decimal shippingFee = _shippingService.CalculateShippingFee(shippableItems);
            decimal total = subtotal + shippingFee;

            if (customer.Balance < total)
                throw new Exception("Insufficient customer balance");

            customer.Balance -= total;

            foreach (var item in cart.Items)
            {
                item.product.Quantity -= item.Quantity;
            }

            if (shippableItems.Any())
                _shippingService.Ship(shippableItems);

            _receiptPrinter.PrintReceipt(cart.Items, subtotal, shippingFee, total, customer.Balance);
        }
    }
}
