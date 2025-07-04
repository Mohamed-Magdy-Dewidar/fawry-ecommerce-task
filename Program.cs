using Ecommerce_Fawry_Task.CustomerModule;
using Ecommerce_Fawry_Task.ProductModule;
using Ecommerce_Fawry_Task.ServiceAbstractions;
using Ecommerce_Fawry_Task.Services;
using Ecommerce_Fawry_Task.Shipping;

namespace Ecommerce_Fawry_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RunCheckoutScenario();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Checkout failed: {ex.Message}");
            }            
            Console.ReadKey();
        }

        private static void RunCheckoutScenario()
        {
            
            // Services
            IShippingService shippingService = new ShippingService();
            IReceiptPrinterService receiptPrinter = new ReceiptPrinterService();
            ICheckOutService checkoutService = new CheckoutService(shippingService, receiptPrinter);

            // Customer setup
            var customer = new Customer { Id = 1, Name = "Mohamed", Balance = 1000 };

            // Product definitions with Ids
            var cheese = new ExpirableProduct { Id = 1, Name = "Cheese", Price = 100, Quantity = 5, ExpiryDate = DateTime.Now.AddDays(2) };
            var biscuits = new ExpirableProduct { Id = 2, Name = "Biscuits", Price = 150, Quantity = 5, ExpiryDate = DateTime.Now.AddDays(5) };
            var scratchCard = new NonExpirableProduct { Id = 3, Name = "ScratchCard", Price = 50, Quantity = 10 };

            // Wrap shippables
            var shippableCheese = new ShippableProductAdapter(cheese, 0.3);
            var shippableBiscuits = new ShippableProductAdapter(biscuits, 0.7);

            // Add items to cart
            customer.Cart.AddItem(shippableCheese, 2);        // 200 EGP
            customer.Cart.AddItem(shippableBiscuits, 1);      // 150 EGP
            customer.Cart.AddItem(scratchCard, 1);   // 50 EGP




            // shippment fees -> 10 EGP per kg


            // Checkout
            checkoutService.Checkout(customer, customer.Cart);

        }
    }
}
