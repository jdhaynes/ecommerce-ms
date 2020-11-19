using System;

namespace Basket.Infrastructure.RedisBasketStore
{
    public interface IBasketIdentityGenerator
    {
        Guid GenerateId();
    }
}