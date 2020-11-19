using System;
using System.Collections.Generic;
using System.Linq;
using Basket.Domain.Rules;
using Common.Domain;

namespace Basket.Domain
{
    /// <summary>
    /// Aggregate root representing the basket of a shopper.
    /// </summary>
    public class ShopperBasket : Entity
    {
        private List<BasketItem> _items = new List<BasketItem>();

        /// <summary>
        /// The total number of items in the basket.
        /// </summary>
        public int ItemCount => CalculateTotalItemCount();
        /// <summary>
        /// The total price to purchase the items currently in the basket.
        /// </summary>
        public double TotalPrice => CalculateTotalPrice();
        /// <summary>
        /// The collection of items currently in the basket.
        /// </summary>
        public IReadOnlyCollection<BasketItem> Items => _items.AsReadOnly();
        
        /// <summary>
        /// Adds a new item to the basket. If the item is already in the basket, the quantity is
        /// updated to be the sum of the existing quantity and the quantity added.
        /// </summary>
        /// <param name="productId">The identifier of the product being added.</param>
        /// <param name="productName">The name of the product being added.</param>
        /// <param name="productDescription">The description of the product being added.</param>
        /// <param name="price">The price of the product being added.</param>
        /// <param name="availableStock">The quantity of the product in stock that are available
        /// for purchase.</param>
        /// <param name="maximumPurchaseLimit">The maximum quantity a shopper is allowed to
        /// purchase for this product.</param>
        /// <param name="quantity">The quantity of the product being added.</param>
        public void AddItem(Guid productId, string productName, string productDescription, 
            double price, int availableStock, int maximumPurchaseLimit, int quantity)
        {
            BasketItem existingItem =
                _items.SingleOrDefault(item => item.Product.ProductId == productId);

            existingItem?.UpdateQuantity(existingItem.Quantity + quantity);

            BasketItem newItem = new BasketItem(
                    new Product(productId, productName, productDescription, price, availableStock,
                        maximumPurchaseLimit),
                    quantity);

            _items.Add(newItem);
        }

        /// <summary>
        /// Updates the quantity of an item currently in the basket.
        /// </summary>
        /// <param name="productId">The identifier of the product being added.</param>
        /// <param name="quantity">The new quantity of the product.</param>
        /// <exception>Thrown when a business rule is violated.
        ///     <cref>DomainRuleException</cref>
        /// </exception>
        public void UpdateItemQuantity(Guid productId, int quantity)
        {            
            CheckRule(new ItemExistsInBasketRule(_items, productId));
            
            BasketItem item = Items.Single(basketItem => basketItem.Product.ProductId == productId);
            item.UpdateQuantity(quantity);
        }
        private int CalculateTotalItemCount()
        {
            return Items.Sum(item => item.Quantity);
        }

        private double CalculateTotalPrice()
        {
            return Items.Sum(item => item.Product.Price);
        }
    }
}