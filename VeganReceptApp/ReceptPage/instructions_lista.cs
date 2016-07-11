using System;
using Xamarin.Forms;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace VeganReceptApp
{
	public class instructions_lista:ViewCell
	{
		Label instNumLabel, instTextLabel;
		public instructions_lista()
		{
			instNumLabel = new Label 
			{ 
				TextColor = Color.Fuchsia,
				HorizontalOptions = LayoutOptions.Fill
			};
			instNumLabel.SetBinding(Label.TextProperty, new Binding("InstNummer"));

			instTextLabel = new Label 
			{
				TextColor = Color.Fuchsia,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			instTextLabel.SetBinding(Label.TextProperty, new Binding("InstText"));

			//create Grid
			var instructionsGrid = new Grid { Padding = new Thickness(10) };
			instructionsGrid.ColumnDefinitions.Add(new ColumnDefinition {Width=new GridLength(0.1,GridUnitType.Star) });
			instructionsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.1, GridUnitType.Star) });


			//add to the grid all the labels
			instructionsGrid.Children.Add(instNumLabel, 1, 0);
			instructionsGrid.Children.Add(instTextLabel, 2, 0);

			View = instructionsGrid;
		}
	}
}

