using System;

namespace Basket.Infrastructure.RedisBasketStore
{
    public class DotNetGuidGenerator : IBasketIdentityGenerator
    {
        public Guid GenerateId()
        {
            return Guid.NewGuid();
        }
    }
}