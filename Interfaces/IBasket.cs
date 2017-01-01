using System;
using System.Collections.Generic;

namespace OnlineShopping
{
    interface IBasket
    {
        void addItem(Item item);
        void addItems(List<Item> items);
        string getId();
        List<Item> getItems();
        DateTime getPurchaseTime();
        decimal getTotalPrice();
        void setId(string id);
        void setPurchaseTime(DateTime time);
    }
}
