namespace OnlineShopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db_creation_new_fix_bugs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        _Id = c.String(nullable: false, maxLength: 128),
                        _PurchaseTime = c.DateTime(nullable: false),
                        PurchaseHistory__Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t._Id)
                .ForeignKey("dbo.PurchaseHistories", t => t.PurchaseHistory__Id)
                .Index(t => t.PurchaseHistory__Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        _SerialNumber = c.String(),
                        _Name = c.String(),
                        _Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        _Count = c.Int(nullable: false),
                        _Spec__Id = c.Int(),
                        Basket__Id = c.String(maxLength: 128),
                        ItemCategory__Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemSpecs", t => t._Spec__Id)
                .ForeignKey("dbo.Baskets", t => t.Basket__Id)
                .ForeignKey("dbo.ICategories", t => t.ItemCategory__Id)
                .Index(t => t._Spec__Id)
                .Index(t => t.Basket__Id)
                .Index(t => t.ItemCategory__Id);
            
            CreateTable(
                "dbo.ItemSpecs",
                c => new
                    {
                        _Id = c.Int(nullable: false, identity: true),
                        _PropertiesDB = c.String(),
                    })
                .PrimaryKey(t => t._Id);
            
            CreateTable(
                "dbo.ICategories",
                c => new
                    {
                        _Id = c.Int(nullable: false, identity: true),
                        _Level = c.Int(nullable: false),
                        _Name = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Category__Id = c.Int(),
                        Shop__Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t._Id)
                .ForeignKey("dbo.ICategories", t => t.Category__Id)
                .ForeignKey("dbo.Shops", t => t.Shop__Id)
                .Index(t => t.Category__Id)
                .Index(t => t.Shop__Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        _Id = c.String(nullable: false, maxLength: 128),
                        _FirstName = c.String(),
                        _LastName = c.String(),
                        _EmailAddress = c.String(),
                        _DeliveryAddress = c.String(),
                        _Phone = c.String(),
                        _CurrentBasket__Id = c.String(maxLength: 128),
                        _PurchaseHistory__Id = c.String(maxLength: 128),
                        Shop__Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t._Id)
                .ForeignKey("dbo.Baskets", t => t._CurrentBasket__Id)
                .ForeignKey("dbo.PurchaseHistories", t => t._PurchaseHistory__Id)
                .ForeignKey("dbo.Shops", t => t.Shop__Id)
                .Index(t => t._CurrentBasket__Id)
                .Index(t => t._PurchaseHistory__Id)
                .Index(t => t.Shop__Id);
            
            CreateTable(
                "dbo.PurchaseHistories",
                c => new
                    {
                        _Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t._Id);
            
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        _Id = c.String(nullable: false, maxLength: 128),
                        _Name = c.String(),
                    })
                .PrimaryKey(t => t._Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ICategories", "Shop__Id", "dbo.Shops");
            DropForeignKey("dbo.Customers", "Shop__Id", "dbo.Shops");
            DropForeignKey("dbo.Customers", "_PurchaseHistory__Id", "dbo.PurchaseHistories");
            DropForeignKey("dbo.Baskets", "PurchaseHistory__Id", "dbo.PurchaseHistories");
            DropForeignKey("dbo.Customers", "_CurrentBasket__Id", "dbo.Baskets");
            DropForeignKey("dbo.Items", "ItemCategory__Id", "dbo.ICategories");
            DropForeignKey("dbo.ICategories", "Category__Id", "dbo.ICategories");
            DropForeignKey("dbo.Items", "Basket__Id", "dbo.Baskets");
            DropForeignKey("dbo.Items", "_Spec__Id", "dbo.ItemSpecs");
            DropIndex("dbo.Customers", new[] { "Shop__Id" });
            DropIndex("dbo.Customers", new[] { "_PurchaseHistory__Id" });
            DropIndex("dbo.Customers", new[] { "_CurrentBasket__Id" });
            DropIndex("dbo.ICategories", new[] { "Shop__Id" });
            DropIndex("dbo.ICategories", new[] { "Category__Id" });
            DropIndex("dbo.Items", new[] { "ItemCategory__Id" });
            DropIndex("dbo.Items", new[] { "Basket__Id" });
            DropIndex("dbo.Items", new[] { "_Spec__Id" });
            DropIndex("dbo.Baskets", new[] { "PurchaseHistory__Id" });
            DropTable("dbo.Shops");
            DropTable("dbo.PurchaseHistories");
            DropTable("dbo.Customers");
            DropTable("dbo.ICategories");
            DropTable("dbo.ItemSpecs");
            DropTable("dbo.Items");
            DropTable("dbo.Baskets");
        }
    }
}
