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
        internal ICategory()
        {

        }

        public IList<Item> search(ItemSpec spec)
        {
            List<Item> result = new List<Item>();
            var db = AppContext.getInstance();
            List<Item> allItems = db.Categories.Where(c => c._Id == this._Id).FirstOrDefault().getItems();
            foreach (var item in allItems)
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
            var db = AppContext.getInstance();
            List<Item> allItems = db.Categories.Where(c => c._Id == this._Id).FirstOrDefault().getItems();
            foreach (var item in allItems)
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
        public List<Item> _Items {get; set;}

        public ItemCategory(string name)
        {
            this._Name = name;
            this._Items = new List<Item>();
        }
        internal ItemCategory()
        {

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
        public List<ICategory> _Categories { get; set; }

        internal Category()
        {

        }
        public Category(string name)
        {
            this._Name = name;
            this._Categories = new List<ICategory>();
        }

        public List<ICategory> getCategories(){
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
