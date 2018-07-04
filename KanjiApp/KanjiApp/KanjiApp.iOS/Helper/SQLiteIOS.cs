using System;
using System.IO;
using KanjiApp.iOS.Helpers;
using KanjiApp.Interfaces;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteIOS))]
namespace KanjiApp.iOS.Helpers
{
	public class SQLiteIOS : ISQLite
	{
		public SQLiteIOS()
		{
		}

		#region ISQLite implementation
		public SQLiteConnection GetConnection()
		{
			var sqliteFilename = "databaseKanjiN12345.sqlite";
			string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
			string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
			var path = Path.Combine(libraryPath, sqliteFilename);

			// This is where we copy in the prepopulated database
			//Console.WriteLine(path);
			if (!File.Exists(path))
			{
				File.Copy(sqliteFilename, path);
			}

			var conn = new SQLiteConnection(path);

			// Return the database connection 
			return conn;
		}
		#endregion
	}
}