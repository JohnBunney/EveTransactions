//namespace EveTransactions.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class AddPrices : DbMigration
//    {
//        public override void Up()
//        {
//            AddColumn("dbo.EveItems", "BuyPrice", c => c.Double(nullable: false));
//            AddColumn("dbo.EveItems", "SellPrice", c => c.Double(nullable: false));
//        }
        
//        public override void Down()
//        {
//            DropColumn("dbo.EveItems", "SellPrice");
//            DropColumn("dbo.EveItems", "BuyPrice");
//        }
//    }
//}
