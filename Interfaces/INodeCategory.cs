using System;
using System.Collections.Generic;

namespace OnlineShopping
{
    interface INodeCategory
    {
        void addCategory(Category category);
        List<Category> getChildren();
        List<Item> getItems();
    }
}
