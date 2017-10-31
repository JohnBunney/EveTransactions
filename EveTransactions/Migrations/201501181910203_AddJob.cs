//namespace EveTransactions.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;

//    public partial class AddJob : DbMigration
//    {
//        public override void Up()
//        {
//            CreateTable(
//                "dbo.Jobs",
//                c => new
//                    {
//                        JobID = c.Long(nullable: false, identity: true),
//                        InstallerID = c.Long(nullable: false),
//                        InstallerName = c.String(maxLength: 4000),
//                        FacilityID = c.Long(nullable: false),
//                        SolarSystemID = c.Long(nullable: false),
//                        SolarSystemName = c.String(maxLength: 4000),
//                        StationID = c.Long(nullable: false),
//                        Activity = c.Int(nullable: false),
//                        BlueprintID = c.Long(nullable: false),
//                        BlueprintTypeID = c.Long(nullable: false),
//                        BlueprintTypeName = c.String(maxLength: 4000),
//                        BlueprintLocationID = c.Long(nullable: false),
//                        OutputLocationID = c.Long(nullable: false),
//                        Runs = c.Long(nullable: false),
//                        Cost = c.Double(nullable: false),
//                        TeamID = c.Long(nullable: false),
//                        LicensedRuns = c.Long(nullable: false),
//                        Probability = c.Decimal(nullable: false, precision: 18, scale: 2),
//                        ProductTypeID = c.Long(nullable: false),
//                        ProductTypeName = c.String(maxLength: 4000),
//                        Status = c.Long(nullable: false),
//                        TimeInSeconds = c.Long(nullable: false),
//                        StartDate = c.DateTime(nullable: false),
//                        EndDate = c.DateTime(nullable: false),
//                        PauseDate = c.DateTime(nullable: false),
//                        CompletedDate = c.DateTime(nullable: false),
//                        CompletedCharacterID = c.Long(nullable: false),
//                        SuccessfulRuns = c.Long(nullable: false),
//                    })
//                .PrimaryKey(t => t.JobID);

//        }

//        public override void Down()
//        {
//            DropTable("dbo.Jobs");
//        }
//    }
//}
