using System;
using System.Collections.Generic;

namespace OnlineShopping
{
    interface IBasket
    {
        bool addItem(Item item, uint count = 1);
        string getId();
        List<Item> getItems();
        DateTime getPurchaseTime();
        decimal getTotalPrice();
        void setId(string id);
        void setPurchaseTime(DateTime time);
    }
}
