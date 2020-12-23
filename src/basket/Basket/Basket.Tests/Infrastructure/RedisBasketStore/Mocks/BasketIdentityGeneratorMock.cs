using System;
using Basket.Infrastructure.RedisBasketStore;

namespace Basket.Tests.Infrastructure.RedisBasketStore.Mocks
{
    public class BasketIdentityGeneratorMock : IBasketIdentityGenerator
    {
        private Guid _guid;
        
        public BasketIdentityGeneratorMock(Guid guid)
        {
            _guid = guid;
        }
        
        public Guid GenerateId()
        {
            return _guid;
        }
    }
}