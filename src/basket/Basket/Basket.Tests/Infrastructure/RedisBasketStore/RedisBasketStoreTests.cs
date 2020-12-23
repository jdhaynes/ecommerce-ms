using System;
using Basket.Application.Interfaces;
using Basket.Infrastructure.RedisBasketStore;
using Basket.Tests.Infrastructure.RedisBasketStore.Mocks;
using NUnit.Framework;
using StackExchange.Redis;

namespace Basket.Tests.Infrastructure.RedisBasketStore
{
    [TestFixture]
    public class RedisBasketStoreTests
    {
        private readonly ConnectionMultiplexer _conn;
        private readonly IBasketRepository _repo;
        private readonly IBasketIdentityGenerator _identity;

        public RedisBasketStoreTests()
        {
            _conn = ConnectionMultiplexer.Connect("localhost:32770");
            _identity = new DotNetGuidGenerator();
            _repo = new RedisBasketStoreRepository(_conn, _identity);
        }
        
        [Test]
        public void GivenRedisInstanceExistsWhenInstantiateRepositoryShouldConnect()
        {
            Assert.IsTrue(_conn.IsConnected);
        }

        [Test]
        public void WhenCreateBasketShouldReturnGuid()
        {
            Guid basket = _repo.CreateBasket();
            Assert.NotNull(basket);
        }

        [Test]
        public void GivenGuidCollisionWhenCreateBasketShouldThrowException()
        {
            Guid id = new Guid("5147a409-1168-4bb0-85ee-c141aea30f12");
            RedisBasketStoreRepository repo = new RedisBasketStoreRepository(_conn,
                new BasketIdentityGeneratorMock(id));
            
            Assert.Throws<Exception>(() => { repo.CreateBasket(); });
        }
    }
}