//namespace EveTransactions.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;

//    public partial class MaxBuildTime : DbMigration
//    {
//        public override void Up()
//        {
//            AddColumn("dbo.Recipes", "PrimaryManufacturer", c => c.String(maxLength: 4000));
//            AddColumn("dbo.Recipes", "BuildTimeHours", c => c.Decimal(nullable: false, precision: 18, scale: 2));
//        }

//        public override void Down()
//        {
//            DropColumn("dbo.Recipes", "BuildTimeHours");
//            DropColumn("dbo.Recipes", "PrimaryManufacturer");
//        }
//    }
//}
