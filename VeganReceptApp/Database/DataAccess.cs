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
	public class DataAccess : IDisposable
	{
		private SQLiteConnection connection;
		public DataAccess()
		{
			var config = DependencyService.Get<IConfig>();
			connection = new SQLiteConnection(config.Platforma, Path.Combine(config.DirectoryDB, "vegDatabase.db3"));
			connection.CreateTable<ingredients_items>();
		}
		public void InsertmyIng(ingredients_items newIng)
		{

			if (GetItem(newIng.IngName) == null)
				connection.Insert(newIng);
			else
				UpdatemyIng(newIng);
		}

		public void UpdatemyIng(ingredients_items updIng)
		{
			ingredients_items updIngQuantity = GetItem(updIng.IngName);
			updIngQuantity.IngAmount += updIng.IngAmount;
			connection.Update(updIngQuantity);
		}

		public void DeletemyIng(ingredients_items delIng)
		{
			connection.Delete(delIng);
		}

		public ingredients_items GetItem(string Ing)
		{
			return connection.Table<ingredients_items>().FirstOrDefault(c => c.IngName == Ing);
		}

		public List<ingredients_items> GetItems()
		{
			return connection.Table<ingredients_items>().ToList();
		}

		public void Dispose()
		{
			connection.Dispose();
		}
	}
}

