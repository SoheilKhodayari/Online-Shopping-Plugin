using System;
using System.Collections.Generic;
namespace OnlineShopping
{
    public interface IPurchaseHistory
    {
        string getId();
        void setId(string id);
        void addPurchaseRecord(Basket record);
        void removePurchaseRecord(Basket record);
        List<Basket> getPurchseRecords();
        void setPurchseRecords(List<Basket> records);
        void removePurchaseRecords(List<Basket> records);


    }
}
