using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;

namespace KanjiApp.Views
{
	public partial class Check : PopupPage
	{
		public Check()
		{
			InitializeComponent();
		}

		private void OnCloseButtonTapped(object sender, EventArgs e)
		{
			CloseAllPopup();
		}

		private async void CloseAllPopup()
		{
			await Navigation.PopAllPopupAsync();
		}
	}
}