using System;
using System.Collections.Generic;
namespace OnlineShopping
{
    public interface ICustomer
    {
        void addItemToBasket(Item item);
        Basket getCurrentBasket();
        string getDeliveryAddress();
        string getEmailAddress();
        string getFirstName();
        string getId();
        string getLastName();
        string getPhoneNumber();
        PurchaseHistory getPurchaseHistory();
        bool PurchaseCurrentBasket();
        void removeItemFromBasket(Item item);
        void setCurrentBasket(Basket basket);
        void setDeliveryAddress(string address);
        void setEmailAddress(string emailAddress);
        void setFirstName(string firstName);
        void setId(string id);
        void setLastName(string lastName);
        void setPhoneNumber(string phoneNumber);
        void setPurchaseHistory(PurchaseHistory purchaseHistory);
    }
}
