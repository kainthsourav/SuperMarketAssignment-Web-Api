using Moq;
using NUnit.Framework;
using SuperMarketAssignment.Models;
using SuperMarketAssignment.Repository.Interface;
using SuperMarketAssignment.Service.Implementation;
using System;
using System.Collections.Generic;

namespace SuperMarketAssignment.Test
{
    [TestFixture]
    public class StockServiceTest
    {
        private Mock<IStockRepository> _stockMockRepo;
        private StockService _stockService;

        private List<ProductsDataModel> products;
        private List<string> items;

        [SetUp]
        public void Setup()
        { 
            _stockMockRepo = new Mock<IStockRepository>();
            _stockService = new StockService(_stockMockRepo.Object);

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
        }

        [TearDown]
        public void TearDown()
        {
            _stockMockRepo = null;
            _stockService = null;
            items.Clear();
            products.Clear();
        }

        [Test]
        public void ShoudldCheckAvailablilityOfStocks()
        {
            _stockMockRepo.Setup(x => x.CheckStockStatus(It.IsAny<List<string>>())).Returns(products); 
            var result = _stockService.GetStockStatus(items);
            Assert.AreEqual(products, result);
        }



    }

}

