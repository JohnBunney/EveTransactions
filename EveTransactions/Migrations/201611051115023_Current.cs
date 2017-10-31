//namespace EveTransactions.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class Current : DbMigration
//    {
//        public override void Up()
//        {
//            AddColumn("dbo.EveItems", "BuildPrice", c => c.Double(nullable: false));
//            AddColumn("dbo.EveItems", "CurrentStock", c => c.Long(nullable: false));
//        }
        
//        public override void Down()
//        {
//            DropColumn("dbo.EveItems", "CurrentStock");
//            DropColumn("dbo.EveItems", "BuildPrice");
//        }
//    }
//}
