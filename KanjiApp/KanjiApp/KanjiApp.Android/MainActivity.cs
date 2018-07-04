using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using KanjiApp.Droid.Logger;
using Prism;
using Prism.Ioc;
using System.IO;

namespace KanjiApp.Droid
{
    [Activity(Label = "KanjiApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
			AssetManager assets = this.Assets;
			//var documentPath = Android.OS.Environment.ExternalStorageDirectory.Path;
			var documentPath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath + "/Kanji";

			if (!Directory.Exists(documentPath))
			{
				Directory.CreateDirectory(documentPath);
			}

			var fileName = "databaseKanjiN12345.sqlite";
			var dbPath = Path.Combine(documentPath, fileName);
			using (var br = new BinaryReader(assets.Open("databaseKanjiN12345.sqlite")))
			{
				using (var bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
				{
					byte[] buffer = new byte[2048];
					int length = 0;
					while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
					{
						bw.Write(buffer, 0, length);
					}
				}
			}
			global::Rg.Plugins.Popup.Popup.Init(this, bundle);
			global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));
			System.Diagnostics.Debug.Listeners.Add(new LogTraceListener());
		}
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            // Register any platform specific implementations
        }
    }
}

