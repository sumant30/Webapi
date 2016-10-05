namespace Stats . Migrations
	{
	using System;
	using System . Data . Entity . Migrations;

	public partial class SetDefaultValueforDate : DbMigration
		{
		public override void Up ( )
			{
			Sql(Utility . DropDefaultConstraint ( "dbo.Players" , "CreatedDate" ));
			Sql ( Utility . DropDefaultConstraint ( "dbo.Teams" , "CreatedDate" ) );
			Sql ( Utility . DropDefaultConstraint ( "dbo.Games" , "CreatedDate" ) );
			Sql ( Utility . DropDefaultConstraint ( "dbo.GameEvents" , "CreatedDate" ) );
			AlterColumn ( "dbo.Players" , "CreatedDate" , c => c . DateTime ( defaultValueSql: "GetDate()" ) );
			AlterColumn ( "dbo.Teams" , "CreatedDate" , c => c . DateTime (  defaultValueSql: "GetDate()" ) );
			AlterColumn ( "dbo.Games" , "CreatedDate" , c => c . DateTime ( defaultValueSql: "GetDate()" ) );
			AlterColumn ( "dbo.GameEvents" , "CreatedDate" , c => c . DateTime ( defaultValueSql: "GetDate()" ) );
			}

		public override void Down ( )
			{
			AlterColumn ( "dbo.GameEvents" , "CreatedDate" , c => c . DateTime ( nullable: false ) );
			AlterColumn ( "dbo.Games" , "CreatedDate" , c => c . DateTime ( nullable: false ) );
			AlterColumn ( "dbo.Teams" , "CreatedDate" , c => c . DateTime ( nullable: false ) );
			AlterColumn ( "dbo.Players" , "CreatedDate" , c => c . DateTime ( nullable: false ) );
			}
		}



	}
