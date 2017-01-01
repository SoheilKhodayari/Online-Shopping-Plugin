using System;
using System.Collections.Generic;
namespace OnlineShopping
{
    interface IShop
    {
        void addCustomer(Customer customer);
        void addMainCategory(Category mainCategory);
        bool checkExistingItemStock(Item item, uint count, bool inc = true);
        List<Item> getAllItems();
        List<Customer> getCustomers();
        string getId();
        List<Category> getMainCategories();
        string getName();
        List<Basket> getShopPurchaseHistory();
        void removeCustomer(Customer customer);
        void removeMainCategory(Category mainCategory);
        IList<Item> search(ItemSpec spec);
        void setCustomers(List<Customer> customers);
        void setId(string id);
        void setMainCategories(List<Category> categories);
        void setName(string name);
        IList<Item> strictSearch(ItemSpec spec);
        bool updateExistingItemStock(Item item, uint count, bool inc = true);
    }
}
