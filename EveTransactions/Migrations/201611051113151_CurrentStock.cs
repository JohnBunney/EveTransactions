//namespace EveTransactions.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class CurrentStock : DbMigration
//    {
//        public override void Up()
//        {
//            CreateTable(
//                "dbo.EveItems",
//                c => new
//                    {
//                        EveItemID = c.Long(nullable: false, identity: true),
//                        ItemID = c.Long(nullable: false),
//                        ItemName = c.String(maxLength: 4000),
//                        TrackPrices = c.Boolean(nullable: false),
//                        BuyPrice = c.Double(nullable: false),
//                        SellPrice = c.Double(nullable: false),
//                        JitaBuyPrice = c.Double(nullable: false),
//                        JitaSellPrice = c.Double(nullable: false),
//                        BuildPrice = c.Double(nullable: false),
//                        CurrentStock = c.Long(nullable: false),
//                        TargetStock = c.Long(nullable: false),
//                    })
//                .PrimaryKey(t => t.EveItemID);
            
//            CreateTable(
//                "dbo.InventedBlueprints",
//                c => new
//                    {
//                        TypeName = c.String(nullable: false, maxLength: 4000),
//                        TotalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
//                        AverageCost = c.Decimal(nullable: false, precision: 18, scale: 2),
//                        NumberOfInventionAttempts = c.Long(nullable: false),
//                        SuccessfulAttempts = c.Long(nullable: false),
//                        OutputMultiplier = c.Long(nullable: false),
//                    })
//                .PrimaryKey(t => t.TypeName);
            
//            CreateTable(
//                "dbo.Jobs",
//                c => new
//                    {
//                        JobID = c.Long(nullable: false, identity: true),
//                        EveJobID = c.Long(nullable: false),
//                        InstallerID = c.Long(nullable: false),
//                        InstallerName = c.String(maxLength: 4000),
//                        FacilityID = c.Long(nullable: false),
//                        SolarSystemID = c.Long(nullable: false),
//                        SolarSystemName = c.String(maxLength: 4000),
//                        StationID = c.Long(nullable: false),
//                        Activity = c.Int(nullable: false),
//                        BlueprintID = c.Long(nullable: false),
//                        BlueprintTypeID = c.Long(nullable: false),
//                        BlueprintTypeName = c.String(maxLength: 4000),
//                        BlueprintLocationID = c.Long(nullable: false),
//                        OutputLocationID = c.Long(nullable: false),
//                        Runs = c.Long(nullable: false),
//                        Cost = c.Double(nullable: false),
//                        TeamID = c.Long(nullable: false),
//                        LicensedRuns = c.Long(nullable: false),
//                        Probability = c.Decimal(nullable: false, precision: 18, scale: 2),
//                        ProductTypeID = c.Long(nullable: false),
//                        ProductTypeName = c.String(maxLength: 4000),
//                        Status = c.Long(nullable: false),
//                        TimeInSeconds = c.Long(nullable: false),
//                        StartDate = c.DateTime(nullable: false),
//                        EndDate = c.DateTime(nullable: false),
//                        CompletedDate = c.DateTime(nullable: false),
//                        CompletedCharacterID = c.Long(nullable: false),
//                        SuccessfulRuns = c.Long(nullable: false),
//                    })
//                .PrimaryKey(t => t.JobID);
            
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
            
//            CreateTable(
//                "dbo.MarketItems",
//                c => new
//                    {
//                        MarketItemID = c.Long(nullable: false, identity: true),
//                        TypeID = c.Long(nullable: false),
//                        Name = c.String(maxLength: 4000),
//                        Group = c.String(maxLength: 4000),
//                        Disabled = c.Boolean(nullable: false),
//                    })
//                .PrimaryKey(t => t.MarketItemID);
            
//            CreateTable(
//                "dbo.RecipeInputs",
//                c => new
//                    {
//                        RecipeInputID = c.Long(nullable: false, identity: true),
//                        RecipeID = c.Long(nullable: false),
//                        TypeName = c.String(maxLength: 4000),
//                        Quantity = c.Long(nullable: false),
//                    })
//                .PrimaryKey(t => t.RecipeInputID);
            
