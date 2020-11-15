using System;

namespace Basket.Domain
{
    public class Item
    {
        public Guid ProductId { get; }
        public int Quantity { get; }

        public Item(Guid productId, int quantity)
        {
            this.ProductId = productId;
            this.Quantity = quantity;
        }
    }
}