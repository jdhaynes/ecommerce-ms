using System;
using Common.Domain;

namespace Basket.Domain
{
    /// <summary>
    /// Entity representing a product in the catalog. This entity is not owned by the basket.
    /// </summary>
    public class Product : Entity
    {
        public Guid ProductId { get; }
        public string Name { get; }
        public string Description { get; }
        public double Price { get; }
        public int AvailableStock { get; private set; }
        public int MaximumPurchaseLimit { get; }
        public bool IsInStock => AvailableStock > 0;
        
        private Product() { }

        public Product(Guid productId, string name, string description, double price, 
            int availableStock, int maximumPurchaseLimit)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            Price = price;
            AvailableStock = availableStock;
            MaximumPurchaseLimit = maximumPurchaseLimit;
        }
    }
}