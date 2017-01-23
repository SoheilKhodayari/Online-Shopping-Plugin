#OnlineShoppingFramework wiki 
- Developed by C# .NET 4.5 and Entity Framework 6+ .

## Framework Class Diagram
![class diagram](http://uupload.ir/files/o3fl_onlineshoppingframework.jpg)


## Framework Usage Instructions
In this section, we will walk through all classes as well as interfaces and see how to use each one. 

## ItemSpec Class
An ItemSpec is used as a result of doing a commonality analysis so as to make it possible to have dynamic properties for items of different categories on an online shopping system. It is basically a dictionary holding each essential item-specific property as needed.

The following codes demonstrates how to use it:

```C#              
// Creation: Method-1
IItemSpec mLabtopItemSpec = new ItemSpec();

// Creation: Method-2
Dictionary<string,Object> properties = new Dictionary<string,Object>();
properties.Add("CPU", "Core i7");
IItemSpec mLabtopItemSpec = new ItemSpec(properties);

// Add individual properties
mLabtopItemSpec.addPropertyIfNotExists("CPU", "Core i7");

// Set a specific property if exists
string key = ...;
object value = ...;
bool status = mLabtopItemSpec.setProperty(key, value);

// Get the object value of a property
string key = ...;
object value =  mLabtopItemSpec.getProperty(key);

// Get All Properties
Dictonary<string, object> properties;
properties = mLabtopItemSpec.getProperties();

// Check if contains a property
string key = ...;
bool result = mLabtopItemSpec.containsProperty(key);

// check if an current existing property also exists in  
// the passed otherSpec object and that the values do match
ItemSpec otherSpec = ...;
string propertyKey = ...;
bool result = mLabtopItemSpec.hasEqualProperty(propertyKey,otherSpec);

// Compare ItemSpecs by getting same properties 
ItemSpec otherSpec = ...;
var sameProperties = mLabtopItemSpec.getSameProperties(otherSpec);

// Comare ItemSpecs by getting different properties as a tuple of dictionaries
var differences = mLabtopItemSpec.getDifferentProperties(otherSpec);

// Check if an ItemSpec object matches another ItemSpec object
// match strategy is specified in the setMatchStrategy method
// default strategy uses ItemSpecMatcher class
ItemSpec otherSpec = ...;
bool result = mLabtopItemSpec.matches(otherSpec);

// Check if an ItemSpec object strictly matches another ItemSpec object
bool result = mLabtopItemSpec.strictlyMatches(otherSpec);

// Get or Set match strategy
IMatchStrategy matcher = mLabtopItemSpec.getMatchStrategy();
mLabtopItemSpec.setMatchStrategy(matcher);

```

## Item Class
An Item class is used to represent items on the desired shopping system.

The following codes demonstrates how to use it:

```C#
    // Creation
    decimal ItemPrice = 2500050;
    unit ItemCount = 10;
    string SerialNumber = Guid.NewGuid().ToString();
    string ItemName = "Acer-Aspire-V571-G";
    IItem mLabtopItem = new Item(SerialNumber, ItemName, ItemPrice, 
                                  ItemCount , mLabtopItemSpec);

    // get or set price
    decmial price = mLabtopItem.getPrice();
    mLabtopItem.setPrice(ItemPrice);

    // get or set ItemSpec
    ItemSpec spec = mLabtopItem.getSpec();
    mLabtopItem.setSpec(mLabtopItemSpec)

   // get or set Item count
   uint count = mLabtopItem.getCount();
   mLabtopItem.setCount(count); 

   // increment or decrement item count 
   bool status =  mLabtopItem.decCount();
   mLabtopItem.incCount();

   // clone item to be saved in histories, internal usage only
   var item = mLabtopItem.clone();

   // get item unique id
   var Id = mLabtopItem.getSerialNumber();
 

```



## ICategory - Category - ItemCategory Classes
In order to handle categories, this framework make use of a composite pattern. That is, both Category Class and ItemCategory Class would inherit from the Abstract ICategory Class, But the Category Class holds a reference to a
Collections of ICategory Classes (Which in turn could be a Category as well) to represent the tree relationships.
The ItemCategory Classes are the leaf nodes and they hold a reference to a list of items.

The following codes demonstrates how to use it:
   
```C#         
 // Create a binary tree of categories
ICateogry digitalProductsCategory = new Category("DigitalProducts");
ICateogry LabtopCategory = new ItemCategory("Labtop");
ICateogry mobileCategory = new ItemCategory("Mobile");


// search the category for items
ItemSpec spec = ...;
IList<item> items = digitalProductsCategory.search(spec);

// strict search the category for items
ItemSpec spec = ...;
IList<item> items = digitalProductsCategory.strictSearch(spec);

// get child categories
digitalProductsCategory.getCategories()

// add child category
digitalProductsCategory.addCategory(LabtopCategory);
digitalProductsCategory.addCategory(mobileCategory);

var shop = Shop.getInstance();
shop.addMainCategory(digitalProductsCategory);

// remove child category
digitalProductsCategory.removeCategory(LabtopCategory);

// get all actual items (not cloned ones)
digitalProductsCategory.getItems();


```

## Basket Class
The following lines of codes demonstrates how to use the Basket Class:

```C#
// Creation: Method-1
var basketId = Guid.NewGuid().ToString();
IBasket basket = new Basket(basketId);

// Creation: Method-2
var basketId = Guid.NewGuid().ToString();
List<Item> basketItems = new List<Item>();
basketItems.Add(mLabtopItem);
IBasket basket = new Basket(basketId, basketItems);

// Add Items individually
basket.addItem(mLabtopItem);

// Remove Items
uint countToBeDeleted = 5;
basket.removeItem(mLaptomItem, countToBeDeleted);

// Calculate Basket Price
 decimal price = basket.getTotalPrice();

// Other useful Properties
var items = basket.getItems();


```

## Customer Class
The following lines of codes demonstrates how to use the Customer Class:

```C#
// Creation
string firstName = ...;
string lastName = ...;
string customerId = Guid.NewGuid.ToString();
ICustomer customer = new Customer(customerId, firstName, lastName)

// set Delivery Address;
string address = ...;
customer.setDeliveryAddress(address);

// get/set Customer Basket instance
customer.getCurrentBasket();
customer.setCurrentBasket(basket);

// add item to basket
var count = 2;
customer.addItemToBasket(mLabtopItem, count);

// remove item from basket
var count = 2;
customer.removeItemFromBasket(mLabtopItem, count);

// purchase current basket
customer.PurchaseCurrentBasket();

// get purchase history object
customer.getPurchaseHistory();
```

## Purchase History Class
The following lines of codes demonstrates how to use the Purchase History Class:

```C#
// Creation
var Id = ...;
IPurchaseHistory history = new PurchaseHistory(Id);

// get/set records of purchased baskets
List<Basket> baskets = ...;
List<Basket> baskets = history.getPurchasedRecords();
history.setPurchaseRecords(baskets);

// add/remove a purchase record
history.addPurchaseRecord(basket);
history.removePurchaseRecord(basket);
history.removePurchaseRecords(baskets);

```

## AppContext Class For Database Context
This is the default database context class that is used to handle database creation, migrations, etc. It is to be noted that the user defined context must inherit AppContext for its database connections.

To create the database, run the following commands in the "Nuget-Package-Manger -> Package-Manager-Console":
```
Enable-Migrations
Add-Migration db_creation_migration
Update-Database
```

In order to work with database, just follow the Entity Framework conventions:
```C#
// Example EF database operations
// add item
Item item = ...;
var db = new AppContext().getInstance()   // get the current db connection
db.Items.Add(item);
db.SaveChanges();

// remove item
var item = db.Items.Remove(item);
db.SaveChanges();

// find an item
string serialNumber = ...;
var item = db.Items.Where(i=> i.getSerialNumber() == serialNumber).FirstOrDefault();

// retrieve all Categories;
var categories = db.Categories.ToList();

```

## Shop Class
The following codes demonstrates how to use this class.

```C#

// get singleton shop instance
IShop shop = Shop.getInstance();

// get or set shop properties
shop.setId(Id);
shop.setName(Name);
var _id = shop.getId();
var _name = shop.getName();

// get or set shop customers
List<Customer> customers = ...;
shop.setCustomers(customers);
var customers = shop.getCustomers();

// add or remove individual customer
Customer customer = ...;
shop.addCustomer(customer);
shop.removeCustomer(customer);

// add or remove main cateogry
ICategory cateogry = ...;
shop.addMainCategory(category);
shop.removeMainCategory(category);

// get or set main categories
List<ICateogry> categories = ...;
shop.setMainCategories(categories);
var mainCategories = shop.getMainCategories();

// get all items
var items = shop.getAllItems();

// get shop purchase history
List<Basket> history = shop.getShopPurchaseHistory();

// search and strict search ItemSpec
ItemSpec spec = ...;
IList<Item> result;
result = shop.search(spec);
result = shop.strictSearch(spec);


// check if shop contains item 
uint count = 5;
Item item = 2;
bool result = shop.checkExistingItemStock(item, count);

// update item count in shop
bool increment_count = true;
bool result = updateExistingItemStock(item, count, increment_count);


```
