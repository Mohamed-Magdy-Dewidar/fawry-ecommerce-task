using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce_Fawry_Task.ProductModule;

namespace Ecommerce_Fawry_Task.CartModule
{
    public class CustomerCart
    {
        public string? Id { get; set; } = null!;
        
        public ICollection<CartItem> Items { get; set; } = [];


        public decimal shippingPrice { get; set; }


        
        public void AddItem(Product? product, int quantity)
        {

            if(product is null)
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");

            if (product.Id < 1)
                throw new ArgumentException("Product must have a valid Id.");
            
           
            // handles the case where quantity is less than 1
            if (quantity < 1)
                throw new ArgumentException("Quantity must be at least 1.");


            // handles the case where product is added more than once
            // if the product already exists in the cart, increase its quantity
            // instead of adding it one more time
            var existing = Items.FirstOrDefault(i => i.product.Id == product.Id);
            if (existing != null)
            {
                existing.Quantity += quantity;
            }
            else
            {
                Items.Add(new CartItem {product = product, Quantity = quantity });
            }
        }

    }
}
