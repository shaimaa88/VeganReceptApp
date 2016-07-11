using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace VeganReceptApp
{
	public class ShoppingList : ContentPage
	{
		

		ListView ingredientsLista;
		Entry quantityEntry,typeEntry,nameEntry ;
		public ShoppingList()
		{
			var layoutRelative = new RelativeLayout { HeightRequest = 100 };
			ingredientsLista = new ListView
			{
				HeightRequest = 300
			};
			 quantityEntry = new Entry 
			{
				Placeholder = "Quant",
				HorizontalOptions=LayoutOptions.Fill
			};
			quantityEntry.SetBinding(Entry.TextProperty, new Binding("IngredientQuantity"));
			 typeEntry = new Entry
			{
				Placeholder = "Type",
				HorizontalOptions = LayoutOptions.Fill
			};
			typeEntry.SetBinding(Entry.TextProperty, new Binding("IngredientType"));
			 nameEntry = new Entry
			{
				Placeholder = "IngredientName",
				HorizontalOptions = LayoutOptions.Fill
			};
			nameEntry.SetBinding(Entry.TextProperty, new Binding("IngredientsName"));
			var addIng = new Button
			{
				Text = "Add new Ingredient",
				TextColor = Color.Gray,
				BackgroundColor = Color.Lime
			};
			//create a Grid to show be able to add ingredients
			var gridIng = new Grid { Padding = new Thickness(10) };
			gridIng.ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Auto });
			gridIng.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
			gridIng.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto});
			gridIng.Children.Add(quantityEntry, 1, 0);
			gridIng.Children.Add(typeEntry, 2, 0);
			gridIng.Children.Add(nameEntry, 3, 0);
			layoutRelative.Children.Add(ingredientsLista,
			                            Constraint.Constant(0), 
			                            Constraint.Constant(50),
										Constraint.RelativeToParent((parent) =>
				{
					return parent.Width;
				}),
				Constraint.RelativeToParent((parent) =>
				{
					return parent.Height * .6;
				})

			);
			layoutRelative.Children.Add(gridIng, Constraint.Constant(10),
			                            Constraint.RelativeToView(ingredientsLista, (parent, view) =>
				{
					return view.Y + view.Height + 10;
				})
			);
			layoutRelative.Children.Add(addIng,Constraint.RelativeToView(gridIng, (parent, view) =>
				{
					return view.X + 5;
				}),
			                            Constraint.RelativeToView(gridIng, (parent, view) =>
				{
				return view.Y+view.Height+40;
				})
			);
			Content = layoutRelative;
			UpdateList();
			ingredientsLista.ItemTapped += IngredientsLista_ItemTapped;//remove with tap
			addIng.Clicked += AddIng_Clicked;

		}
		public void UpdateList()
		{

			ingredientsLista.ItemTemplate = new DataTemplate(typeof(ingredients_lista));
			using (var ingredients = new DataAccess())
			{
				ingredientsLista.ItemsSource = ingredients.GetItems();
			}
		}

		void IngredientsLista_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			using (var ing = new DataAccess())
			{
				ing.DeletemyIng((ingredients_items)e.Item);
				ingredientsLista.ItemsSource = ing.GetItems();
			}

		}

		void AddIng_Clicked(object sender, EventArgs e)
		{
			ingredients_items newIngredient = new ingredients_items
			{
				IngredientQuantity=double.Parse(quantityEntry.Text),
				IngredientType = typeEntry.Text,
				IngredientName = nameEntry.Text
			};
			using (var ingredients = new DataAccess())
			{
				ingredients.InsertmyIng(newIngredient);
				ingredientsLista.ItemsSource = ingredients.GetItems();
			}
			UpdateList();
			DisplayAlert("Ingredient added", "Yesss", "Ok");
			quantityEntry.Text = "";
			typeEntry.Text = "";
			nameEntry.Text = "";

		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			UpdateList();
		}
	}
}


