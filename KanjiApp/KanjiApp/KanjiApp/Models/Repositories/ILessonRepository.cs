using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KanjiApp.Models.Repositories
{
    public interface ILessonRepository
    {
		List<Lesson> GetLessonsByLevelID(int levelID);
		string GetLessonNameByLessonID(int lessonID);
	}
}
