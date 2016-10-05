using Stats . DataAccess . Entities;
using System;
using System . Collections . Generic;
using System . Linq;
using System.Net.Http;
using System . Web;
using System.Web.Mvc;

namespace Stats . Models
	{

	public interface IModelFactory
		{
		PlayerModel Create ( Player player );

		Player Create ( PlayerModel playerModel );

		TeamModel Create ( Team team );

		GameModel Create ( Game game );

		GameEvent Create ( Player player , Game game , int pointValue );
		}

	public class ModelFactory : IModelFactory
		{

		
		public PlayerModel Create ( Player player )
			{
			PlayerModel playerModel = null;
			if ( player != null )
				{
				playerModel = new PlayerModel ( )
					{
						PlayerId = player . Id ,
						FirstName = player . FirstName ,
						LastName = player . LastName ,
						TeamId = player . Team != null ? player . Team . Id : 0 ,
						TeamName = player . Team != null ? player . Team . Name : null
					};
				}
			return playerModel;
			}


		public Player Create ( PlayerModel playerModel )
			{
			Player player = null;
			if ( playerModel != null && playerModel . PlayerId == 0 )
				{
				player = new Player ( )
				{
					FirstName = playerModel . FirstName ,
					LastName = playerModel . LastName ,
					CreatedDate = DateTime . Now ,
					UpdatedDate = DateTime . Now
				};
				}
			else
				{
				player = new Player ( )
					{
						Id = playerModel . PlayerId ,
						FirstName = playerModel . FirstName ,
						LastName = playerModel . LastName ,

					};
				}
			return player;
			}


		public TeamModel Create ( Team team )
			{
			TeamModel teamModel = null;
			if ( team != null )
				{
				teamModel = new TeamModel ( )
				{
					TeamName = team . Name ,
					Players = ( team . Players != null && team . Players . Any ( ) ) ? team . Players . Select ( Create ) . ToList ( ) : null
				};
				}
			return teamModel;
			}


		public GameModel Create ( Game game )
			{
			GameModel gameModel = null;
			if ( game != null )
				{
				gameModel = new GameModel ( )
				{
					AwayTeam = Create ( game . AwayTeam ) ,
					HomeTeam = Create ( game . HomeTeam ) ,
					GameId = game . Id ,
					StartTime = game . StartTime ,
					Event = ( game . Events != null && game . Events . Any ( ) ) ? game . Events . Select ( Create ) . ToList ( ) : null
				};
				}
			return gameModel;
			}

		public GameEventModel Create ( GameEvent gameEvent )
			{
			GameEventModel gameEventModel = null;
			if ( gameEvent != null )
				{
				gameEventModel = new GameEventModel ( )
				{
					GameId = gameEvent . Game . Id ,
					PlayerId = gameEvent . Player . Id ,
					PointValue = gameEvent . PointValue
				};
				}
			return gameEventModel;
			}


		public GameEvent Create ( Player player , Game game , int pointValue )
			{
			return new GameEvent { Player = player , Game = game , PointValue = pointValue };
			}
		}
	}