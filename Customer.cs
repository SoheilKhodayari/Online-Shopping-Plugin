﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping
{
    public class Customer
    {
        private string _Id;
        private string _FirstName;
        private string _LastName;
        private string _EmailAddress;
        private string _DeliveryAddress;
        private string _Phone;
        private Basket _CurrentBasket;
        private PurchaseHistory _PurchaseHistory;

        public Customer(string id, string firstName, string lastName)
        {
            this._Id = id;
            this._FirstName = firstName;
            this._LastName = lastName;
            this._CurrentBasket = new Basket(null);
            this._PurchaseHistory = new PurchaseHistory(null);
        }
        public Customer(string id, string firstName, string lastName, string emailAddress, string address, string phone)
        {
            this._Id = id;
            this._FirstName = firstName;
            this._LastName = lastName;
            this._EmailAddress = emailAddress;
            this._DeliveryAddress = address;
            this._Phone = phone;
            this._CurrentBasket = new Basket(null);
            this._PurchaseHistory = new PurchaseHistory(null);
        }
        public string getId()
        {
            return this._Id;
        }
        public void setId(string id)
        {
            this._Id = id;
        }
        public string getFirstName()
        {
            return this._FirstName;
        }
        public void setFirstName(string firstName)
        {
            this._FirstName = firstName;
        }
        public string getLastName()
        {
            return this._LastName;
        }
        public void setLastName(string lastName)
        {
            this._LastName = lastName;
        }
        public string getPhoneNumber()
        {
            return this._Phone;
        }
        public void setPhoneNumber(string phoneNumber)
        {
            this._Phone = phoneNumber;
        }
        public string getEmailAddress()
        {
            return this._EmailAddress;
        }
        public void setEmailAddress(string emailAddress)
        {
            this._EmailAddress = emailAddress;
        }
        public string getDeliveryAddress()
        {
            return this._DeliveryAddress;
        }
        public void setDeliveryAddress(string address)
        {
            this._DeliveryAddress = address;
        }
        public Basket getCurrentBasket()
        {
            return this._CurrentBasket;
        }
        public void setCurrentBasket(Basket basket)
        {
            this._CurrentBasket = basket;
        }
        public void addItemToBasket(Item item)
        {
            this._CurrentBasket.addItem(item);
        }
        public PurchaseHistory getPurchaseHistory()
        {
            return this._PurchaseHistory;
        }
        public void setPurchaseHistory(PurchaseHistory purchaseHistory)
        {
            this._PurchaseHistory = purchaseHistory;
        }
        public void PurchaseCurrentBasket()
        {
            this._CurrentBasket.setPurchaseTime(DateTime.Now);
            this._PurchaseHistory.addPurchaseRecord(this._CurrentBasket);
            this._CurrentBasket = new Basket(null);
        }

    }
}
