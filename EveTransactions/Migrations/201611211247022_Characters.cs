//namespace EveTransactions.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class Characters : DbMigration
//    {
//        public override void Up()
//        {
//            CreateTable(
//                "dbo.Characters",
//                c => new
//                    {
//                        CharacterID = c.Long(nullable: false, identity: true),
//                        Name = c.String(maxLength: 4000),
//                        EveCharacterID = c.Long(nullable: false),
//                        KeyID = c.String(maxLength: 4000),
//                        vCode = c.String(maxLength: 4000),
//                    })
//                .PrimaryKey(t => t.CharacterID);
            
//        }
        
//        public override void Down()
//        {
//            DropTable("dbo.Characters");
//        }
//    }
//}
