using System;

using Xamarin.Forms;

namespace VeganReceptApp
{
	public class FavoriteRecept : ContentPage
	{
		ListView recepList;
		public FavoriteRecept()
		{
			var layoutStack = new StackLayout();
			recepList = new ListView()
			{
				RowHeight = 180
			};
			layoutStack.Children.Add(recepList);
			Content = layoutStack;
			UpdateList();
			recepList.ItemTapped += ReceptLista_ItemTapped;
		}
		public void UpdateList()
		{

			recepList.ItemTemplate = new DataTemplate(typeof(FavoriteCustomCell));
			using (var recepts = new DataAccessFavorite())
			{
				recepList.ItemsSource = recepts.GetItems();
			}
		}

		void ReceptLista_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			using (var recept = new DataAccessFavorite())
			{
				recept.DeleteRecept((ReceptViewModel)e.Item);

				recepList.ItemsSource = recept.GetItems();
			}

		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			UpdateList();
		}
	}
}


