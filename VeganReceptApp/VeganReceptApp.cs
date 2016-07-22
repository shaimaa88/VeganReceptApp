using System;

using Xamarin.Forms;

namespace VeganReceptApp
{
	public class App : Application
	{
		public static ReceptManager ReceptsManager { get; set; }
		public App ()
		{
			// The root page of your application
			ReceptsManager = new ReceptManager(new RestService());
			MainPage = new MainPageTab();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

