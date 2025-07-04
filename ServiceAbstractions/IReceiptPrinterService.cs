using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce_Fawry_Task.CartModule;

namespace Ecommerce_Fawry_Task.ServiceAbstractions
{
    public interface IReceiptPrinterService
    {
        void PrintReceipt(ICollection<CartItem> items, decimal subtotal, decimal shipping, decimal total, decimal remainingBalance);
    }

}
