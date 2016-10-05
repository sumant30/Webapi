﻿using Stats . DataAccess . Entities;
using System;
using System . Collections . Generic;
using System . Linq;
using System . Web;

namespace Stats . DataAccess . Repository
	{
	public class TeamRepository : Repository<Team>
		{
		public TeamRepository ( StatsDbContext context )
			: base ( context ) { }
		}
	}