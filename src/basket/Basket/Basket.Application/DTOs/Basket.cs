using System;
using System.Collections.Generic;

namespace Basket.Application.DTOs
{
    public class Basket
    {
        public Guid Id { get; set; }
        public List<BasketItem> Items { get; set; }
        public double TotalPrice { get; set; }
    }
}