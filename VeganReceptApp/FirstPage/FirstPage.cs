using System;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;

namespace VeganReceptApp
{
	public class FirstPage : ContentPage
	{
		//public ObservableCollection<ReceptViewModel>recepts{ get; set; }
		List<ReceptViewModel> recepts;
		ListView listRecept = new ListView();
		public FirstPage ()
		{
			//recepts = new ObservableCollection<ReceptViewModel> ();
			listRecept.RowHeight = 180;
			this.Title = "Recept App";



			//NOW I POPULATE THE LISTVIEW FROM DATABASE

			/*	recepts = new List<ReceptViewModel> 
				{ 
					new ReceptViewModel{ReceptName=myId,ReceptImage=myId2},
					new ReceptViewModel{ReceptName=myId,ReceptImage=myId2},
					new ReceptViewModel{ReceptName=myId,ReceptImage=myId2},
					new ReceptViewModel{ReceptName=myId,ReceptImage=myId2}
				};*/


			listRecept.ItemsSource = recepts;
			listRecept.ItemTemplate = new DataTemplate(typeof(ReceptViewCell));
			listRecept.ItemTapped += ListRecept_ItemTapped;
			Content = listRecept;
		}

		async void ListRecept_ItemTapped (object sender, ItemTappedEventArgs e)
		{
			await Navigation.PushAsync (new ReceptPage ((ReceptViewModel)e.Item));			
		}
		protected async override void OnAppearing()
		{
			base.OnAppearing();
			recepts = await App.ReceptsManager.GetRecepts();
		}
	}

}
