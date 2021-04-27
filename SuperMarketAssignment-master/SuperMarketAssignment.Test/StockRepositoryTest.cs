using Moq;
using NUnit.Framework;
using SuperMarketAssignment.Models;
using SuperMarketAssignment.Repository.Implementation;
using SuperMarketAssignment.Repository.Interface;
using SuperMarketAssignment.Service.Implementation;
using System;
using System.Collections.Generic;

namespace SuperMarketAssignment.Test
{
    [TestFixture]
    public class StockRepositoryTest
    {
        private List<ProductsDataModel> productsDataModels;
        private List<string> _items;
        private StockRepository _stockRepo;

        [SetUp]
        public void Setup()
        {
            productsDataModels = new List<ProductsDataModel>();
            _items = new List<string>();
            _stockRepo = new StockRepository();
        }
        [TearDown]
        public void TearDown()
        {
            productsDataModels.Clear();
            _items.Clear();
        }

        [Test]
        public void ShouldCheckStockStatus()
        {
            _items.Add("Bread");
            _items.Add("Milk");
            _items.Add("Cheese");
            _items.Add("Butter");
            _items.Add("Biscuits");

            var result = _stockRepo.CheckStockStatus(_items);
            Assert.NotNull(result);
        }

       
    }
}
