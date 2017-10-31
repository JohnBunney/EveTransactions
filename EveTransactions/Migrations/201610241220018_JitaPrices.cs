//namespace EveTransactions.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class JitaPrices : DbMigration
//    {
//        public override void Up()
//        {
//            AddColumn("dbo.EveItems", "JitaBuyPrice", c => c.Long(nullable: false));
//            AddColumn("dbo.EveItems", "JitaSellPrice", c => c.Long(nullable: false));
//        }

//        public override void Down()
//        {
//            DropColumn("dbo.EveItems", "JitaBuyPrice");
//            DropColumn("dbo.EveItems", "JitaSellPrice");
//        }
//    }
//}
