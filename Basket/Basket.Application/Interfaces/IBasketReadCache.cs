using System;

namespace Basket.Application.Interfaces
{
    public interface IBasketCache<TBasket>
    {
        TBasket Get(Guid basketId);
        void Update(TBasket basket);
        bool Exists(Guid basketId);
    }
}