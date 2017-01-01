using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping
{
    public class PurchaseHistory : IPurchaseHistory
    {
        private string _Id;
        private List<IBasket> _Records;

        public PurchaseHistory(string id)
        {
            this._Id = id;
            this._Records = new List<IBasket>();
        }
        public PurchaseHistory(string id, List<IBasket> records)
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
        public List<IBasket> getPurchseRecords()
        {
            return this._Records;
        }
        public void setPurchseRecords(List<IBasket> records)
        {
            this._Records = records;
        }
        public void addPurchaseRecord(IBasket record)
        {
            this._Records.Add(record);
        }
        public void removePurchaseRecord(IBasket record)
        {
            this._Records.Remove(record);
        }
        public void removePurchaseRecords(List<IBasket> records)
        {
            foreach (var record in records)
            {
                this._Records.Remove(record);
            }
        }
    }
}
