using KanjiApp.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KanjiApp.Models;
using KanjiApp.Interfaces;
using SQLite;
using Xamarin.Forms;

namespace KanjiApp.Models.Repositories
{
	public class LessonRepository:ILessonRepository
	{
		SQLiteConnection database;
		const string DB_PATH = "/mnt/sdcard/KanjiApp/databaseKanjiN12345.sqlite";
		public LessonRepository()
		{
			OpenConnection();
		}

		public void OpenConnection()
		{
			database = DependencyService.Get<ISQLite>().GetConnection();
			//database = new SQLiteConnection(DB_PATH);
		}

		public void CloseConnection()
		{
			database.Close();
		}

		public List<Lesson> GetLessonsByLevelID(int levelID)
		{
			var lessons = new List<Lesson>();
			foreach (Lesson lesson in database.Table<Lesson>().Where(i => i.LevelID == levelID))
			{
				lessons.Add(lesson);
			}
			CloseConnection();
			return lessons;
		}

		public string GetLessonNameByLessonID(int lessonID)
		{
			var lessonName = database.Table<Lesson>().Where(i => i.LessonID == lessonID).FirstOrDefault().LessonName;
			CloseConnection();
			return lessonName;
		}

	}
}
