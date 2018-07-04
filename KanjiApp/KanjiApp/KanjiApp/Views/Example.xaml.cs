using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;

namespace KanjiApp.Views
{
    public partial class Example : PopupPage
    {
        public Example()
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
