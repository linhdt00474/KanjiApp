using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KanjiApp.Views;

namespace KanjiApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Question : ContentPage
	{
		public Question ()
		{
			InitializeComponent ();
		}
	}
}