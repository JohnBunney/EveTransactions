//namespace EveTransactions.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;

//    public partial class AddInvention : DbMigration
//    {
//        public override void Up()
//        {
//            CreateTable(
//                "dbo.InventedBlueprints",
//                c => new
//                    {
//                        TypeName = c.String(nullable: false, maxLength: 4000),
//                        TotalCost = c.Double(nullable: false),
//                        AverageCost = c.Double(nullable: false),
//                        NumberOfInventionAttempts = c.Long(nullable: false),
//                        SuccessfulAttempts = c.Long(nullable: false),
//                    })
//                .PrimaryKey(t => t.TypeName);

//        }

//        public override void Down()
//        {
//            DropTable("dbo.InventedBlueprints");
//        }
//    }
//}
