using System;
namespace OnlineShopping
{
    interface IItem
    {
        string getName();
        decimal getPrice();
        string getSerialNumber();
        ItemSpec getSpec();
        void setName(string name);
        void setPrice(decimal price);
        void setSerialNumber(string serialNumber);
        void setSpec(ItemSpec spec);
    }
}
