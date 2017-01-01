using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping
{
    public class Shop : IShop
    {

        private string _Id;
        private string _Name;
        private List<ICategory> _MainCategories;
        private List<ICustomer> _Customers;
        private const int _FirstLevel = 0;

        private static Shop _Shop = new Shop();

        public static Shop getInstance()
        {
            return _Shop;
        }
        private Shop()
        {
            this._MainCategories = new List<ICategory>();
            this._Customers = new List<ICustomer>();
        }

        public string getId()
        {
            return this._Id;
        }
        public void setId(string id)
        {
            this._Id = id;
        }
        public string getName()
        {
            return this._Name;
        }
        public void setName(string name)
        {
            this._Name = name;
        }
        public List<ICustomer> getCustomers()
        {
            return this._Customers;
        }
        public void setCustomers(List<ICustomer> customers)
        {
            this._Customers = customers;
        }
        public void addCustomer(ICustomer customer)
        {
            this._Customers.Add(customer);
        }
        public void removeCustomer(ICustomer customer)
        {
            this._Customers.Remove(customer);
        }
        public List<ICategory> getMainCategories()
        {
            return this._MainCategories;
        }
        public List<IItem> getAllItems()
        {
            List<IItem> items = new List<IItem>();
            foreach (var cat in this._MainCategories)
            {
                items.AddRange(cat.getItems());
            }
            return items;
        }
        public bool checkExistingItemStock(IItem item, uint count)
        {
            List<IItem> items = this.getAllItems();
            IItem existingItem = items.Find(i => i.getSerialNumber() == item.getSerialNumber());
            if (existingItem.Equals(null))
                return false;            
            return existingItem.getCount() >= count;
            
        }
        public bool updateExistingItemStock(IItem item, uint count, bool inc = true)
        {
            if (inc)
            {
                List<IItem> items = this.getAllItems();
                IItem existingItem = items.Find(i => i.getSerialNumber() == item.getSerialNumber());
                if (!existingItem.Equals(null))
                {
                    item.incCount(count);
                }
            }
            else if(this.checkExistingItemStock(item, count))
            {
                item.decCount(count);
                return true;
            }
            return false;
        }
        public void setMainCategories(List<ICategory> categories)
        {
            foreach(var cat in categories)
            {
                cat.setLevel(_FirstLevel);
            }
            this._MainCategories = categories;
        }
        public void addMainCategory(ICategory mainCategory)
        {
            mainCategory.setLevel(_FirstLevel);
            this._MainCategories.Add(mainCategory);
        }
        public void removeMainCategory(ICategory mainCategory)
        {
            this._MainCategories.Remove(mainCategory);
        }
        public List<IBasket> getShopPurchaseHistory()
        {
            List<IBasket> purchaseHistory = new List<IBasket>();
            List<IBasket> customerPurchased;
            foreach (var customer in this._Customers)
            {
                customerPurchased = customer.getPurchaseHistory().getPurchseRecords();
                purchaseHistory.AddRange(customerPurchased);
            }
            return purchaseHistory;
        }
        public IList<IItem> search(IItemSpec spec)
        {
            List<IItem> result = new List<IItem>();
            foreach(var cat in this._MainCategories)
            {
                result.AddRange(cat.search(spec));
            }
            return result.AsReadOnly();
        }
        public IList<IItem> strictSearch(IItemSpec spec)
        {
            List<IItem> result = new List<IItem>();
            foreach (var cat in this._MainCategories)
            {
                result.AddRange(cat.search(spec));
            }
            return result.AsReadOnly();
        }
    }
}
