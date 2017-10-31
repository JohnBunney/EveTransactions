//namespace EveTransactions.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class AddMarketItemPriceTable : DbMigration
//    {
//        public override void Up()
//        {
//            CreateTable(
//                "dbo.MarketItemPrices",
//                c => new
//                    {
//                        MarketItemPriceID = c.Long(nullable: false, identity: true),
//                        TypeID = c.Long(nullable: false),
//                        Name = c.String(maxLength: 4000),
//                        Group = c.String(maxLength: 4000),
//                        BuyPrice = c.Double(nullable: false),
//                        SellPrice = c.Double(nullable: false),
//                        Volume = c.Double(nullable: false),
//                        ProfitPerUnit = c.Double(nullable: false),
//                        ProfitPercent = c.Double(nullable: false),
//                        ProfitVolume = c.Double(nullable: false),
//                        ProfitVolumePercent = c.Double(nullable: false),
//                    })
//                .PrimaryKey(t => t.MarketItemPriceID);
            
//        }
        
//        public override void Down()
//        {
//            DropTable("dbo.MarketItemPrices");
//        }
//    }
//}
