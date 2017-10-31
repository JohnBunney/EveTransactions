//namespace EveTransactions.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class DecimalReward : DbMigration
//    {
//        public override void Up()
//        {
//            AlterColumn("dbo.Rewards", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
//        }
        
//        public override void Down()
//        {
//            AlterColumn("dbo.Rewards", "Amount", c => c.Double(nullable: false));
//        }
//    }
//}
