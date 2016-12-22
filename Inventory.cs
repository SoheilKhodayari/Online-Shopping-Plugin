using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping
{
    class Inventory
    {

        private int _Id;
        private List<Category> _mainCategories;
        private const int _firstLevel = 0;

        public int getId()
        {
            return this._Id;
        }
        public void setId(int id)
        {
            this._Id = id;
        }
        public List<Category> getMainCategories()
        {
            return this._mainCategories;
        }

        // --- Methods
        public void addMainCategory(Category mainCategory)
        {
            mainCategory.setLevel(_firstLevel);
            this._mainCategories.Add(mainCategory);
        }
    }
}
