using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping
{
    public abstract class Category
    {
        public string _Name;
        private int _Level;

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

    }
    public class ItemCategory : Category
    {
        private List<Item> _Items;

        public ItemCategory(string name)
        {
            this._Name = name;
            this._Items = new List<Item>();
        }

        public List<Item> getItems()
        {
            return this._Items;
        }

        public void addItem(Item item)
        {
            _Items.Add(item);
        }
    }
    public class NodeCategory : Category
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
    }

}
