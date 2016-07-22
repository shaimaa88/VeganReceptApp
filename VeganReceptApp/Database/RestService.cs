using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VeganReceptApp
{
	public class RestService:IRestService
	{
		HttpClient client;
		List<ReceptViewModel> Recepts;

		public RestService()
		{
			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;
		}

		public async Task<List<ReceptViewModel>> GetRecept()
		{
			Recepts = new List<ReceptViewModel>();

			var uri = new Uri(string.Format("http://rubyanderson.se/share/herbivor/getdata.php", string.Empty));

			try
			{
				var response = await client.GetAsync(uri);
				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();//Put all data from url to string
					Recepts = JsonConvert.DeserializeObject<List<ReceptViewModel>>(content);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"                      ERROR{0}", ex.Message);
			}
			return Recepts;
		}
	}
}

