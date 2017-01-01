using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping
{
    public class Shop : OnlineShopping.IShop, OnlineShopping.IShop
    {
        private const int _FirstLevel = 0;
        private string _Id;
        private string _Name;
        private List<Category> _MainCategories;
        private List<Customer> _Customers;
        
        private static Shop _Shop = new Shop();

        public static Shop getInstance()
        {
            return _Shop;
        }
        private Shop()
        {
            this._MainCategories = new List<Category>();
            this._Customers = new List<Customer>();
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
        public List<Customer> getCustomers()
        {
            return this._Customers;
        }
        public void setCustomers(List<Customer> customers)
        {
            this._Customers = customers;
        }
        public void addCustomer(Customer customer)
        {
            this._Customers.Add(customer);
        }
        public void removeCustomer(Customer customer)
        {
            this._Customers.Remove(customer);
        }
        public List<Category> getMainCategories()
        {
            return this._MainCategories;
        }
        public List<Item> getAllItems()
        {
            List<Item> items = new List<Item>();
            foreach (var cat in this._MainCategories)
            {
                items.AddRange(cat.getItems());
            }
            return items;
        }
        public bool checkExistingItemStock(Item item, uint count, bool inc=true)
        {
            List<Item> items = this.getAllItems();
            Item existingItem = items.Find(i => i.getSerialNumber() == item.getSerialNumber());
            if (existingItem.Equals(null))
                return false;            
            if (!inc)
            {
                return existingItem.getCount() >= count;
            }
            return true;
        }
        public bool updateExistingItemStock(Item item, uint count, bool inc = true)
        {
            if(this.checkExistingItemStock(item, count, inc))
            {
                if (inc)
                {
                    item.incCount(count);
                }
                else
                {
                    item.decCount(count);
                }

                return true;
            }
            return false;
        }
        public void setMainCategories(List<Category> categories)
        {
            foreach(var cat in categories)
            {
                cat.setLevel(_FirstLevel);
            }
            this._MainCategories = categories;
        }
        public void addMainCategory(Category mainCategory)
        {
            mainCategory.setLevel(_FirstLevel);
            this._MainCategories.Add(mainCategory);
        }
        public void removeMainCategory(Category mainCategory)
        {
            this._MainCategories.Remove(mainCategory);
        }
        public List<Basket> getShopPurchaseHistory()
        {
            List<Basket> purchaseHistory = new List<Basket>();
            List<Basket> customerPurchased;
            foreach (var customer in this._Customers)
            {
                customerPurchased = customer.getPurchaseHistory().getPurchseRecords();
                purchaseHistory.AddRange(customerPurchased);
            }
            return purchaseHistory;
        }
        public IList<Item> search(ItemSpec spec)
        {
            List<Item> result = new List<Item>();
            foreach(var cat in this._MainCategories)
            {
                result.AddRange(cat.search(spec));
            }
            return result.AsReadOnly();
        }
        public IList<Item> strictSearch(ItemSpec spec)
        {
            List<Item> result = new List<Item>();
            foreach (var cat in this._MainCategories)
            {
                result.AddRange(cat.search(spec));
            }
            return result.AsReadOnly();
        }
    }
}
