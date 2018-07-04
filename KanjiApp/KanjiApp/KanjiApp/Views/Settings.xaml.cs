using Xamarin.Forms;

namespace KanjiApp.Views
{
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
        }

		private void btnOption1_OnClicked(object sender)
		{
			btnOption1.BackgroundColor = Color.Blue;
			btnOption1.TextColor = Color.White;
			btnOption2.BackgroundColor = Color.White;
			btnOption2.TextColor = Color.Blue;
			btnOption3.BackgroundColor = Color.White;
			btnOption3.TextColor = Color.Blue;
		}
		private void btnOption2_OnClicked(object sender)
		{
			btnOption2.BackgroundColor = Color.Blue;
			btnOption2.TextColor = Color.White;
			btnOption1.BackgroundColor = Color.White;
			btnOption1.TextColor = Color.Blue;
			btnOption3.BackgroundColor = Color.White;
			btnOption3.TextColor = Color.Blue;
		}
		private void btnOption3_OnClicked(object sender)
		{
			btnOption3.BackgroundColor = Color.Blue;
			btnOption3.TextColor = Color.White;
			btnOption2.BackgroundColor = Color.White;
			btnOption2.TextColor = Color.Blue;
			btnOption1.BackgroundColor = Color.White;
			btnOption1.TextColor = Color.Blue;
		}
		private void btnOption4_OnClicked(object sender)
		{
			btnOption4.BackgroundColor = Color.Blue;
			btnOption4.TextColor = Color.White;
			btnOption5.BackgroundColor = Color.White;
			btnOption5.TextColor = Color.Blue;
			btnOption6.BackgroundColor = Color.White;
			btnOption6.TextColor = Color.Blue;
		}
		private void btnOption5_OnClicked(object sender)
		{
			btnOption5.BackgroundColor = Color.Blue;
			btnOption5.TextColor = Color.White;
			btnOption4.BackgroundColor = Color.White;
			btnOption4.TextColor = Color.Blue;
			btnOption6.BackgroundColor = Color.White;
			btnOption6.TextColor = Color.Blue;
		}
		private void btnOption6_OnClicked(object sender)
		{
			btnOption6.BackgroundColor = Color.Blue;
			btnOption6.TextColor = Color.White;
			btnOption4.BackgroundColor = Color.White;
			btnOption4.TextColor = Color.Blue;
			btnOption5.BackgroundColor = Color.White;
			btnOption5.TextColor = Color.Blue;
		}
	}
}
