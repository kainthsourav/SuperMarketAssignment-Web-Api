using SuperMarketAssignment.Models;
using SuperMarketAssignment.Service.Interface;
using SuperMarketAssignment.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketAssignment.Service.Implementation
{
    public class StockService : IStockService
    {
        private IStockRepository _stockRepo;

        public StockService(IStockRepository stockRepo)
        {
            _stockRepo = stockRepo;
        }
        public IEnumerable<ProductsDataModel> GetStockStatus(List<string> items)
        {
            return _stockRepo.CheckStockStatus(items);
        }
    }
}
