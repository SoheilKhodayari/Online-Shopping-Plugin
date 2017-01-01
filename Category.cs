using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping
{
    public abstract class ICategory
    {
        public string _Name;
        private int _Level;

        public abstract List<IItem> getItems();

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

        public IList<IItem> search(IItemSpec spec)
        {
            List<IItem> result = new List<IItem>();
            foreach (var item in this.getItems())
            {
                if (spec.matches(item.getSpec()))
                {
                    result.Add(item);
                }
            }
            return result.AsReadOnly();
        }
        public IList<IItem> strictSearch(IItemSpec spec)
        {
            List<IItem> result = new List<IItem>();
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
    public class ItemCategory : ICategory

    {
        private List<IItem> _Items;

        public ItemCategory(string name)
        {
            this._Name = name;
            this._Items = new List<IItem>();
        }

        public override List<IItem> getItems()
        {
            return this._Items;
        }

        public void addItem(IItem item)
        {
            IItem existingItem = this._Items.Find(i => i.getSerialNumber() == item.getSerialNumber());
            if (existingItem != null)
                existingItem.incCount(item.getCount());
            else
                this._Items.Add(item);
        }
        public void removeItem(IItem item)
        {
            this._Items.Remove(item);
        }
    }
    public class Category : ICategory

    {
        private List<ICategory> _Categories;

        public Category(string name)
        {
            this._Name = name;
            this._Categories = new List<ICategory>();
        }

        public List<ICategory> getChildren(){
            return this._Categories;
        }

        public void addCategory(ICategory category)
        {
            var nextLevel = this.getLevel()+1;
            category.setLevel(nextLevel);
            _Categories.Add(category);
        }

        public void removeCategory(ICategory category)
        {
            this._Categories.Remove(category);
        }

        public override List<IItem> getItems()
        {
            List<IItem> items = new List<IItem>();
            foreach(var cat in this._Categories)
            {
                items.AddRange(cat.getItems());
            }
            return items;
        }
    }

}
