using Stats . DataAccess;
using Stats . Filters;
using Stats . Models;
using System;
using System . Collections . Generic;
using System . Linq;
using System . Net;
using System . Net . Http;
using System . Web . Http;

namespace Stats.Controllers
{
	[RoutePrefix("Game")]
	public class GameController : BaseApiController
    {
		public GameController ( )
			: base ( new StatsService ( ) , new ModelFactory ( ) )
			{
			
			}

		[Route("")]
		public IHttpActionResult Get ( ) 
			{
			var game = StatsService . Games . Get ( );
			var gameModel = game . Select ( ModelFactory . Create );
			return Ok ( gameModel );
			}

		[Route ( "{id:int}" )]
		public IHttpActionResult Get (int Id )
			{
			var game = StatsService . Games . Get (Id );
			var gameModel = ModelFactory.Create(game);
			return Ok ( gameModel );
			}

		
		[Route ( "{id:int}/Event" )]
		[ModelValidatorFilter]
		public IHttpActionResult CreateEvent([FromBody] GameEventModel gameEventModel)
		{
		try
			{
			var player = StatsService . Players . Get ( gameEventModel . PlayerId );
			var game   = StatsService . Games . Get ( gameEventModel . GameId );
			var gameEvent = ModelFactory . Create ( player , game , gameEventModel . PointValue );
			StatsService . Events . Insert ( gameEvent );
			return Created ( string . Format ( "http://localhost:2366/Game/{0}" , gameEventModel . GameId ) , gameEventModel );
			}
		catch ( Exception )
			{

			return InternalServerError ( );
			}
		}
    }
}
