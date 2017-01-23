using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineShopping
{
    public class Customer : ICustomer
    {
        [Key]
        public string _Id { get; set; }
        public string _FirstName { get; set; }
        public string _LastName { get; set; }
        public string _EmailAddress { get; set; }
        public string _DeliveryAddress { get; set; }
        public string _Phone { get; set; }
        public virtual Basket _CurrentBasket { get; set; }
        public virtual PurchaseHistory _PurchaseHistory { get; set; }

        private static readonly object _syncLock = new object();
        public Customer(string id, string firstName, string lastName)
        {
            this._Id = id;
            this._FirstName = firstName;
            this._LastName = lastName;
            //this._CurrentBasket = new Basket(null);
            this._CurrentBasket = null;
            this._PurchaseHistory = null;

            
        }
        public Customer(string id, string firstName, string lastName, string emailAddress, string address, string phone)
        {
            this._Id = id;
            this._FirstName = firstName;
            this._LastName = lastName;
            this._EmailAddress = emailAddress;
            this._DeliveryAddress = address;
            this._Phone = phone;
            //this._CurrentBasket = new Basket(null);
            //this._PurchaseHistory = new PurchaseHistory(null);

            this._CurrentBasket = null;
            this._PurchaseHistory = null;
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
        public void addItemToBasket(Item item, uint count=1)
        {
            if(this._CurrentBasket == null)
            {
                this._CurrentBasket = new Basket(Guid.NewGuid().ToString());
            }
            this._CurrentBasket.addItem(item, count);
        }
        public void removeItemFromBasket(Item item)
        {
            if(this._CurrentBasket == null)
            {
                return;
            }
            this._CurrentBasket.removeItem(item);
        }
        public PurchaseHistory getPurchaseHistory()
        {
            return this._PurchaseHistory;
        }
        public void setPurchaseHistory(PurchaseHistory purchaseHistory)
        {
            this._PurchaseHistory = purchaseHistory;
        }
        public bool PurchaseCurrentBasket()
        {
            Shop shop = Shop.getInstance();
            lock (_syncLock)
            {
                foreach (var item in this._CurrentBasket.getItems())
                {
                    if (!shop.checkExistingItemStock(item, item.getCount()))
                        return false;
                }
                foreach (var item in this._CurrentBasket.getItems())
                {
                    shop.updateExistingItemStock(item, item.getCount(), false);
                }
            }
            this._CurrentBasket.setPurchaseTime(DateTime.Now);
            
            if(this._PurchaseHistory == null)
            {
                this._PurchaseHistory = new PurchaseHistory(Guid.NewGuid().ToString());
                this._PurchaseHistory.addPurchaseRecord(this._CurrentBasket);
            }
            else
            {
                this._PurchaseHistory.addPurchaseRecord(this._CurrentBasket);
            }
            this._CurrentBasket = null;
            
            return true;
        }

    }
}
