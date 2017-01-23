using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShopping.Interfaces;
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
           
            var db = AppContext.getInstance();

            Shop shop = Shop.getInstance();
            shop.setName("MyStore");
            shop.setId(Guid.NewGuid().ToString());

            db.Shops.Add(shop);
            db.SaveChanges();

            //------- digital Products
            Category digitalProductsCategory = new Category("DigitalProducts");
            shop.addMainCategory(digitalProductsCategory);

            ItemCategory laptopCategory = new ItemCategory("Laptop");
            ItemCategory mobileCategory = new ItemCategory("Mobile");

            digitalProductsCategory.addCategory(laptopCategory);
            digitalProductsCategory.addCategory(mobileCategory);

            
            //------- Sport Products
            Category sportCategory = new Category("SportProducts");
            shop.addMainCategory(sportCategory);

            ItemCategory SportItemsCategory = new ItemCategory("SportItems");
            ItemCategory ShoesCategory = new ItemCategory("Shoes");
            ItemCategory ShirtsCategory = new ItemCategory("Shirts");

            sportCategory.addCategory(SportItemsCategory);
            sportCategory.addCategory(ShoesCategory);
            sportCategory.addCategory(ShirtsCategory);


            //------- labtop spec 1
            ItemSpec laptopItemSpec1 = new ItemSpec();
            laptopItemSpec1.addPropertyIfNotExists("color", "black");
            laptopItemSpec1.addPropertyIfNotExists("weight", "2.7 Kg");
            laptopItemSpec1.addPropertyIfNotExists("hdd", "256G SSD");
            laptopItemSpec1.addPropertyIfNotExists("cpu", "Core i7");
            laptopItemSpec1.addPropertyIfNotExists("ram", "DDR3 8M");
            laptopItemSpec1.addPropertyIfNotExists("processor-freq", "2.5GHz up to 3.1 GHz");

            //------- labtop spec 2
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

            //--------- mobile spec 1
            ItemSpec mobileItemSpec1 = new ItemSpec();
            mobileItemSpec1.addPropertyIfNotExists("color", "black");
            mobileItemSpec1.addPropertyIfNotExists("weight", "0.4kg");
            mobileItemSpec1.addPropertyIfNotExists("camera", "12M");
            mobileItemSpec1.addPropertyIfNotExists("cpu", "arm-cortex-v7");

            //--------- mobile spec 2
            ItemSpec mobileItemSpec2 = new ItemSpec();
            mobileItemSpec2.addPropertyIfNotExists("color", "black");
            mobileItemSpec2.addPropertyIfNotExists("weight", "0.4kg");
            mobileItemSpec2.addPropertyIfNotExists("camera", "12M");

            db.ItemSpecs.Add(mobileItemSpec1);
            db.ItemSpecs.Add(mobileItemSpec2);
            db.SaveChanges();

            //--------- Shoes Spec 1
            ItemSpec ShoesSpec1 = new ItemSpec();
            ShoesSpec1.addPropertyIfNotExists("size", "42");
            ShoesSpec1.addPropertyIfNotExists("color", "red");
            ShoesSpec1.addPropertyIfNotExists("brand", "adidas");

            //--------- Shoes Spec 2
            ItemSpec ShoesSpec2 = new ItemSpec();
            ShoesSpec1.addPropertyIfNotExists("size", "44");
            ShoesSpec1.addPropertyIfNotExists("color", "red");

            //--------- Shoes Spec 3
            ItemSpec ShoesSpec3 = new ItemSpec();
            ShoesSpec1.addPropertyIfNotExists("size", "40");
            ShoesSpec1.addPropertyIfNotExists("color", "blue");
            ShoesSpec1.addPropertyIfNotExists("brand", "nike");

            db.ItemSpecs.Add(ShoesSpec1);
            db.ItemSpecs.Add(ShoesSpec2);
            db.ItemSpecs.Add(ShoesSpec3);
            db.SaveChanges();


            //--------- Shirt Spec 1
            ItemSpec ShirtSpec1 = new ItemSpec();
            ShirtSpec1.addPropertyIfNotExists("size", "large");
            ShirtSpec1.addPropertyIfNotExists("color", "red");
            ShirtSpec1.addPropertyIfNotExists("brand", "adidas");

            //--------- shirt Spec 2
            ItemSpec ShirtSpec2 = new ItemSpec();
            ShirtSpec2.addPropertyIfNotExists("size", "large");
            ShirtSpec2.addPropertyIfNotExists("color", "red");
            ShirtSpec2.addPropertyIfNotExists("type", "running");

            //--------- Shirt Spec 3
            ItemSpec ShirtSpec3 = new ItemSpec();
            ShirtSpec3.addPropertyIfNotExists("size", "xlarge");
            ShirtSpec3.addPropertyIfNotExists("color", "blue");
            ShirtSpec3.addPropertyIfNotExists("brand", "nike");
            ShirtSpec3.addPropertyIfNotExists("quality", "prefect");

            db.ItemSpecs.Add(ShirtSpec1);
            db.ItemSpecs.Add(ShirtSpec2);
            db.ItemSpecs.Add(ShirtSpec3);
            db.SaveChanges();

            // --- items
            Item labtop_1 = new Item(Guid.NewGuid().ToString(), "Acer-Aspire-V571-G", 2500050, 10, laptopItemSpec1);
            Item labtop_2 = new Item(Guid.NewGuid().ToString(), "Lenovo-Ideapad-310-K", 3100000, 4, laptopItemSpec2);
            Item mobile_1 = new Item(Guid.NewGuid().ToString(), "Samsung-Galaxy-Note-7", 2400000, 5, mobileItemSpec1);
            Item mobile_2 = new Item(Guid.NewGuid().ToString(), "Huawei-P8-DualSim", 980000, 5, mobileItemSpec2);
            Item Shoes_1 = new Item(Guid.NewGuid().ToString(), "adidas-ultra boost itd", 420000, 15, ShoesSpec1);
            Item Shoes_2 = new Item(Guid.NewGuid().ToString(), "adidas-tabular runner", 760000, 20, ShoesSpec2);
            Item Shoes_3 = new Item(Guid.NewGuid().ToString(), "nike-Jordan Flight Flex Trainer 2", 580000, 25, ShoesSpec3);
            Item Shirt_1 = new Item(Guid.NewGuid().ToString(), "adidas", 242000, 15, ShirtSpec1);
            Item Shirt_2 = new Item(Guid.NewGuid().ToString(), "puma", 176000, 20, ShirtSpec2);
            Item Shirt_3 = new Item(Guid.NewGuid().ToString(), "nike", 258000, 25, ShirtSpec3);

            db.Items.Add(labtop_1);
            db.Items.Add(labtop_2);
            db.Items.Add(mobile_1);
            db.Items.Add(mobile_2);
            db.Items.Add(Shoes_1);
            db.Items.Add(Shoes_2);
            db.Items.Add(Shoes_3);
            db.Items.Add(Shirt_1);
            db.Items.Add(Shirt_2);
            db.Items.Add(Shirt_3);
            db.SaveChanges();

            //--- add items to thier categories
            laptopCategory.addItem(labtop_1);
            laptopCategory.addItem(labtop_2);
            mobileCategory.addItem(mobile_1);
            mobileCategory.addItem(mobile_2);
            ShoesCategory.addItem(Shoes_1);
            ShoesCategory.addItem(Shoes_2);
            ShoesCategory.addItem(Shoes_3);
            ShirtsCategory.addItem(Shirt_1);
            ShirtsCategory.addItem(Shirt_2);
            ShirtsCategory.addItem(Shirt_3);
            db.SaveChanges();


            //-- customers
            Customer customer1 = new Customer(Guid.NewGuid().ToString(), "Soheil", "Khodayari", "shl_khodayari@yahoo.com", "Tehran-Narmak-FarjamSt", "09125626987");
            Customer customer2 = new Customer(Guid.NewGuid().ToString(), "Ali", "Vishkaie", "avishkaie@gmail.com", "Tehran-Narmak", "09126547832");

            shop.addCustomer(customer1);
            shop.addCustomer(customer2);


            // customer1 shopping
            customer1.addItemToBasket(labtop_1, 2);
            customer1.addItemToBasket(mobile_2);
            db.SaveChanges();

            var price_basket1 = customer1.getCurrentBasket().getTotalPrice();
            Console.WriteLine("basket1-price:{0}", price_basket1);

            // customer2 shopping
            customer2.addItemToBasket(Shoes_3);
            customer2.addItemToBasket(Shirt_2,2);
            customer2.addItemToBasket(Shirt_1);
            db.SaveChanges();

            var price_basket2 = customer2.getCurrentBasket().getTotalPrice();
            Console.WriteLine("basket2-price:{0}", price_basket2);

            //---------- customer1 purchased his basket
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


            //---- search test
            Dictionary<string,Object> searchDict = new Dictionary<string,Object>();
            searchDict.Add("color","black");
            ItemSpec searchSpec = new ItemSpec(searchDict);
            IList<Item> searchResults = shop.search(searchSpec);
            foreach(var item in searchResults)
            {
                Console.WriteLine(item.getName());
            }

            
            //fetch spec from db
            var l1 = db.ItemSpecs.ToList()[0];
            var l2 = db.ItemSpecs.ToList()[1];
            var m1 = db.ItemSpecs.ToList()[2];
            var m2 = db.ItemSpecs.ToList()[3];

            // test match
            if (m1.matches(m2))
            {
                Console.WriteLine("[mobileSpec1 and mobileSpec2] matched");
            }
            if (!l1.strictlyMatches(l2))
            {
                Console.WriteLine("[labtopSpec1 and labtopSpec2] not matched");
            }


            //compare labtop 1 and 2
            Dictionary<string, object> sim;
            sim = labtop_1.getSpec().getSameProperties(labtop_2.getSpec());
            foreach (KeyValuePair<string, object> kvp in sim)
            {
                Console.WriteLine(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
            }

            Console.WriteLine("------labtop 1------");
            foreach (KeyValuePair<string, object> kvp in l1.getProperties())
            {
                Console.WriteLine(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
            }
            Console.WriteLine("------labtop 2------");
            foreach (KeyValuePair<string, object> kvp in l2.getProperties())
            {
                Console.WriteLine(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
            }
            Console.WriteLine("---------------------------------------------\n");

            Console.WriteLine("----------- compare labtop 1 and 2 -----------");
            Tuple<Dictionary<string, Object>, Dictionary<string, Object>> diff;
            diff = l2.getDifferentProperties(l1);
            Console.WriteLine("------diff1------");
            foreach (KeyValuePair<string, object> kvp in diff.Item1)
            {
                Console.WriteLine(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
            }
            Console.WriteLine("------diff2------");
            foreach (KeyValuePair<string, object> kvp in diff.Item2)
            {
                Console.WriteLine(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
            }
            Console.WriteLine("---------------------------------------------\n");


            Console.WriteLine("Finished!");
            Console.ReadLine();


        }

    }
}
