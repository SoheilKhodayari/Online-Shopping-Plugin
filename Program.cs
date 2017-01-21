using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping
{
    public class test
    {
        public string name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*
            ItemCategory ic = new ItemCategory("itemCategoryName");
            NodeCategory nc = new NodeCategory("nodeCategoryName");
            NodeCategory nc2 = new NodeCategory("nodeCategoryName2");
            nc.addCategory(ic);
            nc.addCategory(nc2);
            Console.WriteLine(nc.getChildren()[1].GetType() == typeof(NodeCategory));

            List<int> initialList = new List<int>();
            initialList.Add(1);
            // Put whatever you want in the initial list
            List<int> listToAdd = new List<int>();
            listToAdd.Add(2); listToAdd.Add(3);
            // Put whatever you want in the second list
            initialList.AddRange(listToAdd);
            Console.WriteLine(initialList[0]);
            Console.WriteLine(initialList[1]);
            Console.WriteLine(initialList[2]);
            */
            
            /*
            Customer c = new Customer(null, "Ali", null);
            Basket b = new Basket(null);
            Item i = new Item(null, "name", 10, null);
            i.setCount(10);
            Console.WriteLine(i.getCount());
            b.addItem(i);
            c.addItemToBasket(i);
            Console.WriteLine(i.getCount());
            Console.WriteLine(b.getItems()[0].getCount());
            */
            //IItem i = new Item(null, "name", 10 ,10, null);
            //IItem j = i.clone();
            //j.incCount(1);
            //Console.WriteLine(i.getCount());
            //Console.WriteLine(j.getCount());
            //i.incCount(2);
            //Console.WriteLine(i.getCount());
            //Console.WriteLine(j.getCount());
            //j.incCount(5);
            //Console.WriteLine(i.getCount());
            //Console.WriteLine(j.getCount());


            // serialization example
            //test t = new test();
            //t.name = "soheil";

            //Dictionary<string, Object> dict = new Dictionary<string, Object>();
            //Dictionary<string, Object> dict2;
            //dict.Add("key", t);
            //string json = JsonConvert.SerializeObject(dict, Formatting.Indented);
            ////Console.WriteLine(json);
            //dict2 = JsonConvert.DeserializeObject<Dictionary<string, Object>>(json);

            //JObject obj = (JObject)dict2["key"];
            //test t2 = obj.ToObject<test>();
           // Console.WriteLine(t2.name);

            using(var db = new AppContext())
            {
                Shop shop = Shop.getInstance();
                shop.setName("test-store");
                shop.setId("test-store-id");
                ItemCategory computerCategory = new ItemCategory("Computer");
                ItemSpec spec = new ItemSpec();
                spec.addPropertyIfNotExists("color", "black");
                spec.addPropertyIfNotExists("weight", "2.7kg");
                spec.SyncPropertiesToSerializations();
                db.ItemSpecs.Add(spec);
                Item item = new Item("sf2123122","E571G-Acer-Aspire",500,5,spec);
                db.Items.Add(item);

                computerCategory._Items.Add(item);
                db.Categories.Add(computerCategory);

                shop._MainCategories.Add(computerCategory);
                db.Shops.Add(shop);

                db.SaveChanges();
            }
            

            
            Console.ReadLine();
        }
    }
}
