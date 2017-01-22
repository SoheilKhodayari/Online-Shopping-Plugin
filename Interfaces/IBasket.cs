using System;
using System.Collections.Generic;
namespace OnlineShopping
{
    public interface IBasket
    {
        bool addItem(Item item, uint count = 1);
        void removeItem(Item item, uint count = 1);
        List<Item> getItems();
        decimal getTotalPrice();
        string getId();
        void setId(string id);
        void setPurchaseTime(DateTime time);
        DateTime getPurchaseTime();

    }
}
