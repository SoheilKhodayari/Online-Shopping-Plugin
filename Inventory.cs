using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping
{
    public class Inventory
    {
        private const int _firstLevel = 0;
        private string _Id;
        private string _Name;
        private List<Category> _mainCategories;

        public Inventory(string id, string name)
        {
            this._Id = id;
            this._Name = name;
            this._mainCategories = new List<Category>();
        }
        public Inventory(string id, string name, List<Category> categories)
        {
            this._Id = id;
            this._Name = name;

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
        public List<Category> getMainCategories()
        {
            return this._mainCategories;
        }
        public void setMainCategories(List<Category> categories)
        {
            foreach(var cat in categories)
            {
                cat.setLevel(_firstLevel);
            }
            this._mainCategories = categories;
        }
        public List<Item> getAllItems()
        {
            List<Item> items = new List<Item>();
            foreach(var cat in this._mainCategories)
            {
                items.AddRange(cat.getItems());
            }
            return items;
        }
        public void addMainCategory(Category mainCategory)
        {
            mainCategory.setLevel(_firstLevel);
            this._mainCategories.Add(mainCategory);
        }

        public IList<Item> search(ItemSpec spec)
        {
            List<Item> result = new List<Item>();
            foreach(var cat in this._mainCategories)
            {
                result.AddRange(cat.search(spec));
            }
            return result.AsReadOnly();
        }
        public IList<Item> strictSearch(ItemSpec spec)
        {
            List<Item> result = new List<Item>();
            foreach (var cat in this._mainCategories)
            {
                result.AddRange(cat.search(spec));
            }
            return result.AsReadOnly();
        }
    }
}
