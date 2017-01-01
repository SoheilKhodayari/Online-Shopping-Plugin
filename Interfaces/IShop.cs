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
        void addCustomer(ICustomer customer);
        void removeCustomer(ICustomer customer);
        List<ICustomer> getCustomers();
        void setCustomers(List<ICustomer> customers);
        void addMainCategory(ICategory mainCategory);
        void removeMainCategory(ICategory mainCategory);
        List<ICategory> getMainCategories();
        void setMainCategories(List<ICategory> categories);
        bool checkExistingItemStock(IItem item, uint count, bool inc = true);
        bool updateExistingItemStock(IItem item, uint count, bool inc = true);
        List<IItem> getAllItems();
        List<IBasket> getShopPurchaseHistory();
        IList<IItem> search(IItemSpec spec);
        IList<IItem> strictSearch(IItemSpec spec);
    }
}
