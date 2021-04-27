using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketAssignment.Repository.Interface
{
   public interface IDiscountRepository
    {
        double ApplyDiscount(int id, double totalPrice);
    }
}
