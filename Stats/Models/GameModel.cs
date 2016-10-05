using System;
using System . Collections . Generic;
using System . Linq;
using System . Web;

namespace Stats . Models
	{
	public class GameModel
		{
		public int GameId { get; set; }

		public TeamModel HomeTeam { get; set; }

		public TeamModel AwayTeam { get; set; }

		public DateTime StartTime { get; set; }

		public List<GameEventModel> Event { get; set; }
		}
	}