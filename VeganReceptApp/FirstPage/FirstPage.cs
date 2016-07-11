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
		string myId = "lettuce.png";
		string myId2 = "zucchini.png";
		public FirstPage ()
		{
			//recepts = new ObservableCollection<ReceptViewModel> ();
			listRecept.RowHeight = 180;
			this.Title = "Recept App";



			//string id = "lettuce.png";

				recepts = new List<ReceptViewModel> 
				{ 
					new ReceptViewModel{ReceptName=myId,ReceptImage=myId2},
					new ReceptViewModel{ReceptName=myId,ReceptImage=myId2},
					new ReceptViewModel{ReceptName=myId,ReceptImage=myId2},
					new ReceptViewModel{ReceptName=myId,ReceptImage=myId2}
				};


			listRecept.ItemsSource = recepts;
			listRecept.ItemTemplate = new DataTemplate(typeof(ReceptViewCell));
			listRecept.ItemTapped += ListRecept_ItemTapped;
			Content = listRecept;
		}

		async void ListRecept_ItemTapped (object sender, ItemTappedEventArgs e)
		{
			await Navigation.PushAsync (new ReceptPage ((ReceptViewModel)e.Item));			
		}
	}

}
