using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketAssignment.Client
{
   public interface IPaymentGatewayClient
    {
        Task<HttpResponseMessage> GetAsync(string requestUri);
    }
}
