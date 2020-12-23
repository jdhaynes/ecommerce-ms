using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;
using Basket.Domain;

namespace Basket.Tests.Domain
{
    [TestFixture]
    public class BasketDomainUnitTests
    {
        [Test]
        public void WhenInstantiateBasketShouldReturnNotObject()
        {
            ShopperBasket basket = new ShopperBasket();

            Assert.Multiple(() =>
            {
                Assert.IsNotNull(basket);
                Assert.IsInstanceOf<ShopperBasket>(basket);
            });
        }

        [Test]
        public void GivenNewBasketWhenItemCountShouldBeZero()
        {
            ShopperBasket basket = new ShopperBasket();

            Assert.AreEqual(0, basket.ItemCount);
        }

        [Test]
        public void GivenNewBasketWhenAddItemCountShouldIncrease()
        {
            ShopperBasket basket = new ShopperBasket();

            Guid productId = Guid.NewGuid();
            basket.AddItem(productId, "Test name", "Test dec", 15.25, 5, 10, 2);
            
            Assert.AreEqual(2, basket.ItemCount);
        }

        [Test]
        public void GivenOneItemWhenGetItemsShouldReturnOneItem()
        {
            ShopperBasket basket = new ShopperBasket();

            Guid productId = Guid.NewGuid();
            basket.AddItem(productId, "Test name", "Test dec", 15.25, 5, 10, 2);

            IReadOnlyCollection<BasketItem> items = basket.Items;
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(1, items.Count);
                Assert.NotNull(items.ElementAt(0));
            });
        }

        [Test]
        public void GivenOneItemWhenGetItemsShouldReturnItemWithCorrectPropertyValues()
        {
            ShopperBasket basket = new ShopperBasket();

            Guid productId = Guid.NewGuid();
            basket.AddItem(productId, "Test name", "Test dec", 15.25, 5, 10, 2);

            BasketItem basketItem = basket.Items.ElementAt(0);
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(productId, basketItem.Product.ProductId);
                Assert.AreEqual(2, basketItem.Quantity);
            });
        }
    }
}