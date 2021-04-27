using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketAssignment.Client
{
   public class PaymentGatewayClient : IPaymentGatewayClient
    {
        private HttpClient _httpClient;
        
        public PaymentGatewayClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            var result = await _httpClient.GetAsync(requestUri);
            return result;
        }
    }
}
