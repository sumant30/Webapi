using System;
using System . Collections . Generic;
using System . Linq;
using System . Web;

namespace Stats . DataAccess . Entities
	{
	public abstract class EntityBase : ReportingBase
		{
		public int Id { get; set; }
		}
	}