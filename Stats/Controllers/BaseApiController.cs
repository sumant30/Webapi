using Stats.DataAccess;
using Stats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Stats.Controllers
{
    public class BaseApiController : ApiController
    {

		public IStatsService StatsService { get { return _service; } }

		public IModelFactory ModelFactory { get { return _modelFactory; } }

		private IStatsService _service;

		private IModelFactory _modelFactory;

		protected BaseApiController (IStatsService StatsService,IModelFactory ModelFactory )
			{
			_service = StatsService;
			_modelFactory = ModelFactory;
			}
    }
}
