using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping
{
    
    public class Item
    {
        private string _SerialNumber;
        private string _Name;
        private decimal _Price;
        private ItemSpec _Spec;

        public Item(string serialNumber, string name, decimal price, ItemSpec spec)
        {
            this._SerialNumber = serialNumber;
            this._Name = name;
            this._Price = price;
            this._Spec = spec;
        }
        public ItemSpec getSpec()
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

        public void setSpec(ItemSpec spec)
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

    }
}
