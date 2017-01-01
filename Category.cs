using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping
{
    public abstract class Category : OnlineShopping.ICategory
    {
        public string _Name;
        private int _Level;

        public abstract List<Item> getItems();

        public string getName()
        {
            return _Name;
        }
        public void setName(string name)
        {
            this._Name = name;
        }
        public int getLevel()
        {
            return this._Level;
        }
        internal void setLevel(int level)
        {
            this._Level = level;
        }

        public IList<Item> search(ItemSpec spec)
        {
            List<Item> result = new List<Item>();
            foreach (var item in this.getItems())
            {
                if (spec.matches(item.getSpec()))
                {
                    result.Add(item);
                }
            }
            return result.AsReadOnly();
        }
        public IList<Item> strictSearch(ItemSpec spec)
        {
            List<Item> result = new List<Item>();
            foreach (var item in this.getItems())
            {
                if (spec.strictlyMatches(item.getSpec()))
                {
                    result.Add(item);
                }
            }
            return result.AsReadOnly();
        }

    }
    public class ItemCategory : Category, OnlineShopping.IItemCategory
    {
        private List<Item> _Items;

        public ItemCategory(string name)
        {
            this._Name = name;
            this._Items = new List<Item>();
        }

        public override List<Item> getItems()
        {
            return this._Items;
        }

        public void addItem(Item item)
        {
            _Items.Add(item);
        }
    }
    public class NodeCategory : Category, OnlineShopping.INodeCategory
    {
        private List<Category> _Categories;

        public NodeCategory(string name)
        {
            this._Name = name;
            this._Categories = new List<Category>();
        }

        public List<Category> getChildren(){
            return this._Categories;
        }

        public void addCategory(Category category)
        {
            var nextLevel = this.getLevel()+1;
            category.setLevel(nextLevel);
            _Categories.Add(category);
        }

        public override List<Item> getItems()
        {
            List<Item> items = new List<Item>();
            foreach(var cat in this._Categories)
            {
                items.AddRange(cat.getItems());
            }
            return items;
        }
    }

}
