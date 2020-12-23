using System;
using System.Collections.Generic;
using Basket.Application.DTOs;

namespace Basket.Application.Interfaces
{
    public interface IBasketReadCache
    {
        List<BasketItemCached> GetItems(Guid basketId);
    }
}