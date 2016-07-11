using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using SQLite.Net;
using Xamarin.Forms;
namespace VeganReceptApp
{
	public class DataAccessFavorite:IDisposable
	{
		private SQLiteConnection connection;

		public DataAccessFavorite()
		{
			var config = DependencyService.Get<IConfig>();
			connection = new SQLiteConnection(config.Platforma, Path.Combine(config.DirectoryDB, "veganDatabase.db3"));
			connection.CreateTable<ReceptViewModel>();
		}
		public void InsertRecep(ReceptViewModel newRecept)
		{

			if (GetItem(newRecept.ReceptName) == null)
				connection.Insert(newRecept);
			
				
		}

		/*public void UpdatemyIng(ingredients_items updIng)
		{
			ingredients_items updIngQuantity = GetItem(updIng.IngredientName);
			updIngQuantity.IngredientQuantity += updIng.IngredientQuantity;
			connection.Update(updIngQuantity);
		}*/

		public void DeleteRecept(ReceptViewModel delRecep)
		{
			connection.Delete(delRecep);
		}

		public ReceptViewModel GetItem(string Recept)
		{
			return connection.Table<ReceptViewModel>().FirstOrDefault(c => c.ReceptName == Recept);
		}

		public List<ReceptViewModel> GetItems()
		{
			return connection.Table<ReceptViewModel>().ToList();
		}

		public void Dispose()
		{
			connection.Dispose();
		}
	}
}

