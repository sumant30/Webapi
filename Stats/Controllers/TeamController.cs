using Stats . DataAccess;
using Stats . Models;
using System;
using System . Collections . Generic;
using System . Linq;
using System . Net;
using System . Net . Http;
using System . Web . Http;

namespace Stats . Controllers
	{
	[RoutePrefix ( "Team" )]
	public class TeamController : BaseApiController
		{


		public TeamController ( )
			: base ( new StatsService ( ) , new ModelFactory ( ) )
			{
			
			}

		[Route ( "" )]
		public IHttpActionResult Get ( )
			{
			var teams = StatsService . Teams . Get ( );
			var model = teams . Select ( ModelFactory . Create );
			return Ok ( model );
			}
		}
	}
