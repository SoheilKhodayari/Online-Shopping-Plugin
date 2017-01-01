using System;
using System.Collections.Generic;
namespace OnlineShopping
{
    public interface IPurchaseHistory
    {
        string getId();
        void setId(string id);
        void addPurchaseRecord(IBasket record);
        void removePurchaseRecord(IBasket record);
        List<IBasket> getPurchseRecords();
        void setPurchseRecords(List<IBasket> records);
        void removePurchaseRecords(List<IBasket> records);


    }
}
