using System;
using System . Collections . Generic;
using System . Linq;
using System . Web;

namespace Stats . DataAccess . Entities
	{
	public class Game  : EntityBase
		{
		public virtual Team HomeTeam { get; set; }

		public virtual Team AwayTeam { get; set; }

		public DateTime StartTime { get; set; }

		public ICollection<GameEvent> Events { get; set; }
		}
	}