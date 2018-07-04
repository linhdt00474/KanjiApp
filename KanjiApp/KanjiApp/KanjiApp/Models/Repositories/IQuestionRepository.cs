using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KanjiApp.Models.Repositories
{
    public interface IQuestionRepository
	{
		List<QuestionKanji> GetQuestionList(int levelID, int lessonID);
		IList<Answer> GetAnswerListByQuestionId(int questionID);
		IList<QuestionKanji> GetRandomListOfQuestion(int levelID);
	}
}
