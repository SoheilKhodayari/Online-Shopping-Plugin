using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OnlineShopping
{
    public class Basket : OnlineShopping.IBasket
    {
        private string _Id;
        private DateTime _PurchaseTime;
        private List<Item> _Items;

        public Basket(string id)
        {
            this._Id = id;
            this._Items = new List<Item>();
        }
        public Basket(string id, List<Item> items)
        {
            this._Id = id;
            this._Items = items;
        }

        public string getId()
        {
            return this._Id;
        }
        public void setId(string id)
        {
            this._Id = id;
        }
        public DateTime getPurchaseTime()
        {
            return this._PurchaseTime;
        }
        public void setPurchaseTime(DateTime time)
        {
            this._PurchaseTime = time;
        }
        public List<Item> getItems()
        {
            return this._Items;
        }
        public bool addItem(Item item, uint count=1)
        {
            Shop shop = Shop.getInstance();
            if(shop.checkExistingItemStock(item, count , false))
            {
                Item newItem = this._Items.Find(i => i.getSerialNumber() == item.getSerialNumber());
                if (newItem != null)
                {
                    newItem.incCount(count);
                }
                else
                {
                    newItem = item.clone();
                    newItem.setCount(count);
                }
                this._Items.Add(newItem);
                return true;
            }
            return false;
        }
        public void removeItem(Item item)
        {
            Shop shop = Shop.getInstance();
            if (shop.checkExistingItemStock(item, item.getCount()))
            {
                this._Items.Remove(item);
            }
        }
        public decimal getTotalPrice()
        {
            decimal price = 0;
            foreach (var item in this._Items)
            {
                price += item.getPrice() * item.getCount();
            }
            return price;
        }
    }
}
