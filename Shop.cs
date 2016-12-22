using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping
{
    public class Shop
    {
        private const int _FirstLevel = 0;
        private string _Id;
        private string _Name;
        private List<Category> _MainCategories;
        private List<Customer> _Customers;

        public Shop(string id, string name)
        {
            this._Id = id;
            this._Name = name;
            this._MainCategories = new List<Category>();
            this._Customers = new List<Customer>();
        }
        public Shop(string id, string name, List<Category> categories)
        {
            this._Id = id;
            this._Name = name;
            this._Customers = new List<Customer>();
            setMainCategories(categories);
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
        public List<Category> getMainCategories()
        {
            return this._MainCategories;
        }
        public void setMainCategories(List<Category> categories)
        {
            foreach(var cat in categories)
            {
                cat.setLevel(_FirstLevel);
            }
            this._MainCategories = categories;
        }
        public List<Item> getAllItems()
        {
            List<Item> items = new List<Item>();
            foreach(var cat in this._MainCategories)
            {
                items.AddRange(cat.getItems());
            }
            return items;
        }
        public void addMainCategory(Category mainCategory)
        {
            mainCategory.setLevel(_FirstLevel);
            this._MainCategories.Add(mainCategory);
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
