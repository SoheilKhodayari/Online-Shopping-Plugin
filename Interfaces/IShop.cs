using System;
using System.Collections.Generic;
namespace OnlineShopping
{
    interface IShop
    {
        void addCustomer(Customer customer);
        void setCustomers(List<Customer> customers);
        List<Customer> getCustomers();

        void addMainCategory(Category mainCategory);
        List<Category> getMainCategories();
        void setMainCategories(List<Category> categories);

        List<Item> getAllItems();
        List<Basket> getShopPurchaseHistory();

        IList<Item> search(ItemSpec spec);
        IList<Item> strictSearch(ItemSpec spec);

        string getId();
        void setId(string id);

        void setName(string name);
        string getName();

    }
}
