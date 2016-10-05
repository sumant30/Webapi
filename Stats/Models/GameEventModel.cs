using System;
using System . Collections . Generic;
using System . Linq;
using System . Web;

namespace Stats . Models
	{
	public class GameEventModel
		{
		public int GameId { get; set; }

		public int PlayerId { get; set; }

		public int PointValue { get; set; }
		}
	}