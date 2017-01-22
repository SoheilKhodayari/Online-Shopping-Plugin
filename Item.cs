using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopping
{
    
    public class Item : IItem
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        //[Column(TypeName = "VARCHAR")]
        //[StringLength(450)]
        //[Index("Unique_SerialNumber_Constraint",IsUnique = true)]
        public string _SerialNumber {get; set;}
        public string _Name { get; set; }
        public decimal _Price { get; set; }
        public int _Count { get; set; }
        public virtual ItemSpec _Spec { get; set; }

        public Item(string serialNumber, string name, decimal price, uint count, ItemSpec spec)
        {
            this._SerialNumber = serialNumber;
            this._Name = name;
            this._Price = price;
            this._Count = (int)count;
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
        public void setCount(uint count)
        {
            this._Count = (int)count;
        }
        public uint getCount()
        {
            return (uint)this._Count;
        }
        public void incCount(uint count)
        {
            this._Count += (int)count;
        }
        public bool decCount(uint count)
        {
            if (this._Count < (int)count)
                return false;
            this._Count -= (int)count;
            return true;
        }
        public Item clone()
        {
            Item item = new Item(this._SerialNumber
                                ,this._Name
                                ,this._Price
                                ,(uint)this._Count
                                ,this._Spec);
            return item;
        }
    }

    //public class CloneItem : Item
    //{
    //    public CloneItem(string serialNumber, string name, decimal price, uint count, ItemSpec spec):
    //        base(serialNumber, name, price, count, spec)
    //    {

    //    }
    //    // Nothing Here, Only a Workaround over EF problem of multiple bbject sets per type
    //}
}
