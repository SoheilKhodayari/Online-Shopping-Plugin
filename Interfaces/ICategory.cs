using System;
using System.Collections.Generic;


namespace OnlineShopping
{
    interface ICategory
    {
        List<Item> getItems();
        int getLevel();
        string getName();
        IList<Item> search(ItemSpec spec);
        void setName(string name);
        IList<Item> strictSearch(ItemSpec spec);
    }
}
