using System;
using System.Collections.Generic;
using System.Linq;

namespace Basket.Domain
{
    public class CustomerBasket
    {
        public int ItemCount => Items.Count;

        public List<Item> Items { get; private set; }

        public CustomerBasket()
        {
            this.Items = new List<Item>();
        }

        public void AddItem(Guid productId, int quantity)
        {
            Items.Add(new Item(productId, quantity));
        }
    }
}