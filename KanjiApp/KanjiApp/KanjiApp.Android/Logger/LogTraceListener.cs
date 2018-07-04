using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace KanjiApp.Droid.Logger
{
	public class LogTraceListener : System.Diagnostics.TraceListener
	{
		public override void Write(string message)
		{
			Android.Util.Log.WriteLine(Android.Util.LogPriority.Debug, "KanjiApp", message);
		}

		public override void WriteLine(string message)
		{
			Android.Util.Log.WriteLine(Android.Util.LogPriority.Debug, "KanjiApp", message);
		}
	}
}