using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping
{
    public class PurchaseHistory : OnlineShopping.IPurchaseHistory
    {
        private string _Id;
        private List<Basket> _Records;

        public PurchaseHistory(string id)
        {
            this._Id = id;
            this._Records = new List<Basket>();
        }
        public PurchaseHistory(string id, List<Basket> records)
        {
            this._Id = id;
            this._Records = records;
        }

        public string getId()
        {
            return this._Id;
        }
        public void setId(string id)
        {
            this._Id = id;
        }
        public List<Basket> getPurchseRecords()
        {
            return this._Records;
        }
        public void setPurchseRecords(List<Basket> records)
        {
            this._Records = records;
        }
        public void addPurchaseRecord(Basket record)
        {
            this._Records.Add(record);
        }
        public void removePurchaseRecord(Basket record)
        {
            this._Records.Remove(record);
        }
        public void removePurchaseRecords(List<Basket> records)
        {
            foreach (var record in records)
            {
                this._Records.Remove(record);
            }
        }
    }
}
