using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SQLite.Net.Attributes;
namespace VeganReceptApp
{
	
	public class ReceptViewModel
	{
		
		[PrimaryKey, AutoIncrement]

		public int ReceptID { get; set; }
		public string ReceptName { get; set; }
		public string ReceptImage { get; set; }
		public string ReceptTime2cook { get; set;}
		public string ReceptServings { get; set; }

		public List<ingredients_items> ingr { get; set; }
		public List<instructions_items> instr { get; set; }
		/*public override string ToString()
		{
			return string.Format("[ReceptViewModel : ReceptID={0}, ReceptName={1}, ReceptImage={2}]",ReceptID,ReceptName,ReceptImage);
		}*/
	}
}

