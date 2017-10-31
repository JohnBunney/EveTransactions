//namespace EveTransactions.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class AddRewardTable : DbMigration
//    {
//        public override void Up()
//        {
           
//            CreateTable(
//                "dbo.Rewards",
//                c => new
//                    {
//                        RewardID = c.Long(nullable: false, identity: true),
//                        Description = c.String(maxLength: 4000),
//                        Date = c.DateTime(nullable: false),
//                        Amount = c.Double(nullable: false),
//                        EveJournalID = c.Long(nullable: false),
//                    })
//                .PrimaryKey(t => t.RewardID);
            
//        }
        
//        public override void Down()
//        {
//            DropTable("dbo.Rewards");
//        }
//    }
//}
