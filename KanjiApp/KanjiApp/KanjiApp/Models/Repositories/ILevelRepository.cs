using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KanjiApp.Models.Repositories
{
    public interface ILevelRepository
    {
		List<Level> GetLevelList();
		string GetLevelNameByLevelID(int levelID);
		int GetLevelIDByLessonID(int lessonID);
	}
}
