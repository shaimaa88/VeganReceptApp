using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly: Dependency(typeof(VeganReceptApp.iOS.Config))]

namespace VeganReceptApp.iOS
{
	public class Config:IConfig
	{
		private string directoryDB;
		private ISQLitePlatform plataforma;
		public string DirectoryDB
		{
			get
			{
				if (string.IsNullOrEmpty(directoryDB))
				{
					var directorio = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
					directoryDB = System.IO.Path.Combine(directorio, "..", "Library");
				}
				return directoryDB;
			}
		}

		public ISQLitePlatform Platforma
		{
			get
			{
				if (plataforma == null)
				{
					plataforma = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
				}
				return plataforma;
			}
		}
	}
}

