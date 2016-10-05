using Stats . DataAccess . Entities;
using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Threading . Tasks;

namespace Stats . DataAccess . Repository
	{
	interface IRepository <T> where T : EntityBase
		{
		List<T> Get ( );

		T Get ( int Id );

		T Insert ( T Obj );

		T Update ( T Obj );

		int Delete ( T Obj );
		}
	}
