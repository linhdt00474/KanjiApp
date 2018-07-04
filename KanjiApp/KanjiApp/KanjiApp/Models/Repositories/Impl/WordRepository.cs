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
	public class WordRepository: IWordRepository
	{
		const int NUMBER_OF_WORDS_PER_LESSONS = 12;
		SQLiteConnection database;
		public WordRepository()
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

		public List<Word> GetWordListByLessonId(int lessonID, int levelID)
		{
			var words = new List<Word>();
			int startRowIndex = (lessonID - 1) * NUMBER_OF_WORDS_PER_LESSONS;
			foreach (Word word in database.Table<Word>().Where(i => i.LevelID == levelID).Skip(startRowIndex).Take(NUMBER_OF_WORDS_PER_LESSONS))
			{
				words.Add(word);
			}
			CloseConnection();
			return words;
		}

		public List<Word> GetWordListByLevelID(int levelID)
		{
			var words = new List<Word>();
			foreach (Word word in database.Table<Word>().Where(i => i.LevelID == levelID))
			{
				words.Add(word);
			}
			CloseConnection();
			return words;
		}

		public List<Word> GetWordList()
		{
			var words = new List<Word>();
			foreach (Word word in database.Table<Word>())
			{
				words.Add(word);
			}
			CloseConnection();
			return words;
		}
	}
}
