using System;
using System . Collections . Generic;
using System . Linq;
using System . Web . Http;

namespace Stats
	{
	public static class WebApiConfig
		{
		public static void Register ( HttpConfiguration config )
			{
			GlobalConfiguration . Configure ( x => x . MapHttpAttributeRoutes ( ) );
			}
		}
	}
