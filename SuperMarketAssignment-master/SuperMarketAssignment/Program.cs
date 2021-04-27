using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketAssignment.Client;
using SuperMarketAssignment.Repository.Implementation;
using SuperMarketAssignment.Service;
using SuperMarketAssignment.Service.Implementation;
using SuperMarketAssignment.Logging;

namespace SuperMarketAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Customer Id");
            int customerId = Int32.Parse(Console.ReadLine());
            while (customerId.ToString() == null)
            {
                Console.WriteLine("Enter Customer Id");
                customerId = Int32.Parse(Console.ReadLine());
            }
            var stockService = new StockService(new StockRepository());
            var discountService = new DiscountService(new DiscountRepository());
            var paymentGateway = new PaymentRepository(new PaymentGatewayClient(new System.Net.Http.HttpClient()));

            List<string> items = new List<string>() { "Breads", "Milk", "Biscuits", "DryFruits" };
            ShoppingService shopping = new ShoppingService(customerId, stockService, discountService, paymentGateway, new Logger());
            var count = shopping.GetItemsToBuy(items);
            var resutl = count > 0 ? $"Shopping done for {count} products" : $"Shopping done for {count} products";
            Console.WriteLine(resutl);
            Console.ReadLine();
        }

    }
}
