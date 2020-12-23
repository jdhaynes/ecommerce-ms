using System;
using System.Collections.Generic;
using Basket.Application.DTOs;
using Basket.Application.Interfaces;
using StackExchange.Redis;

namespace Basket.Infrastructure.RedisBasketStore
{
    public class RedisBasketCache : IBasketReadCache
    {
        private readonly ConnectionMultiplexer _conn;
        private readonly IDatabase _db;

        public RedisBasketCache(ConnectionMultiplexer connectionMultiplexer)
        {
            _conn = connectionMultiplexer;
            _db = connectionMultiplexer.GetDatabase();
        }
        
        public List<BasketItemCached> GetItems(Guid basketId)
        {
            throw new NotImplementedException();
        }
    }
}