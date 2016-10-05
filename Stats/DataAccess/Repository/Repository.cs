using Stats . DataAccess . Entities;
using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Web;

namespace Stats . DataAccess . Repository
	{
	public abstract class Repository<T> : IRepository<T> where T : EntityBase
		{

		private StatsDbContext 	_dbContext;

		protected Repository (StatsDbContext dbContext )
			{
			_dbContext = dbContext;
			}

		public virtual List<T> Get ( )
			{
		 	return _dbContext . Set<T> ( ) . ToList ( );
			}

		public virtual T Get ( int Id )
			{
			return _dbContext . Set<T> ( ) . Find(Id);
			}

		public virtual T Insert ( T Obj )
			{
			_dbContext . Set<T> ( ) . Add ( Obj );
			_dbContext . SaveChanges ( );
			return Obj;
			}

		public virtual T Update ( T Obj )
			{
			_dbContext . Entry ( Obj ) . State = EntityState . Modified;
			_dbContext . SaveChanges ( );
			return Obj;
			}

		public virtual int Delete ( T Obj )
			{
			_dbContext . Set<T> ( ) . Remove ( Obj );
			return _dbContext . SaveChanges ( );
			}





		
		}
	}