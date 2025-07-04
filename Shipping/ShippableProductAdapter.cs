using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce_Fawry_Task.ProductModule;

namespace Ecommerce_Fawry_Task.Shipping
{
    public class ShippableProductAdapter : Product , IShippable
    {
        private readonly Product _product;
        private readonly double _weight;

        public ShippableProductAdapter(Product product, double weight)
        {
            _product = product;
            _weight = weight;

            // Sync base Product properties
            this.Id = _product.Id;
            this.Name = _product.Name;
            this.Price = _product.Price;
            this.Quantity = _product.Quantity;
        }

        public string GetName() => _product.Name;
        public double GetWeight() => _weight;

        public override bool IsExpired() => _product.IsExpired();
    }

}
