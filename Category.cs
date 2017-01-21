using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping
{
    public abstract class ICategory
    {
        [Key]
        public int _Id {get; set;}
        public int _Level { get; set; }
        public string _Name { get; set; }

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
    public class ItemCategory : ICategory

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
            Item existingItem = this._Items.Find(i => i.getSerialNumber() == item.getSerialNumber());
            if (existingItem != null)
                existingItem.incCount(item.getCount());
            else
                this._Items.Add(item);
        }
        public void removeItem(Item item)
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
