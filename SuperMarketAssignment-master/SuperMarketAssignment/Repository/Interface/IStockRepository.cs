using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketAssignment.Models;

namespace SuperMarketAssignment.Repository.Interface
{
   public interface IStockRepository
    {
        IEnumerable<ProductsDataModel> CheckStockStatus(List<string> items);
    }
}
