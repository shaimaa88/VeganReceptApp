using System;

using Xamarin.Forms;

namespace VeganReceptApp
{
	public class FavoriteCustomCell : ViewCell
	{
		public FavoriteCustomCell()
		{
			StackLayout cellWrapper = new StackLayout();
			StackLayout horizontalLayout = new StackLayout();
			var recepImage = new Image() { HeightRequest=90,WidthRequest=90};
			Label nameRecep = new Label() { FontSize = 25, HeightRequest = 90};

			nameRecep.SetBinding(Label.TextProperty, new Binding("ReceptName"));
			                     recepImage.SetBinding(Image.SourceProperty,new Binding("ReceptImage"));
			//cellWrapper.BackgroundColor = Color.Navy;
			horizontalLayout.Orientation = StackOrientation.Horizontal;
			nameRecep.TextColor = Color.Maroon;

			horizontalLayout.Children.Add(recepImage);
			horizontalLayout.Children.Add(nameRecep);
			cellWrapper.Children.Add(horizontalLayout);
			View = cellWrapper;
		}
	}
}


