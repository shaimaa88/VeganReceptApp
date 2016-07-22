using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VeganReceptApp
{
	public interface IRestService
	{
		Task<List<ReceptViewModel>> GetRecept();
	}
}

