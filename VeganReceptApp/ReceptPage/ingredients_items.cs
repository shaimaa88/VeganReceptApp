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
		public int sqlIngId { get; set; }
		public string IngAmount { get; set; }
		public string IngUnit { get; set; }
		public string IngName { get; set; }

		public override string ToString()
		{
			return string.Format("[ingredients_items : ID_ing={0}, IngAmount={1}, IngUnit={2}, IngName={3}]", IngAmount, IngUnit, IngName);
		}
	}

}

