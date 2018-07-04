using System;
using System.Collections.Generic;
using System.Text;
using KanjiApp.Models;
using KanjiApp.Models.Repositories;

namespace KanjiApp.Services
{
	public class LevelService
	{
		private LevelRepository levelRepository;
		public LevelService()
		{
			levelRepository = new LevelRepository();
		}

		public string GetLevelNameByLevelID(int levelID)
		{
			return levelRepository.GetLevelNameByLevelID(levelID);
		}

		public int GetLevelIDByLessonID(int lessonID)
		{
			return levelRepository.GetLevelIDByLessonID(lessonID);
		}
	}
}
