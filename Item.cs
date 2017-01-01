using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping
{
    
    public class Item : OnlineShopping.IItem
    {
        private string _SerialNumber;
        private string _Name;
        private decimal _Price;
        private uint _Count;
        private IItemSpec _Spec;

        public Item(string serialNumber, string name, decimal price, uint count, IItemSpec spec)
        {
            this._SerialNumber = serialNumber;
            this._Name = name;
            this._Price = price;
            this._Count = count;
            this._Spec = spec;
        }
        public IItemSpec getSpec()
        {
            return this._Spec;
        }
        public string getSerialNumber()
        {
            return this._SerialNumber;
        }
        public string getName()
        {
            return this._Name;
        }
        public decimal getPrice()
        {
            return this._Price;
        }

        public void setSpec(IItemSpec spec)
        {
            this._Spec = spec;
        }
        public void setName(string name)
        {
            this._Name = name;
        }
        public void setPrice(decimal price)
        {
            this._Price = price;
        }
        public void setSerialNumber(string serialNumber)
        {
            this._SerialNumber = serialNumber;
        }
        public void setCount(uint count)
        {
            this._Count = count;
        }
        public uint getCount()
        {
            return this._Count;
        }
        public void incCount(uint count)
        {
            this._Count += count;
        }
        public bool decCount(uint count)
        {
            if (this._Count < count)
                return false;
            this._Count -= count;
            return true;
        }
        public IItem clone()
        {
            IItem item = new Item(this._SerialNumber
                                ,this._Name
                                ,this._Price
                                ,this._Count
                                ,this._Spec);
            return item;
        }
    }
}
