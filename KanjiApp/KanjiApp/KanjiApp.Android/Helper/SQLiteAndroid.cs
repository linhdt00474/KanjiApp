using System;
using System.IO;
using Android.Content.Res;
using KanjiApp.Droid.Helpers;
using KanjiApp.Interfaces;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteAndroid))]
namespace KanjiApp.Droid.Helpers
{
	public class SQLiteAndroid : ISQLite
	{
		public SQLiteAndroid()
		{
		}

		#region ISQLite implementation
		public SQLiteConnection GetConnection()
		{
			var documentPath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath + "/Kanji";
			var fileName = "databaseKanjiN12345.sqlite";
			var dbPath = Path.Combine(documentPath, fileName);

			var conn = new SQLiteConnection(dbPath);
			// Return the database connection 
			return conn;
		}
		#endregion

		/// <summary>
		/// helper method to get the database out of /raw/ and into the user filesystem
		/// </summary>
		void ReadWriteStream(Stream readStream, Stream writeStream)
		{
			int Length = 256;
			Byte[] buffer = new Byte[Length];
			int bytesRead = readStream.Read(buffer, 0, Length);
			// write the required bytes
			while (bytesRead > 0)
			{
				writeStream.Write(buffer, 0, bytesRead);
				bytesRead = readStream.Read(buffer, 0, Length);
			}
			readStream.Close();
			writeStream.Close();
		}
	}
}