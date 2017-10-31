namespace EveTransactions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UrlCache : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UrlCaches",
                c => new
                    {
                        UrlCacheID = c.Long(nullable: false, identity: true),
                        Url = c.String(maxLength: 4000),
                        CacheUntil = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UrlCacheID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UrlCaches");
        }
    }
}
