using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Fawry_Task.ProductModule
{
    public abstract class Product
    {

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public abstract bool IsExpired(); // Required in base
    }

}
