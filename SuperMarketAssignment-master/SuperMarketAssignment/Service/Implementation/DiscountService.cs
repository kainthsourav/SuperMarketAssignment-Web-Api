using SuperMarketAssignment.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketAssignment.Repository.Interface;

namespace SuperMarketAssignment.Service.Implementation
{
    public class DiscountService : IDiscountService
    {
        private IDiscountRepository _discountRepo;
        public DiscountService(IDiscountRepository discountRepo)
        {
            _discountRepo = discountRepo;
        }
        public double GetApplyDiscount(int customerId, double totalPrice)
        {
            return _discountRepo.ApplyDiscount(customerId, totalPrice);
        }
    }
}
