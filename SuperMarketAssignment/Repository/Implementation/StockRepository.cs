using SuperMarketAssignment.Models;
using SuperMarketAssignment.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketAssignment.Repository.Implementation
{
    public class StockRepository : IStockRepository
    {
        public IEnumerable<ProductsDataModel> CheckStockStatus(List<string> items)
        {
            Random randomNumbers = new Random();
            List<ProductsDataModel> products = new List<ProductsDataModel>();
            for (int i = 0; i < items.Count; i++)
            {
                ProductsDataModel product = new ProductsDataModel();
                product.Name = items[i];
                product.Price = randomNumbers.Next(100, 1000); 

                if (randomNumbers.Next(0, 10) % 3 != 0) 
                {
                    products.Add(product);
                }
            }
            return products;
        }
    }
}
