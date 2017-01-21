namespace OnlineShopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cateogryItemList : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "ItemCategory__Id", c => c.Int());
            CreateIndex("dbo.Items", "ItemCategory__Id");
            AddForeignKey("dbo.Items", "ItemCategory__Id", "dbo.ICategories", "_Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "ItemCategory__Id", "dbo.ICategories");
            DropIndex("dbo.Items", new[] { "ItemCategory__Id" });
            DropColumn("dbo.Items", "ItemCategory__Id");
        }
    }
}
