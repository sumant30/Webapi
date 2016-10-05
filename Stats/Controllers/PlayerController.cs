using Stats . DataAccess;
using Stats . Models;
using System;
using System . Collections . Generic;
using System . Linq;
using System . Net;
using System . Net . Http;
using System . Web . Http;
using Stats . Filters;


namespace Stats . Controllers
	{
	[RoutePrefix ( "Player" )]
	public class PlayerController : BaseApiController
		{


		public PlayerController ( IModelFactory modelFactory , IStatsService statsService )
			: base ( statsService,modelFactory  )
			{
			
			}

		[Route ( "" )]
		public IHttpActionResult Get ( )
			{
			var players = StatsService . Players . Get ( );
			var model = players . Select ( ModelFactory . Create );
			return Ok ( model );

			}
		[Route ( "{id:int}" )]
		public IHttpActionResult Get ( int Id )
			{
			try
				{
				var players = StatsService . Players . Get ( Id );
				var model = ModelFactory . Create ( players );
				return Ok ( model );
				}
			catch ( Exception )
				{
				return InternalServerError ( );
				}
			}

		[Route ( "" )]
		[ModelValidatorFilter]
		public IHttpActionResult Post ( [FromBody] PlayerModel playerModel )
			{
			var player = ModelFactory . Create ( playerModel );
			var model =   ModelFactory . Create ( StatsService . Players . Insert ( player ) );
			return Created ( string . Format ( "http://localhost:2366/api/player/{0}" , model . PlayerId ) , model );
			}

		[Route ( "" )]
		[ModelValidatorFilter]
		public IHttpActionResult Put ( [FromBody] PlayerModel playerModel )
			{
			var player = ModelFactory . Create ( playerModel );
			var model =   ModelFactory . Create ( StatsService . Players . Update ( player ) );
			return Ok ( model );
			}

		[Route ( "{id:int}" )]
		public IHttpActionResult Delete ( int Id )
			{
			try
				{
				var players = StatsService . Players . Get ( Id );
				if ( players != null )
					{
					StatsService . Players . Delete ( players );
					return Ok ( );
					}
				else
					{
					return NotFound ( );
					}
				}
			catch ( Exception )
				{
				return InternalServerError ( );
				}
			}
		}
	}
