using System;
using System.Collections.Generic;
using System.Text;
using KanjiApp.Models;
using KanjiApp.Models.Repositories;
using System.Threading.Tasks;
using KanjiApp.Interfaces;
namespace KanjiApp.Services
{
    public class LessonService
    {
		private LessonRepository lessonRepository;
		public LessonService()
		{
			lessonRepository = new LessonRepository();
		}

		public List<Lesson> GetLessonListByLevelID(int levelID)
		{
			return lessonRepository.GetLessonsByLevelID(levelID);
		}

		public string GetLessonNameByLessonID(int lessonID)
		{
			return lessonRepository.GetLessonNameByLessonID(lessonID);
		}
	}
}
