using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Fawry_Task.ProductModule
{
    public class ExpirableProduct : Product
    {
        public DateTime ExpiryDate { get; set; }

        public override bool IsExpired()
        {
            return DateTime.Now > ExpiryDate;
        }
    }

}
