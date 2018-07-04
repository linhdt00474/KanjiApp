using KanjiApp.Models;
using KanjiApp.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace KanjiApp.Services
{
    public class WordService
    {
		private WordRepository wordRepository;
		public WordService()
		{
			wordRepository = new WordRepository();
		}

		public List<Word> GetWordListByLessonID(int lessonID, int levelID)
		{
			var words = wordRepository.GetWordListByLessonId(lessonID, levelID);
			return words;
		}

		public List<Word> GetWordListByLevelID(int levelID)
		{
			var words = wordRepository.GetWordListByLevelID(levelID);
			return words;
		}

		public List<Word> GetWordList()
		{
			var words = wordRepository.GetWordList();
			return words;
		}

	}
}