//            CreateTable(
//                "dbo.Recipes",
//                c => new
//                    {
//                        RecipeID = c.Long(nullable: false, identity: true),
//                        TypeName = c.String(maxLength: 4000),
//                        OutputMultiplier = c.Long(nullable: false),
//                        MaximumStock = c.Long(nullable: false),
//                        PrimaryManufacturer = c.String(maxLength: 4000),
//                        BuildTimeHours = c.Decimal(nullable: false, precision: 18, scale: 2),
//                        MaxRuns = c.Long(nullable: false),
//                    })
//                .PrimaryKey(t => t.RecipeID);
            
//            CreateTable(
//                "dbo.Rewards",
//                c => new
//                    {
//                        RewardID = c.Long(nullable: false, identity: true),
//                        Description = c.String(maxLength: 4000),
//                        Date = c.DateTime(nullable: false),
//                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
//                        EveJournalID = c.Long(nullable: false),
//                    })
//                .PrimaryKey(t => t.RewardID);
            
//            CreateTable(
//                "dbo.Sales",
//                c => new
//                    {
//                        SaleID = c.Long(nullable: false, identity: true),
//                        TypeName = c.String(maxLength: 4000),
//                        BuyDate = c.DateTime(nullable: false),
//                        BuyPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
//                        SellDate = c.DateTime(nullable: false),
//                        SellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
//                        Quantity = c.Long(nullable: false),
//                        ProfitPerUnit = c.Decimal(nullable: false, precision: 18, scale: 2),
//                        BrokerFeePerUnit = c.Decimal(nullable: false, precision: 18, scale: 2),
//                        SalesTaxPerUnit = c.Decimal(nullable: false, precision: 18, scale: 2),
//                        NetProfitPerUnit = c.Decimal(nullable: false, precision: 18, scale: 2),
//                        TotalProfit = c.Decimal(nullable: false, precision: 18, scale: 2),
//                        BrokerFee = c.Decimal(nullable: false, precision: 18, scale: 2),
//                        SalesTax = c.Decimal(nullable: false, precision: 18, scale: 2),
//                        NetProfit = c.Decimal(nullable: false, precision: 18, scale: 2),
//                        HoursHeld = c.Decimal(nullable: false, precision: 18, scale: 2),
//                    })
//                .PrimaryKey(t => t.SaleID);
            
//            CreateTable(
//                "dbo.Stocks",
//                c => new
//                    {
//                        StockID = c.Long(nullable: false, identity: true),
//                        TypeName = c.String(maxLength: 4000),
//                        Date = c.DateTime(nullable: false),
//                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
//                        Quantity = c.Long(nullable: false),
//                    })
//                .PrimaryKey(t => t.StockID);
            
//            CreateTable(
//                "dbo.EveWalletTransactions",
//                c => new
//                    {
//                        EveWalletTransactionID = c.Long(nullable: false, identity: true),
//                        Date = c.DateTime(nullable: false),
//                        Price = c.Double(nullable: false),
//                        TotalPrice = c.Double(nullable: false),
//                        ClientName = c.String(maxLength: 4000),
//                        Station = c.String(maxLength: 4000),
//                        TransactionFor = c.String(maxLength: 4000),
//                        TransactionType = c.String(maxLength: 4000),
//                        TypeName = c.String(maxLength: 4000),
//                        Quantity = c.Long(nullable: false),
//                        TransactionIDFromEve = c.Long(nullable: false),
//                    })
//                .PrimaryKey(t => t.EveWalletTransactionID);
            
//        }
        
//        public override void Down()
//        {
//            DropTable("dbo.EveWalletTransactions");
//            DropTable("dbo.Stocks");
//            DropTable("dbo.Sales");
//            DropTable("dbo.Rewards");
//            DropTable("dbo.Recipes");
//            DropTable("dbo.RecipeInputs");
//            DropTable("dbo.MarketItems");
//            DropTable("dbo.MarketItemPrices");
//            DropTable("dbo.Jobs");
//            DropTable("dbo.InventedBlueprints");
//            DropTable("dbo.EveItems");
//        }
//    }
//}
