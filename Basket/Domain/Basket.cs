using System.Collections.Generic;
using System.Linq;

namespace Basket.Domain
{
    public class Basket
    {
        public BuyerId BuyerId { get; }
        public List<BasketItem> Items
        {
            get { return basketItems; }
        }
        public double TotalPrice
        {
            get
            {
                return basketItems.Sum(item => item.ProductPrice);
            }
        }

        private List<BasketItem> basketItems;

        public Basket(BuyerId buyerId, List<BasketItem> basketItems)
        {
            this.BuyerId = buyerId;
            this.basketItems = basketItems;
        }
        
        public void addItemToBasket(BasketItem item)
        {
            this.basketItems.Add(item);
        }
    }
}