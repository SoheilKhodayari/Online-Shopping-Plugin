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
    public class PurchaseHistory : IPurchaseHistory
    {
        [Key]
        public string _Id {get; set;}
        public virtual List<Basket> _Records { get; set; }

        public PurchaseHistory(string id)
        {
            this._Id = id;
            this._Records = new List<Basket>();
            //var db = AppContext.getInstance();
            //db.PurchaseHistories.Add(this);
            //db.SaveChanges();
        }
        public PurchaseHistory(string id, List<Basket> records)
        {
            this._Id = id;
            this._Records = records;
            //var db = AppContext.getInstance();
            //db.PurchaseHistories.Add(this);
            //db.SaveChanges();
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
