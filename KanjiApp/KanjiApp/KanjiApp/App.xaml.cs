using Prism;
using Prism.Ioc;
using KanjiApp.ViewModels;
using KanjiApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using DLToolkit.Forms.Controls;
using System;

using Unity;
using Prism.Navigation;
using Prism.Common;
using Prism.Plugin.Popups;
using System.Threading.Tasks;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace KanjiApp
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
			InitializeComponent();
			FlowListView.Init();
			await NavigationService.NavigateAsync(new System.Uri("/NavigationPage/SplashScreen", System.UriKind.Absolute));
			await Task.Delay(1000);
			await NavigationService.NavigateAsync(new System.Uri("/SideMenu/NavigationPage/HomePage", System.UriKind.Absolute));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
			containerRegistry.RegisterPopupNavigationService();
			containerRegistry.RegisterForNavigation<NavigationPage>();
			containerRegistry.RegisterForNavigation<SideMenu, SideMenuViewModel>();
			containerRegistry.RegisterForNavigation<HomePage>();
			containerRegistry.RegisterForNavigation<Settings>();
			containerRegistry.RegisterForNavigation<LessonDetail>();
			containerRegistry.RegisterForNavigation<KanjiList>();
			containerRegistry.RegisterForNavigation<Question>();
			containerRegistry.RegisterForNavigation<Example>();
			containerRegistry.RegisterForNavigation<LessonListPopUp>();
			containerRegistry.RegisterForNavigation<Check>();
			containerRegistry.RegisterForNavigation<TestResult>();
			containerRegistry.RegisterForNavigation<SplashScreen>();
		}

		public async void OnBackButtonPressed(object sender, EventArgs e)
		{
			await NavigationService.GoBackAsync();
		}

		protected override void OnStart()
		{
			base.OnStart();
			AppCenter.Start("android=cd04fd35-7f90-4c88-9f40-8968d64d326d;" +
				  "uwp={Your UWP App secret here};" +
				  "ios={Your iOS App secret here}",
				  typeof(Analytics), typeof(Crashes));
		}
	}
}
