using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KanjiApp.Models.Repositories
{
    public interface IWordRepository
	{
		List<Word> GetWordListByLessonId(int lessonID, int levelID);
		List<Word> GetWordListByLevelID(int levelID);
	}
}
