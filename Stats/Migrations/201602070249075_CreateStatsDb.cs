namespace Stats.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateStatsDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.Team_Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        HomeTeam_Id = c.Int(),
                        AwayTeam_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.HomeTeam_Id)
                .ForeignKey("dbo.Teams", t => t.AwayTeam_Id)
                .Index(t => t.HomeTeam_Id)
                .Index(t => t.AwayTeam_Id);
            
            CreateTable(
                "dbo.GameEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PointValue = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        Game_Id = c.Int(),
                        Player_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.Game_Id)
                .ForeignKey("dbo.Players", t => t.Player_Id)
                .Index(t => t.Game_Id)
                .Index(t => t.Player_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.GameEvents", new[] { "Player_Id" });
            DropIndex("dbo.GameEvents", new[] { "Game_Id" });
            DropIndex("dbo.Games", new[] { "AwayTeam_Id" });
            DropIndex("dbo.Games", new[] { "HomeTeam_Id" });
            DropIndex("dbo.Players", new[] { "Team_Id" });
            DropForeignKey("dbo.GameEvents", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.GameEvents", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.Games", "AwayTeam_Id", "dbo.Teams");
            DropForeignKey("dbo.Games", "HomeTeam_Id", "dbo.Teams");
            DropForeignKey("dbo.Players", "Team_Id", "dbo.Teams");
            DropTable("dbo.GameEvents");
            DropTable("dbo.Games");
            DropTable("dbo.Teams");
            DropTable("dbo.Players");
        }
    }
}
