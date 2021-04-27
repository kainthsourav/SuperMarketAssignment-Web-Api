﻿using Moq;
using NUnit.Framework;
using SuperMarketAssignment.Repository.Interface;
using SuperMarketAssignment.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarketAssignment.Test
{
 
    [TestFixture]
    public class DiscountServiceTest
    {

        private Mock<IDiscountRepository> _mockDiscountRepo;
        private DiscountService _discountService;

        [SetUp]
        public void Setup()
        {
            _mockDiscountRepo = new Mock<IDiscountRepository>();
            _discountService = new DiscountService(_mockDiscountRepo.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockDiscountRepo = null;
            _discountService = null;
        }

        [Test]
        [TestCase(1053, 2000, 1000)]
        [TestCase(2696, 1500, 750)]
        [TestCase(7543, 1000, 500)]
        [TestCase(3268, 500, 250)]
        public void ShouldGiveDiscountToPlatinumCustomers(int customerId, double totalPrice, double expectedDiscount)
        {
            _mockDiscountRepo.Setup(x => x.ApplyDiscount(It.IsAny<int>(), It.IsAny<double>())).Returns(expectedDiscount);
            var result = _discountService.GetApplyDiscount(customerId, totalPrice);
            Assert.AreEqual(result, expectedDiscount);
        }

        [Test]
        [TestCase(2051, 1800, 1260)]
        [TestCase(7419, 1900, 1330)]
        [TestCase(8635, 1100, 770)]
        public void ShouldGiveDiscountToGoldCustomers(int customerId, double totalPrice, double expectedDiscount)
        {
            _mockDiscountRepo.Setup(x => x.ApplyDiscount(It.IsAny<int>(), It.IsAny<double>())).Returns(expectedDiscount);
            var result = _discountService.GetApplyDiscount(customerId, totalPrice);
            Assert.AreEqual(result, expectedDiscount);
        }

        [Test]
        [TestCase(3426, 1600, 1440)]
        [TestCase(2222, 1900, 1710)]
        [TestCase(5148, 1100, 990)]
        public void ShouldGiveDiscountToSilverCustomers(int customerId, double totalPrice, double expectedDiscount)
        {
            _mockDiscountRepo.Setup(x => x.ApplyDiscount(It.IsAny<int>(), It.IsAny<double>())).Returns(expectedDiscount);
            var result = _discountService.GetApplyDiscount(customerId, totalPrice);
            Assert.AreEqual(result, expectedDiscount);
        }

        [Test]
        [TestCase(802, 1600, 1600)]
        [TestCase(318, 1900, 1900)]
        [TestCase(813, 1100, 1100)]
        public void ShouldNotGiveDiscountToCustomers(int customerId, double totalPrice, double expectedDiscount)
        {
            _mockDiscountRepo.Setup(x => x.ApplyDiscount(It.IsAny<int>(), It.IsAny<double>())).Returns(expectedDiscount);
            var result = _discountService.GetApplyDiscount(customerId, totalPrice);
            Assert.AreEqual(result, expectedDiscount);
        }
    }

}

