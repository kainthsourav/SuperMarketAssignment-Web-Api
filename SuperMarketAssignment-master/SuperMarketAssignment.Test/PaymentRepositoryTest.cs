using Moq;
using NUnit.Framework;
using SuperMarketAssignment.Repository.Implementation;
using SuperMarketAssignment.Constant;
using SuperMarketAssignment.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace SuperMarketAssignment.Test
{
    [TestFixture]
    public class PaymentRepositoryTest
    {
        private Mock<IPaymentGatewayClient> _mockPaymentGateway;
        private PaymentRepository _paymentRepository;

        [SetUp]
        public void Setup()
        {
            _mockPaymentGateway = new Mock<IPaymentGatewayClient>();
            _paymentRepository = new PaymentRepository(_mockPaymentGateway.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockPaymentGateway = null;
            _paymentRepository = null;
        }

        [Test]
        public void ShouldReturn_PaymentSuccessfull()
        {
            _mockPaymentGateway.Setup(x => x.GetAsync(SuperMarketConstants.RequestUri));

            var result = _paymentRepository.GetAsync(SuperMarketConstants.RequestUri);

            Assert.NotNull(result);
        }
    }
}
