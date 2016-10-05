using System;
using System . Collections . Generic;
using System . ComponentModel . DataAnnotations;
using System . Linq;
using System . Web;

namespace Stats . Models
	{
	public class TeamModel
		{
		public int Id { get; set; }
		
		[Required]
		public string TeamName { get; set; }

		public List<PlayerModel> Players { get; set; }
		}
	}