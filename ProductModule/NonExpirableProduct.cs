using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Fawry_Task.ProductModule
{
    public class NonExpirableProduct : Product
    {

        public override bool IsExpired() => false;
    }

}
