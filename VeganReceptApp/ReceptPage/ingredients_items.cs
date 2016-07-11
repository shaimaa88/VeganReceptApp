using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using SQLite.Net.Attributes;

namespace VeganReceptApp
{
	public class ingredients_items
	{
		[PrimaryKey, AutoIncrement]
		public int ID_ing { get; set; }
		public double IngredientQuantity { get; set; }
		public string IngredientType { get; set; }
		public string IngredientName { get; set; }

		public override string ToString()
		{
			return string.Format("[ingredients_items : ID_ing={0}, IngredientQuantity={1}, IngredientType={2}, IngredientName={3}]", ID_ing, IngredientQuantity, IngredientType, IngredientName);
		}
	}

}

