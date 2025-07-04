using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce_Fawry_Task.ProductModule;

namespace Ecommerce_Fawry_Task.CartModule
{
    public class CartItem
    {
        //public int Id { get; set; }
        public Product product { get; set; }

        //public int Quantity 
        //{ 
        //    get
        //    {
        //        return Quantity;
        //    }

        //    set
        //    {
        //        if (value < 1)
        //            throw new ArgumentException("Quantity must be at least 1");
        //        Quantity = value;
        //    }
        //}

        public int Quantity { get; set; }

      



    }
}
