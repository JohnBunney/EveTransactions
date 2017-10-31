//namespace EveTransactions.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class RemovePauseDate : DbMigration
//    {
//        public override void Up()
//        {
//            DropColumn("dbo.Jobs", "PauseDate");
//        }
        
//        public override void Down()
//        {
//            AddColumn("dbo.Jobs", "PauseDate", c => c.DateTime(nullable: false));
//        }
//    }
//}
