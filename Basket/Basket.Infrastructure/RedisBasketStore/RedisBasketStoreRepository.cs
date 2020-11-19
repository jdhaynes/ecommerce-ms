using System;
using Basket.Application.Interfaces;
using Basket.Domain;
using StackExchange.Redis;

namespace Basket.Infrastructure.RedisBasketStore
{
    public class RedisBasketStoreRepository : IBasketRepository
    {
        private readonly ConnectionMultiplexer _conn;
        private readonly IDatabase _db;
        private readonly IBasketIdentityGenerator _identity;

        public RedisBasketStoreRepository(ConnectionMultiplexer multiplexer,
            IBasketIdentityGenerator identity)
        {
            _conn = multiplexer;
            _db = _conn.GetDatabase();
            _identity = identity;
        }

        /// <summary>
        /// Creates a new empty basket and returns the associated basket ID for future operations.
        /// </summary>
        /// <returns>Identifier GUID of the basket created.</returns>
        /// <exception cref="Exception">Throws if the randomly generated ID already exists,
        /// although it is extremely unlikely for a GUID collision. </exception>
        public Guid CreateBasket()
        {
            Guid basketId = _identity.GenerateId();
            bool keyCreated = _db.StringSet($"Basket:{basketId.ToString()}", "", null, 
                When.NotExists);
            
            if (!keyCreated) { throw new Exception("Basket ID already exists."); }

            return basketId;
        }

        /// <summary>
        /// Gets a basket by ID.
        /// </summary>
        /// <param name="basketId">Identifier GUID of the basket.</param>
        /// <returns>An object representing the contents of the shopper's basket.</returns>
        public ShopperBasket GetBasket(Guid basketId)
        {
            HashEntry[] result = _db.HashGetAll(basketId.ToString());

            throw new NotImplementedException();
        }

        public void UpdateBasket(ShopperBasket basket)
        {
            throw new NotImplementedException();
        }
        
    }
}