using NUnit.Framework;
using SuperMarketAssignment.Repository;
using SuperMarketAssignment.Repository.Implementation;
using SuperMarketAssignment.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarketAssignment.Test
{
    public class DiscountRepositoryTest
    {

        [TestFixture]
        public class DiscountServiceTest
        {

            private IDiscountRepository _discountRepo;

            [SetUp]
            public void Setup()
            {
                _discountRepo = new DiscountRepository();
            }

            [TearDown]
            public void TearDown()
            {
                _discountRepo = null;
            }

            [Test]
            [TestCase(1053, 2000, 1000)]
            [TestCase(2696, 1500, 750)]
            [TestCase(7543, 1000, 500)]
            [TestCase(3268, 500, 250)]
            public void ShouldApplyDiscountForPlatinumCustomers(int customerId, double totalPrice, double expectedDiscount)
            {
                var result = _discountRepo.ApplyDiscount(customerId, totalPrice);
                Assert.AreEqual(result, expectedDiscount);
            }

            [Test]
            [TestCase(2051, 1800, 1260)]
            [TestCase(7419, 1900, 1330)]
            [TestCase(8635, 1100, 770)]
            public void ShouldApplyDiscountForGoldCustomers(int customerId, double totalPrice, double expectedDiscount)
            {
                var result = _discountRepo.ApplyDiscount(customerId, totalPrice);
                Assert.AreEqual(result, expectedDiscount);
            }

            [Test]
            [TestCase(3426, 1600, 1440)]
            [TestCase(2222, 1900, 1710)]
            [TestCase(5148, 1100, 990)]
            public void ShouldApplyDiscountForSilverCustomers(int customerId, double totalPrice, double expectedDiscount)
            {
                var result = _discountRepo.ApplyDiscount(customerId, totalPrice);
                Assert.AreEqual(result, expectedDiscount);
            }

            [Test]
            [TestCase(802, 1600, 1600)]
            [TestCase(318, 1900, 1900)]
            [TestCase(813, 1100, 1100)]
            public void ShouldNotGiveDiscount(int customerId, double totalPrice, double expectedDiscount)
            {
                var result = _discountRepo.ApplyDiscount(customerId, totalPrice);
                Assert.AreEqual(result, expectedDiscount);
            }
        }
    }
}
