//namespace EveTransactions.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class AddRecipes : DbMigration
//    {
//        public override void Up()
//        {
//            CreateTable(
//                "dbo.Recipes",
//                c => new
//                    {
//                        RecipeID = c.Long(nullable: false, identity: true),
//                        TypeName = c.String(maxLength: 4000),
//                    })
//                .PrimaryKey(t => t.RecipeID);
            
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
            
//        }
        
//        public override void Down()
//        {
//            DropTable("dbo.RecipeInputs");
//            DropTable("dbo.Recipes");
//        }
//    }
//}
