using System;
using System.Collections.Generic;
namespace OnlineShopping
{
    public interface ICustomer
    {
        void addItemToBasket(IItem item);
        IBasket getCurrentBasket();
        string getDeliveryAddress();
        string getEmailAddress();
        string getFirstName();
        string getId();
        string getLastName();
        string getPhoneNumber();
        IPurchaseHistory getPurchaseHistory();
        bool PurchaseCurrentBasket();
        void removeItemFromBasket(IItem item);
        void setCurrentBasket(IBasket basket);
        void setDeliveryAddress(string address);
        void setEmailAddress(string emailAddress);
        void setFirstName(string firstName);
        void setId(string id);
        void setLastName(string lastName);
        void setPhoneNumber(string phoneNumber);
        void setPurchaseHistory(IPurchaseHistory purchaseHistory);
    }
}
