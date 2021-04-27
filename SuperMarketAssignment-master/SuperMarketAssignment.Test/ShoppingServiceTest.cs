using Moq;
using NUnit.Framework;
using SuperMarketAssignment.Logging;
using SuperMarketAssignment.Models;
using SuperMarketAssignment.Repository.Implementation;
using SuperMarketAssignment.Repository.Interface;
using SuperMarketAssignment.Service.Implementation;
using SuperMarketAssignment.Service.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SuperMarketAssignment.Test
{

    [TestFixture]
    public class ShoppingServiceTest
    {

        ShoppingService _shoppingService;
        private Mock<ILogger> _mocklogger;
        private Mock<IDiscountService> _mockdiscountService;
        private Mock<IPaymentRepository> _mockPaymentRepo;
        private Mock<IStockService> _mockStockService;

        private List<ProductsDataModel> products = null;
        private List<string> items = null;
        private int anycustomerId = 1053;
      
        [SetUp]
        public void SetUp()
        {
            products = new List<ProductsDataModel>();
            items = new List<string>();
           
            products.Add(new ProductsDataModel()
            {
                Name = "Biscuits",
                Price = 100,
            });
            products.Add(new ProductsDataModel()
            {
                Name = "Milk",
                Price = 300,
            });
           
            items.Add("Bread");
            items.Add("Milk");
            items.Add("cheese");
            items.Add("Butter");
            items.Add("Biscuits");

            _mockdiscountService = new Mock<IDiscountService>();
            _mockPaymentRepo = new Mock<IPaymentRepository>();
            _mockStockService = new Mock<IStockService>();
            _mocklogger = new Mock<ILogger>();
            _shoppingService = new ShoppingService(anycustomerId, _mockStockService.Object, _mockdiscountService.Object, _mockPaymentRepo.Object, _mocklogger.Object);
            _mockStockService.Setup(x => x.GetStockStatus(It.IsAny<List<string>>())).Returns(products);
        }


        [TearDown]
        public void TearDown()
        {
            _mockdiscountService = null;
            _mockPaymentRepo = null;
            _mockStockService = null;
            _mocklogger = null;
            _shoppingService = null;
             products.Clear();
             items.Clear();
        }


        [Test]
        public void WhenGetItemsToBuy_PaymentSuccessfulForAvailableItemsInStock_ReturnsItemCount()
        {
   
            _mockdiscountService.Setup(x => x.GetApplyDiscount(It.IsAny<Int16>(), It.IsAny<double>())).Returns(It.IsAny<double>());
            _mockPaymentRepo.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));
            _mocklogger.Setup(x => x.write(It.IsAny<string>()));
            var result = _shoppingService.GetItemsToBuy(items);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void GetItemsToBuy_PaymentFailedDueToBadRequest_ThrowsException()
        {
            _mockdiscountService.Setup(x => x.GetApplyDiscount(It.IsAny<Int16>(), It.IsAny<double>())).Returns(It.IsAny<double>());
            _mockPaymentRepo.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.BadRequest)));
            _mocklogger.Setup(x => x.write(It.IsAny<string>()));
            Assert.Throws<ArgumentException>(() => _shoppingService.GetItemsToBuy(items));
        }

        [Test]
        public void GetItemsToBuy_ErrorInPaymentProcessing()
        {
            _mockdiscountService.Setup(x => x.GetApplyDiscount(It.IsAny<Int16>(), It.IsAny<double>())).Returns(70);
            _mockPaymentRepo.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.NotFound)));
            _mocklogger.Setup(x => x.write(It.IsAny<string>()));
            var result = _shoppingService.GetItemsToBuy(items);
            var output = new StringWriter();
            Console.SetOut(output);
            var logger = new Logger();
            var errorMsg = "Error in processing payment " + anycustomerId;
            logger.write(errorMsg);
            Assert.That(output.ToString(), Is.EqualTo(errorMsg + string.Format(Environment.NewLine)));
            Assert.AreEqual(2, result);
        }

    }
}