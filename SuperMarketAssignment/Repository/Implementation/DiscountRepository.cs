using SuperMarketAssignment.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketAssignment.Constant;


namespace SuperMarketAssignment.Repository.Implementation
{
    public class DiscountRepository : IDiscountRepository
    {
        public double ApplyDiscount(int id, double totalPrice)
        {
            if(SuperMarketConstants.platinumCustomers.Contains(id))
            {
                return totalPrice - (totalPrice * SuperMarketConstants.platinumCustomersDiscount / SuperMarketConstants.totalCustomersDiscount);
            }
            else if(SuperMarketConstants.goldCustomers.Contains(id))
            {
                return totalPrice - (totalPrice * SuperMarketConstants.goldCustomersDiscount/ SuperMarketConstants.totalCustomersDiscount);
            }
            else if(SuperMarketConstants.silverCustomers.Contains(id))
            {
                return totalPrice - (totalPrice * SuperMarketConstants.sliverCustomersDiscount / SuperMarketConstants.totalCustomersDiscount);
            }
            return totalPrice;
        }
    }
}
