namespace Basket.Application.Interfaces
{
    public interface IBasketWriteCache<TBasket>
    {
        void Update(TBasket basket);
    }
}