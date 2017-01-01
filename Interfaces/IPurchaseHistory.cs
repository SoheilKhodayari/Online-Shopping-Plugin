using System;
using System.Collections.Generic;
namespace OnlineShopping
{
    interface IPurchaseHistory
    {
        void addPurchaseRecord(Basket basket);
        string getId();
        List<Basket> getPurchseRecords();
        void setId(string id);
        void setPurchseRecords(List<Basket> records);
    }
}
