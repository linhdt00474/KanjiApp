using KanjiApp.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KanjiApp.Models;
using KanjiApp.Utilities;
using SQLite;
using Xamarin.Forms;
using KanjiApp.Interfaces;
namespace KanjiApp.Models.Repositories
{
	public class QuestionRepository: IQuestionRepository
	{
		SQLiteConnection database;

		public QuestionRepository()
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

		public List<QuestionKanji> GetQuestionList(int levelID, int lessonID)
		{
			var questions = new List<QuestionKanji>();
			var question1 = database.Table<QuestionKanji>().Take(10);
			var questonList = database.Table<QuestionKanji>().Where(i => i.LevelID == levelID);
			foreach (QuestionKanji question in database.Table<QuestionKanji>().Where(i => i.LevelID == levelID).Where(i=> i.LessonID == lessonID))
			{
				questions.Add(question);
			}
			CloseConnection();
			return questions;
		}

		public IList<Answer> GetAnswerListByQuestionId(int questionID)
		{
			var answerList = new List<Answer>();
			QuestionKanji question = database.Table<QuestionKanji>().Where(i => i.QuestionID == questionID).ElementAt(0);
			answerList.Add(new Answer() { AnswerText = question.CorrectAnswer, IsCorrect = true });
			int levelID = question.LevelID;
			var randomQuestions = GetRandomListOfQuestion(levelID);
			foreach (var item in randomQuestions)
			{
				answerList.Add(new Answer() { AnswerText = item.CorrectAnswer, IsCorrect = false });
			}
			CloseConnection();
			return RandomUtils.Shuffle<Answer>(answerList);
		}

		public IList<QuestionKanji> GetRandomListOfQuestion(int levelID)
		{
			var questions = new List<QuestionKanji>();
			foreach (QuestionKanji question in database.Table<QuestionKanji>().Where(i => i.LevelID == levelID))
			{
				questions.Add(question);
			}
			var questionList = RandomUtils.PickSomeInRandomOrder<QuestionKanji>(questions, 3);
			return questionList;
		}
	}
}
