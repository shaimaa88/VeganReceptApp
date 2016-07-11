using System;

using Xamarin.Forms;

namespace VeganReceptApp
{
	public class MainPageTab : TabbedPage
	{
		public MainPageTab ()
		{
			var firstPage = new NavigationPage (new FirstPage ());
			firstPage.Icon = "mainpage.png";
			var shoppingList = new NavigationPage (new ShoppingList ());
			shoppingList.Icon = "shopping.png";
			var favoriteList = new NavigationPage(new FavoriteRecept());
			favoriteList.Icon = "favorite.png";
			Children.Add (firstPage);
			Children.Add (shoppingList);
			Children.Add(favoriteList);
		}
	}
}


