﻿using Stats . DataAccess . Entities;
using System;
using System . Collections . Generic;
using System . Linq;
using System . Web;

namespace Stats . DataAccess . Repository
	{
	public class GameRepository : Repository<Game>
		{
		public GameRepository ( StatsDbContext context )
			: base ( context ) { }
		}
	}