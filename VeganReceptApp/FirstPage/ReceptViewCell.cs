using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace VeganReceptApp
{
	public class ReceptViewCell :ViewCell
	{
		Label nameImage;
		//public static readonly BindableProperty ReceptNameProperty = BindableProperty.Create("ReceptName", typeof(string), typeof(ReceptViewModel), "ReceptName");
		public ReceptViewCell ()
		{
			RelativeLayout cellView = new RelativeLayout (){ BackgroundColor = Color.White };
			nameImage = new Label() { FontSize=25, HeightRequest = 180, WidthRequest = 180, VerticalOptions=LayoutOptions.CenterAndExpand,HorizontalOptions=LayoutOptions.Center};
			nameImage.SetBinding (Label.TextProperty, new Binding ("ReceptName"));
			cellView.Children.Add (nameImage, Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => {
					return parent.Y;
				})
			);
			var receptImage = new Image (){ HeightRequest = 180, WidthRequest = 180 };
			receptImage.SetBinding (Image.SourceProperty, new Binding ("ReceptImage"));
			cellView.Children.Add (receptImage, 
				Constraint.RelativeToView(nameImage,(parent,view)=>{
					return view.X+view.Width;
				}),

				Constraint.RelativeToView(nameImage,(parent,view) => {
					return view.Y;
				})
			);
			this.View = cellView;
		}

	}
}

