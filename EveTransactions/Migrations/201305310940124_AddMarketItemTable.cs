////namespace EveTransactions.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class AddMarketItemTable : DbMigration
//    {
//        public override void Up()
//        {
//            CreateTable(
//                "dbo.MarketItems",
//                c => new
//                    {
//                        MarketItemID = c.Long(nullable: false, identity: true),
//                        TypeID = c.Long(nullable: false),
//                        Name = c.String(maxLength: 4000),
//                        Group = c.String(maxLength: 4000),
//                    })
//                .PrimaryKey(t => t.MarketItemID);
            
//        }
        
//        public override void Down()
//        {
//            DropTable("dbo.MarketItems");
//        }
//    }
//}
