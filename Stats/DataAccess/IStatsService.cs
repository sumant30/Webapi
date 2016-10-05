using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Threading . Tasks;
using Stats . DataAccess . Repository;
using Stats . DataAccess . Entities;

namespace Stats . DataAccess
	{
	public interface IStatsService
		{
		Repository<Player> Players { get; }

		Repository<Game> Games { get; }

		Repository<Team> Teams { get; }

		Repository<GameEvent> Events { get; }
		}
	}
