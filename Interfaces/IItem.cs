using System;
using System.Collections.Generic;
namespace OnlineShopping
{
    public interface IItem
    {
        IItem clone();
        bool decCount(uint count);
        uint getCount();
        string getName();
        decimal getPrice();
        string getSerialNumber();
        IItemSpec getSpec();
        void incCount(uint count);
        void setCount(uint count);
        void setName(string name);
        void setPrice(decimal price);
        void setSerialNumber(string serialNumber);
        void setSpec(IItemSpec spec);
    }
}
