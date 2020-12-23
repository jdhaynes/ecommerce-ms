using System.Collections.Generic;
using Basket.Application.DTOs;
using Basket.Application.Interfaces;
using Common.Application;

namespace Basket.Application.Queries.GetBasket
{
    public class GetBasketQueryHandler : IQueryHandler<GetBasketQuery, List<DTOs.Basket>>
    {
        private readonly IBasketReadCache _basketReadCache;
        
        public GetBasketQueryHandler(IBasketReadCache basketReadCache)
        {
            _basketReadCache = basketReadCache;
        }
        
        public List<DTOs.Basket> Handle(GetBasketQuery query)
        {
            List<BasketItemCached> cachedItems = _basketReadCache.GetItems(query.BasketId);

            return null;
        }
    }
}