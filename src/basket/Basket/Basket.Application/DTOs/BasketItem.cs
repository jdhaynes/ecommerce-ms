using System;

namespace Basket.Application.DTOs
{
    public class BasketItem
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double Price { get; set; }
    }
}