using Xamarin.Forms;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using KanjiApp.Models;
using KanjiApp.ViewModels;

namespace KanjiApp.Views
{
    public partial class LessonListPopUp : PopupPage
    {
        public LessonListPopUp()
        {
            InitializeComponent();
        }

		private void OnCloseButtonTapped(object sender, EventArgs e)
		{
			CloseAllPopup();
		}

		protected override bool OnBackgroundClicked()
		{
			CloseAllPopup();

			return false;
		}

		private async void CloseAllPopup()
		{
			await Navigation.PopAllPopupAsync();
		}

		private void OnItemTapped(object sender, ItemTappedEventArgs e)
		{
			Lesson lesson = e.Item as Lesson;
			CloseAllPopup();
		}

	}
}
