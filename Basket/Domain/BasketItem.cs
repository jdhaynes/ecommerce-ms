using System;

namespace Basket.Domain
{
    public class BasketItem
    {
        public BasketItemId Id { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int LineQuantity { get; set; }
    }
}