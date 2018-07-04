using KanjiApp.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KanjiApp.Models;
using SQLite;
using Xamarin.Forms;
using KanjiApp.Interfaces;

namespace KanjiApp.Models.Repositories
{
	public class LevelRepository: ILevelRepository
	{
		SQLiteConnection database;
		public LevelRepository()
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

		public List<Level> GetLevelList()
		{
			var levels = new List<Level>();
			foreach (Level level in database.Table<Level>())
			{
				levels.Add(level);
			}
			CloseConnection();
			return levels;
		}

		public string GetLevelNameByLevelID(int levelID)
		{
			var levelName = database.Table<Level>().Where(i => i.LevelID == levelID).FirstOrDefault().LevelName;
			CloseConnection();
			return levelName;
		}

		public int GetLevelIDByLessonID(int lessonID)
		{
			var levelId = database.Table<Lesson>().Where(i => i.LessonID == lessonID).FirstOrDefault().LevelID;
			CloseConnection();
			return levelId;
		}
	}
}
