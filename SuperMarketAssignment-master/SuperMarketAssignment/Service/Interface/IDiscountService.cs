using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketAssignment.Service.Interface
{
   public interface IDiscountService
    {
        double GetApplyDiscount(int customerId, double totalPrice);
    }
}
