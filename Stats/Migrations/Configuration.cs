namespace Stats . Migrations
	{
	using Stats . DataAccess . Entities;
	using System;
	using System . Collections . Generic;
	using System . Data . Entity;
	using System . Data . Entity . Migrations;
	using System . Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<Stats . DataAccess . StatsDbContext>
		{
		public Configuration ( )
			{
			AutomaticMigrationsEnabled = false;
			}

		protected override void Seed ( Stats . DataAccess . StatsDbContext context )
			{
			//  This method will be called after migrating to the latest version.

			var player1 = new Player { FirstName = "John" , LastName = "Doe" , CreatedDate = DateTime . Now , UpdatedDate = DateTime . Now };
			var player2 = new Player { FirstName = "Frank" , LastName = "Doe" , CreatedDate = DateTime . Now , UpdatedDate = DateTime . Now };
			var player3 = new Player { FirstName = "Robbie" , LastName = "Johnson" , CreatedDate = DateTime . Now , UpdatedDate = DateTime . Now };
			var player4 = new Player { FirstName = "Billy" , LastName = "Bob" , CreatedDate = DateTime . Now , UpdatedDate = DateTime . Now };

			var team1 = new Team { Name = "Rhinos" , Players = new List<Player> { player1 , player2 } , CreatedDate = DateTime . Now , UpdatedDate = DateTime . Now };
			var team2 = new Team { Name = "Eagles" , Players = new List<Player> { player3 , player4 } , CreatedDate = DateTime . Now , UpdatedDate = DateTime . Now };

			player1 . Team = team1;
			player2 . Team = team1;
			player3 . Team = team2;
			player4 . Team = team2;

			var game = new Game { AwayTeam = team1 , HomeTeam = team2 , StartTime = DateTime . Now , CreatedDate = DateTime . Now , UpdatedDate = DateTime . Now };

			context . Players . Add ( player1 );
			context . Players . Add ( player2 );
			context . Players . Add ( player3 );
			context . Players . Add ( player4 );

			context . Teams . Add ( team1 );
			context . Teams . Add ( team2 );

			context . Games . Add ( game );
			}
		}
	}
