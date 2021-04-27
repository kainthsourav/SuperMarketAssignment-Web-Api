using SuperMarketAssignment.Repository.Interface;
using SuperMarketAssignment.Service.Interface;
using SuperMarketAssignment.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketAssignment.Constant;
using System.Net.Http;

namespace SuperMarketAssignment.Service.Implementation
{
    public class ShoppingService : IShoppingService
    {
        private readonly int _customerid;
        private double OrderValue = 0;
        private IStockService _stockService;
        private IDiscountService _discountService;
        private IPaymentRepository _paymentRepo;
        private ILogger _logger;

        public ShoppingService(int customerId,IStockService stockService,IDiscountService discountService,IPaymentRepository paymentRepo,ILogger logger)
        {
            _customerid = customerId;
            _stockService = stockService;
            _discountService = discountService;
            _logger = logger;
            _paymentRepo = paymentRepo;
        }
        public int GetItemsToBuy(List<string> Items)
        {
            double price = 0;
            Console.WriteLine("\n---- Shopping List----");
            for (int i = 0; i < Items.Count(); i++)
            {
                Console.WriteLine("-- "+Items[i]);
            }

            var products = _stockService.GetStockStatus(Items);
            Console.WriteLine("\n ---- Item Available----");
            foreach (var item in products)
            {
                Console.WriteLine("-- " + item.Name + " -- " + item.Price);
                price += item.Price;
            }
            Console.WriteLine("\n-------------");
            Console.WriteLine("Total price : "+price);
            OrderValue = _discountService.GetApplyDiscount(this._customerid, price);
            Console.WriteLine("After discount price : "+OrderValue);
            Console.WriteLine();
            var requestUri = SuperMarketConstants.RequestUri + OrderValue;
            var result = _paymentRepo.GetAsync(requestUri).Result;

            if(result.IsSuccessStatusCode)
            {
                Console.WriteLine("Payment processed successfully");
            }
            else
            {
                LogPaymentFailure(result);
            }
            return products.Count();
        }

        private void LogPaymentFailure(HttpResponseMessage response)
        {
            switch(response.StatusCode)
            {
                case System.Net.HttpStatusCode.BadRequest:
                    throw new ArgumentException("Invaild Customer :" + _customerid);
                default:
                    _logger.write("Error in processing payment " + _customerid);
                    break;
            }
        }
    }
}
