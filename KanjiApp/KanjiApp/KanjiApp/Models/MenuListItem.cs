using System;
using System.Collections.Generic;
using System.Text;

namespace KanjiApp.Models
{
    public class MenuListItem
    {
		public string Text { get; set; }
		public string URI { get; set; }
		public string Image { get; set; }
		public Boolean IsSeparatorVisible { get; set; }
	}
}
