using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping
{
    public class Shop : IShop
    {

        [Key]
        public string _Id {get; set;}
        public string _Name { get; set; }
        public virtual List<ICategory> _MainCategories { get; set; }
        public virtual List<Customer> _Customers { get; set; }

        private const int _FirstLevel = 0;

        private static Shop _Shop = new Shop();

        public static Shop getInstance()
        {
            return _Shop;
        }
        private Shop()
        {
            this._MainCategories = new List<ICategory>();
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
        public List<ICategory> getMainCategories()
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
        public bool checkExistingItemStock(Item item, uint count)
        {
            List<Item> items = this.getAllItems();
            Item existingItem = items.Find(i => i.getSerialNumber() == item.getSerialNumber());
            if (existingItem.Equals(null))
                return false;            
            return existingItem.getCount() >= count;
            
        }
        public bool updateExistingItemStock(Item item, uint count, bool inc = true)
        {
            var db = AppContext.getInstance();
            if (inc)
            {
                List<Item> items = this.getAllItems();
                Item existingItem = items.Find(i => i.getSerialNumber() == item.getSerialNumber());
                if (!existingItem.Equals(null))
                {
                    item.incCount(count);
                    db.SaveChanges();
                }
            }
            else if(this.checkExistingItemStock(item, count))
            {
                item.decCount(count);
                db.SaveChanges();
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
