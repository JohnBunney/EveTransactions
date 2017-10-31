//namespace EveTransactions.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class doubler : DbMigration
//    {
//        public override void Up()
//        {
//            AlterColumn("dbo.InventedBlueprints", "TotalCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
//            AlterColumn("dbo.InventedBlueprints", "AverageCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
//            AlterColumn("dbo.Sales", "BuyPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
//            AlterColumn("dbo.Sales", "SellPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
//            AlterColumn("dbo.Sales", "ProfitPerUnit", c => c.Decimal(nullable: false, precision: 18, scale: 2));
//            AlterColumn("dbo.Sales", "BrokerFeePerUnit", c => c.Decimal(nullable: false, precision: 18, scale: 2));
//            AlterColumn("dbo.Sales", "SalesTaxPerUnit", c => c.Decimal(nullable: false, precision: 18, scale: 2));
//            AlterColumn("dbo.Sales", "NetProfitPerUnit", c => c.Decimal(nullable: false, precision: 18, scale: 2));
//            AlterColumn("dbo.Sales", "TotalProfit", c => c.Decimal(nullable: false, precision: 18, scale: 2));
//            AlterColumn("dbo.Sales", "BrokerFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
//            AlterColumn("dbo.Sales", "SalesTax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
//            AlterColumn("dbo.Sales", "NetProfit", c => c.Decimal(nullable: false, precision: 18, scale: 2));
//            AlterColumn("dbo.Sales", "HoursHeld", c => c.Decimal(nullable: false, precision: 18, scale: 2));
//            AlterColumn("dbo.Stocks", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
//        }
        
//        public override void Down()
//        {
//            AlterColumn("dbo.Stocks", "Price", c => c.Double(nullable: false));
//            AlterColumn("dbo.Sales", "HoursHeld", c => c.Double(nullable: false));
//            AlterColumn("dbo.Sales", "NetProfit", c => c.Double(nullable: false));
//            AlterColumn("dbo.Sales", "SalesTax", c => c.Double(nullable: false));
//            AlterColumn("dbo.Sales", "BrokerFee", c => c.Double(nullable: false));
//            AlterColumn("dbo.Sales", "TotalProfit", c => c.Double(nullable: false));
//            AlterColumn("dbo.Sales", "NetProfitPerUnit", c => c.Double(nullable: false));
//            AlterColumn("dbo.Sales", "SalesTaxPerUnit", c => c.Double(nullable: false));
//            AlterColumn("dbo.Sales", "BrokerFeePerUnit", c => c.Double(nullable: false));
//            AlterColumn("dbo.Sales", "ProfitPerUnit", c => c.Double(nullable: false));
//            AlterColumn("dbo.Sales", "SellPrice", c => c.Double(nullable: false));
//            AlterColumn("dbo.Sales", "BuyPrice", c => c.Double(nullable: false));
//            AlterColumn("dbo.InventedBlueprints", "AverageCost", c => c.Double(nullable: false));
//            AlterColumn("dbo.InventedBlueprints", "TotalCost", c => c.Double(nullable: false));
//        }
//    }
//}
