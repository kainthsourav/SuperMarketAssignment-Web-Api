using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketAssignment.Models;

namespace SuperMarketAssignment.Service.Interface
{
   public interface IStockService
    {
        IEnumerable<ProductsDataModel> GetStockStatus(List<string> items);
            
    }
}
