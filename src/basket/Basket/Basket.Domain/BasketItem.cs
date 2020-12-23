using System;
using Common.Domain;

namespace Basket.Domain
{
    // Value object representing an product in the basket with an associated quantity.
    public class BasketItem
    {
        /// <summary>
        /// Entity representing the product.
        /// </summary>
        public Product Product { get; }
        /// <summary>
        /// Quantity of the product in the shopper basket.
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// Private constructor reserved for persistence mapping if required.
        /// </summary>
        private BasketItem() { }
        
        /// <summary>
        ///
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        public BasketItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        /// <summary>
        /// Updates the quantity of the item in the shopper basket.
        /// </summary>
        /// <param name="quantity">The new quantity of the item.</param>
        /// <exception cref="DomainRuleException">Thrown when a business rule is violated.</exception>
        public void UpdateQuantity(int quantity)
        {
            if (Quantity > Product.AvailableStock)  
            { 
                throw new DomainRuleException("ITEM_OUT_OF_STOCK");
            }
            
            if (Quantity > Product.MaximumPurchaseLimit)
            {
                throw new DomainRuleException("MAXIMUM_ITEM_LIMIT_REACHED");
            }
            
            if (Quantity == 0)
            {
                throw new DomainRuleException("ITEM_QUANTITY_ZERO");
            }
            
            Quantity = quantity;
        }
    }
}