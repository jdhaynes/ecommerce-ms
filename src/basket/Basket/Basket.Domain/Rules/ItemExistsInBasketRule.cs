using System;
using System.Collections.Generic;
using Common.Domain;

namespace Basket.Domain.Rules
{
    public class ItemExistsInBasketRule : IDomainRule
    {
        public string ErrorCode => "ITEM_NOT_IN_BASKET";
        private List<BasketItem> _items;
        private Guid _productId;

        public ItemExistsInBasketRule(List<BasketItem> items, Guid productId)
        {
            _items = items;
            _productId = productId;
        }
        
        public bool Valid()
        {
            return _items.Exists(item => item.Product.ProductId == _productId);
        }
    }
}