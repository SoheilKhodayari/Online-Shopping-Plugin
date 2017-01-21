using System;
using System.Collections.Generic;
namespace OnlineShopping
{
    public interface IShop
    {
        string getId();
        void setId(string id);
        string getName();
        void setName(string name);
        void addCustomer(Customer customer);
        void removeCustomer(Customer customer);
        List<Customer> getCustomers();
        void setCustomers(List<Customer> customers);
        void addMainCategory(ICategory mainCategory);
        void removeMainCategory(ICategory mainCategory);
        List<ICategory> getMainCategories();
        void setMainCategories(List<ICategory> categories);
        bool checkExistingItemStock(Item item, uint count);
        bool updateExistingItemStock(Item item, uint count, bool inc = true);
        List<Item> getAllItems();
        List<Basket> getShopPurchaseHistory();
        IList<Item> search(ItemSpec spec);
        IList<Item> strictSearch(ItemSpec spec);
    }
}
