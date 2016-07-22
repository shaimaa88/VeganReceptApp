using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using SQLite.Net.Attributes;
namespace VeganReceptApp
{
	public class instructions_items
	{
		[PrimaryKey, AutoIncrement]
		public int sqlInstId { get; set; }
		public int InstNummer { get; set; }
		public string InstText { get; set;}

		public override string ToString()
		{
			return string.Format("[instructions_items : ID_inst={0}, InstNummer={1}, InstText={2}]", InstNummer, InstText);
		}


	}
}

