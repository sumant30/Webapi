namespace Stats.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeDateTimecolumnNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Players", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.Teams", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Teams", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.Games", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Games", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.GameEvents", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.GameEvents", "UpdatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GameEvents", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.GameEvents", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Games", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Games", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Teams", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Teams", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Players", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Players", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
