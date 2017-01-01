using System;
using System.Collections.Generic;
namespace OnlineShopping
{
    public interface IBasket
    {
        bool addItem(IItem item, uint count = 1);
        void removeItem(IItem item);
        List<IItem> getItems();
        decimal getTotalPrice();
        string getId();
        void setId(string id);
        void setPurchaseTime(DateTime time);
        DateTime getPurchaseTime();

    }
}
