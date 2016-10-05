using Stats . DataAccess . Entities;
using Stats . DataAccess . Repository;
using System;
using System . Collections . Generic;
using System . Linq;
using System . Web;

namespace Stats . DataAccess
	{
	public class StatsService : IStatsService
		{

		private Repository<Player> _players;
		private Repository<Game> _games;
		private Repository<Team> _teams;
		private Repository<GameEvent> _events;
		private StatsDbContext _context;

		public StatsService ( )
			{
			_context = new StatsDbContext ( );
			}

		public Repository<Player> Players
			{
			get
				{
				if ( _players == null )
					{
					_players = new PlayerRepository ( _context );
					}
				return _players;
				}

			}

		public Repository<Game> Games
			{
			get
				{
				if ( _games == null )
					{
					_games = new GameRepository ( _context );
					}
				return _games;
				}
			}

		public Repository<Team> Teams
			{
			get
				{
				if ( _teams == null )
					{
					_teams = new TeamRepository ( _context );
					}
				return _teams;
				}
			}

		public Repository<GameEvent> Events
			{
			get
				{
				if ( _events == null )
					{
					_events = new GameEventRepository ( _context );
					}
				return _events;
				}
			}
		}
	}