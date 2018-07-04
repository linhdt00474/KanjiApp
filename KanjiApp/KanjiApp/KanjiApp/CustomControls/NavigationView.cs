using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace KanjiApp.CustomControls
{
    public class NavigationView:ContentView
    {
		public static readonly BindableProperty TitleProperty =
									BindableProperty.Create("Title",
										typeof(string),
										typeof(NavigationView),
										defaultValue: null,
										defaultBindingMode: BindingMode.TwoWay);

		public string Title
		{
			get => (string)GetValue(TitleProperty);
			set => SetValue(TitleProperty, value);
		}
	}
}
