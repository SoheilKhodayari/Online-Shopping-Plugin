using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

            //catch (DbEntityValidationException e)
            //{
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
            //                ve.PropertyName, ve.ErrorMessage);
            //        }
            //    }
            //   // throw;
            //}


            // --------------------------------------simple test---------------------------------//
            var db = AppContext.getInstance();

            Shop shop = Shop.getInstance();
            shop.setName("MyStore");
            shop.setId(Guid.NewGuid().ToString());

            Category digitalProductsCategory = new Category("DigitalProducts");
            ItemCategory laptopCategory = new ItemCategory("Laptop");
            ItemCategory mobileCategory = new ItemCategory("Mobile");


            ItemSpec laptopItemSpec1 = new ItemSpec();
            laptopItemSpec1.addPropertyIfNotExists("color", "black");
            laptopItemSpec1.addPropertyIfNotExists("weight", "2.7 Kg");
            laptopItemSpec1.addPropertyIfNotExists("hdd", "256G SSD");
            laptopItemSpec1.addPropertyIfNotExists("cpu", "Core i7");
            laptopItemSpec1.addPropertyIfNotExists("ram", "DDR3 8M");
            laptopItemSpec1.addPropertyIfNotExists("processor-freq", "2.5GHz up to 3.1 GHz");

            ItemSpec laptopItemSpec2 = new ItemSpec();
            laptopItemSpec2.addPropertyIfNotExists("color", "white");
            laptopItemSpec2.addPropertyIfNotExists("weight", "2.9 Kg");
            laptopItemSpec2.addPropertyIfNotExists("hdd", "1TB 5400 RPM");
            laptopItemSpec2.addPropertyIfNotExists("cpu", "Core i5");
            laptopItemSpec2.addPropertyIfNotExists("ram", "DDR4 8M");
            laptopItemSpec2.addPropertyIfNotExists("processor-freq", "2.4GHz up to 3.2 GHz");
            laptopItemSpec2.addPropertyIfNotExists("usb 3", "2 ports");

            db.ItemSpecs.Add(laptopItemSpec1);
            db.ItemSpecs.Add(laptopItemSpec2);
            db.SaveChanges();

            ItemSpec mobileItemSpec1 = new ItemSpec();
            mobileItemSpec1.addPropertyIfNotExists("color", "black");
            mobileItemSpec1.addPropertyIfNotExists("weight", "0.4kg");
            mobileItemSpec1.addPropertyIfNotExists("camera", "12M");
            mobileItemSpec1.addPropertyIfNotExists("cpu", "arm-cortex-v7");

            ItemSpec mobileItemSpec2 = new ItemSpec();
            mobileItemSpec2.addPropertyIfNotExists("color", "black");
            mobileItemSpec2.addPropertyIfNotExists("weight", "0.4kg");
            mobileItemSpec2.addPropertyIfNotExists("camera", "12M");

            db.ItemSpecs.Add(mobileItemSpec1);
            db.ItemSpecs.Add(mobileItemSpec2);
            db.SaveChanges();

            Item laptopItem1 = new Item(Guid.NewGuid().ToString(), "Acer-Aspire-V571-G", 2500050, 10, laptopItemSpec1);
            Item laptopItem2 = new Item(Guid.NewGuid().ToString(), "Lenovo-Ideapad-310-K", 3100000, 4, laptopItemSpec1);
            Item mobileItem1 = new Item(Guid.NewGuid().ToString(), "Samsung-Galaxy-Note-7", 2400000, 5, mobileItemSpec1);
            Item mobileItem2 = new Item(Guid.NewGuid().ToString(), "Huawei-P8-DualSim", 980000, 5, mobileItemSpec1);

            db.Items.Add(laptopItem1);
            db.Items.Add(laptopItem2);
            db.Items.Add(mobileItem1);
            db.Items.Add(mobileItem2);
            db.SaveChanges();

            laptopCategory.addItem(laptopItem1);
            laptopCategory.addItem(laptopItem2);
            mobileCategory.addItem(mobileItem1);
            mobileCategory.addItem(mobileItem2);
            digitalProductsCategory.addCategory(laptopCategory);
            digitalProductsCategory.addCategory(mobileCategory);
            shop.addMainCategory(digitalProductsCategory);

            //db.Categories.Add(mobileCategory);
            //db.Categories.Add(laptopCategory);
            //db.Categories.Add(digitalProductsCategory);
            //db.Shops.Add(shop);
            //db.SaveChanges();
            if(shop.checkExistingItemStock(mobileItem1, 1))
            {
                Console.WriteLine("this is nhggubghvhgvhgv");
            }



            Basket basket1 = new Basket(Guid.NewGuid().ToString());
            Basket basket2 = new Basket(Guid.NewGuid().ToString());
            db.Baskets.Add(basket1);
            db.Baskets.Add(basket2);
            db.SaveChanges();

            basket1.addItem(laptopItem1);
            basket1.addItem(mobileItem1);
            basket2.addItem(laptopItem2);
            db.SaveChanges();


            var price_basket1 = basket1.getTotalPrice();
            var price_basket2 = basket2.getTotalPrice();
            Console.WriteLine("basket1-price:{0}", price_basket1);
            Console.WriteLine("basket2-price:{0}", price_basket2);


            Customer customer1 = new Customer(Guid.NewGuid().ToString(), "Soheil", "Khodayari", "shl_khodayari@yahoo.com", "Tehran-Narmak-FarjamSt", "09125626987");
            Customer customer2 = new Customer(Guid.NewGuid().ToString(), "Ali", "Vishkaie", "avishkaie@gmail.com", "Tehran-Narmak", "09126547832");

            db.Customers.Add(customer1);
            db.Customers.Add(customer2);
            db.SaveChanges();


            customer1.setCurrentBasket(basket1);
            db.SaveChanges();

            bool result = customer1.PurchaseCurrentBasket();
            db.SaveChanges();

            if (result)
            {
                PurchaseHistory purchaseHistoryCustomer1 = customer1.getPurchaseHistory();
                foreach (var basket in purchaseHistoryCustomer1.getPurchseRecords())
                {
                    Console.WriteLine("-Purchased On: {0}\n", basket.getPurchaseTime());
                    foreach (var item in basket.getItems())
                    {
                        Console.WriteLine(string.Format(" Item Name: {0}, Price: {1}, Count: {2}\n", item.getName(), item.getPrice(), item.getCount()));
                    }
                }
            }
            else
            {
                Console.WriteLine("Message: Could not buy Item!");
            }



            //var LaptopItemSpec1 = db.ItemSpecs.Where(i => i._Id == 25).FirstOrDefault();
            //var LaptopItemSpec2 = db.ItemSpecs.Where(i => i._Id == 26).FirstOrDefault();
            //var mobileItemSpec1 = db.ItemSpecs.Where(i => i._Id == 27).FirstOrDefault();
            //var mobileItemSpec2 = db.ItemSpecs.Where(i => i._Id == 28).FirstOrDefault();



            //if (mobileItemSpec1.matches(mobileItemSpec2))
            //{
            //    Console.WriteLine("true");
            //}
            //if (!mobileItemSpec1.strictlyMatches(mobileItemSpec2))
            //{
            //    Console.WriteLine("true");
            //}


            //Dictionary<string, object> sim;
            //sim = mobileItemSpec2.getSameProperties(mobileItemSpec2);
            //foreach (KeyValuePair<string, object> kvp in sim)
            //{
            //    Console.WriteLine(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
            //}

            //Console.WriteLine("------Item1------");
            //foreach (KeyValuePair<string, object> kvp in LaptopItemSpec1.getProperties())
            //{
            //    Console.WriteLine(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
            //}
            //Console.WriteLine("------Item2------");
            //foreach (KeyValuePair<string, object> kvp in LaptopItemSpec2.getProperties())
            //{
            //    Console.WriteLine(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
            //}

            //Tuple<Dictionary<string, Object>, Dictionary<string, Object>> diff;
            //diff = LaptopItemSpec2.getDifferentProperties(LaptopItemSpec1);
            //Console.WriteLine("------diff1------");
            //foreach (KeyValuePair<string, object> kvp in diff.Item1)
            //{
            //    Console.WriteLine(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
            //}
            //Console.WriteLine("------diff2------");
            //foreach (KeyValuePair<string, object> kvp in diff.Item2)
            //{
            //    Console.WriteLine(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
            //}

            ItemSpec sad = db.ItemSpecs.Where(i => i._Id == 25).FirstOrDefault();
            sad.getProperties();

            Console.WriteLine("Finished!");
            Console.ReadLine();


        }

    }
}
