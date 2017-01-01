using System;
using System.Collections.Generic;


namespace OnlineShopping
{
    interface IItemCategory
    {
        void addItem(Item item);
        List<Item> getItems();
    }
}
