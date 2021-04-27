using SuperMarketAssignment.Client;
using SuperMarketAssignment.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketAssignment.Repository.Implementation
{
    public class PaymentRepository : IPaymentRepository
    {
        private IPaymentGatewayClient _paymentGatewayClient;
        public PaymentRepository(IPaymentGatewayClient paymentGatewayClient)
        {
            _paymentGatewayClient = paymentGatewayClient;
        }
        public Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            var result = _paymentGatewayClient.GetAsync(requestUri);
            return result;
        }
    }
}
