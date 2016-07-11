using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using System.Diagnostics;
using Xamarin.Forms;

namespace VeganReceptApp
{
	public class ReceptPage : ContentPage
	{
		RelativeLayout layoutRecept = new RelativeLayout() { HeightRequest = 100 };
		Button ingredients;//Global to be able to access outside ReceptPage()
		Label numPersonLabel;
		double numPerson = 1;//counter 
		List<ingredients_items> ingredientsItems;
		List<instructions_items> instructionsItems;
		//ListView items_listView = new ListView();
		public ReceptPage(ReceptViewModel recept)
		{
			var foodImg = new Image()
			{
				Aspect = Aspect.AspectFill,
				Source = ImageSource.FromFile("lettuce.png"),//Source must come from database
				HeightRequest = 100,
				WidthRequest = 200
			};
			//Now I create the buttons which represents differents options

			var favoriteIcon = new Button
			{
				Image = "favorite.png",
				HeightRequest = 30,
				WidthRequest = 30
			};
			var personIcon = new Image()
			{
				Source = ImageSource.FromFile("person.png"),
				HeightRequest = 30,
				WidthRequest = 30
			};

			numPersonLabel = new Label
			{
				Text = numPerson.ToString(),
				HeightRequest = 30,
				WidthRequest = 30
			};

			var add_person = new Button
			{
				Text = "+",//Now is a text but we can change to a image instead
				TextColor = Color.Black,
				FontSize=20,
				HeightRequest = 20,
				WidthRequest = 20

			};

			var less_person = new Button
			{
				Text = "-",
				TextColor = Color.Black,
				FontSize = 20,
				HeightRequest = 20,
				WidthRequest = 20
			};
			ingredients = new Button
			{
				Text = "Ingredients",
				FontSize = 20
			};
			var instructions = new Button
			{
				Text = "Instructions",
				FontSize = 20
			};
			layoutRecept.Children.Add(foodImg,
				Constraint.Constant(0),
				Constraint.Constant(50),
				Constraint.RelativeToParent((parent) =>
				{
					return parent.Width;
				}),
				Constraint.RelativeToParent((parent) =>
				{
					return parent.Height * .4;
				})
			);
			layoutRecept.Children.Add(favoriteIcon, Constraint.Constant(10),
				Constraint.RelativeToView(foodImg, (parent, view) =>
				{
					return view.Y + view.Height + 10;
				})
			);

			layoutRecept.Children.Add(personIcon,
				Constraint.RelativeToView(favoriteIcon, (parent, view) =>
				{
					return view.X + 40;
				}),
				Constraint.RelativeToView(favoriteIcon, (parent, view) =>
				{
					return view.Y;
				})
			);
			layoutRecept.Children.Add(numPersonLabel,
				Constraint.RelativeToView(personIcon, (parent, view) =>
				{
					return view.X + 40;
				}),
				Constraint.RelativeToView(personIcon, (parent, view) =>
				{
					return view.Y;
				})
			);
			layoutRecept.Children.Add(add_person,
				Constraint.RelativeToView(numPersonLabel, (parent, view) =>
				{
					return view.X + 20;
				}),
				Constraint.RelativeToView(numPersonLabel, (parent, view) =>
				{
					return view.Y-5;
				})
			);
			layoutRecept.Children.Add(less_person,
			                          Constraint.RelativeToView(add_person, (parent, view) =>
				{
					return view.X;
				}),
			                          Constraint.RelativeToView(add_person, (parent, view) =>
				{
					return view.Y+15;
				})
			);
			layoutRecept.Children.Add(ingredients, Constraint.Constant(40),
				Constraint.RelativeToView(favoriteIcon, (parent, view) =>
				{
					return view.Y + view.Height + 20;
				})
			);
			layoutRecept.Children.Add(instructions,
				Constraint.RelativeToView(ingredients, (parent, view) =>
				{
					return view.X + view.Width + 40;
				}),
				Constraint.RelativeToView(ingredients, (parent, view) =>
				{
					return view.Y;
				})
			);
			ingredients.Clicked += ShowIngredients;
			instructions.Clicked += ShowInstructions;
			add_person.Clicked += (object sender, EventArgs e) =>
			{
				numPerson += 1;
				numPersonLabel.Text = numPerson.ToString();
				LoadDataToList("ingredients");
			};
			less_person.Clicked += (object sender, EventArgs e) => 
			{
				numPerson -= 1;
				if (numPerson <= 0)
					numPerson = 1;
				numPersonLabel.Text = numPerson.ToString();
				LoadDataToList("ingredients");
			};
			favoriteIcon.Clicked += (object sender, EventArgs e) => 
			{
				using (var newRecep = new DataAccessFavorite())
				{
					newRecep.InsertRecep(recept);
				}
				string recName = recept.ReceptName;
				DisplayAlert(recName, "has been added", "OK");
			};
			Content = layoutRecept;
		}

		void LoadDataToList(string lista)
		{
			if (lista == "ingredients")
			{
				var listIng = new ListView
				{
					HeightRequest = 200,
					ItemTemplate = new DataTemplate(typeof(ingredients_lista))
				};
				ingredientsItems = new List<ingredients_items>
				{
					new ingredients_items{IngredientQuantity=2.0*numPerson,IngredientType="kg",IngredientName="Eggs"},
					new ingredients_items{IngredientQuantity=4.0*numPerson,IngredientType="st",IngredientName="Banan"},
					new ingredients_items{IngredientQuantity=5.0*numPerson,IngredientType="liter",IngredientName="Water"}
				};
				listIng.ItemsSource = ingredientsItems;
				listIng.SeparatorVisibility = SeparatorVisibility.None;
				layoutRecept.Children.Add(listIng, Constraint.Constant(40),
										  Constraint.RelativeToView(ingredients, (parent, view) =>
										   {
											   return view.Y + view.Height + 10;
										   })
										 );
				//return listIng;
				listIng.ItemTapped += (object sender, ItemTappedEventArgs e) => 
				{
					using (var ingredients = new DataAccess())
					{
						ingredients.InsertmyIng((ingredients_items)e.Item);
					}
					string itemAdded = ((ingredients_items)e.Item).IngredientName.ToString();
					DisplayAlert(itemAdded, "has been added", "OK");
				};
			}
			else if(lista == "instructions"){
				var listInst = new ListView
				{
					HeightRequest=200,
					ItemTemplate= new DataTemplate(typeof(instructions_lista))
				};
				instructionsItems = new List<instructions_items>
				{
					new instructions_items{InstNummer=1,InstText="Hello chop eggs"},
					new instructions_items{InstNummer=2,InstText="GoodBye, drink milk"}
				};
				listInst.ItemsSource = instructionsItems;
				listInst.SeparatorVisibility = SeparatorVisibility.None;
				layoutRecept.Children.Add(listInst, Constraint.Constant(40),
										  Constraint.RelativeToView(ingredients, (parent, view) =>
				 							{
					 							return view.Y + view.Height + 10;
											 })
										 );
			}

		}
		void ShowIngredients(object sender, EventArgs e) 
		{
			LoadDataToList("ingredients");
		}
		void ShowInstructions(object sender, EventArgs e)
		{
			LoadDataToList("instructions");
		}
		protected override void OnAppearing()
		{
			//base.OnAppearing();
			LoadDataToList("ingredients");
		}

	}
}


