using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping
{
    public class Item
    {
        private int _Id;
        private string _Name;
        private decimal _Price;
        private string _ProducerName;
        private ItemSpec _Spec;

        public Item(int Id, string name, decimal price, string producerName, ItemSpec spec)
        {
            this._Id = Id;
            this._Name = name;
            this._Price = price;
            this._ProducerName = producerName;
            this._Spec = spec;
        }
    }
}
