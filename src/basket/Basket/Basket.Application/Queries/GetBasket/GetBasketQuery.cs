using System;
using System.Collections.Generic;
using Basket.Application.DTOs;
using Common.Application;

namespace Basket.Application.Queries.GetBasket
{
    public class GetBasketQuery : IQuery<DTOs.Basket>, IQuery<List<DTOs.Basket>>
    {
        public Guid BasketId { get; }

        public GetBasketQuery(Guid basketId)
        {
            BasketId = basketId;
        }
    }
}