using System;
using Basket.Domain;

namespace Basket.Application.Interfaces
{
    public interface IBasketRepository
    {
        Guid CreateBasket();
        ShopperBasket GetBasket(Guid basketId);
        void UpdateBasket(ShopperBasket basket);
    }
}