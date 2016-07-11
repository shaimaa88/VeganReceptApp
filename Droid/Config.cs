using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly: Dependency(typeof(VeganReceptApp.Droid.Config))]
namespace VeganReceptApp.Droid
{
	public class Config : IConfig
	{
		private string directoryDB;
		private ISQLitePlatform plataforma;

		public string DirectoryDB
		{
			get
			{
				if (string.IsNullOrEmpty(directoryDB))
				{
					directoryDB = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
				}
				return directoryDB;
			}

		}

		public ISQLitePlatform Platforma
		{
			get
			{

				plataforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();

				return plataforma;
			}
		}
	}
}

