using Stats . DataAccess . Entities;

namespace Stats . DataAccess . Repository
	{
	public class PlayerRepository : Repository<Player>
		{
		public PlayerRepository ( StatsDbContext context )
			: base ( context ) {}
		}
	}