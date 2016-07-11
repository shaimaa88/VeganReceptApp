using System;
using Xamarin.Forms;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;


namespace VeganReceptApp
{
	//This class creates a gridview to show ingredients in rows 
	public class ingredients_lista:ViewCell
	{
		Label quantityLabel, typeLabel, ingredientNameLabel;

		public ingredients_lista()
		{
			quantityLabel = new Label 
			{
				TextColor = Color.Red,
				HorizontalOptions = LayoutOptions.Fill
			};
			quantityLabel.SetBinding(Label.TextProperty, new Binding("IngredientQuantity"));

			typeLabel = new Label
			{
				TextColor = Color.Red,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			typeLabel.SetBinding(Label.TextProperty, new Binding("IngredientType"));

			ingredientNameLabel = new Label 
			{
				TextColor = Color.Red,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			ingredientNameLabel.SetBinding(Label.TextProperty, new Binding("IngredientName"));

			//create a grid where all the labels will be placed
			var ingredientsGrid = new Grid { Padding = new Thickness(10) };
			ingredientsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.1, GridUnitType.Star)});
			ingredientsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.1, GridUnitType.Star) });
			ingredientsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.2, GridUnitType.Star) });

			//add to the grid all the labels
			ingredientsGrid.Children.Add(quantityLabel, 1, 0);
			ingredientsGrid.Children.Add(typeLabel, 2, 0);
			ingredientsGrid.Children.Add(ingredientNameLabel, 3, 0);
			View = ingredientsGrid;
		}
	}
}

