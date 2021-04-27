using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketAssignment.Service.Interface
{
   public interface IShoppingService
    {
        public int GetItemsToBuy(List<string> Items);
    }
}
