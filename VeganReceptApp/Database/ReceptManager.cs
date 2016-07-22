using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace VeganReceptApp
{
	/* This class manages the connection to external database, to get json object
	*/
	public class ReceptManager
	{
		IRestService restService;
		public ReceptManager(IRestService service)
		{
			restService = service;
		}

		public Task<List<ReceptViewModel>> GetRecepts()
		{
			return restService.GetRecept();
		}
	}
}

