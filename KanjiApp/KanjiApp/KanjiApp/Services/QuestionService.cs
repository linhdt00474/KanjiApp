using KanjiApp.Models;
using KanjiApp.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace KanjiApp.Services
{
    public class QuestionService
    {
		private QuestionRepository _questionRepository;
		public QuestionService()
		{
			_questionRepository = new QuestionRepository();
		}

		public List<QuestionKanji> GetQuestionList(int levelID, int questionID)
		{
			var questions = _questionRepository.GetQuestionList(levelID, questionID);
			return questions;
		}

		public ObservableCollection<Answer> GetAnswerListByQuestionId(int rowID)
		{
			ObservableCollection<Answer> answerCollection = new ObservableCollection<Answer>();
			var answers = _questionRepository.GetAnswerListByQuestionId(rowID) as List<Answer>;
			foreach (var answer in answers)
			{
				answerCollection.Add(answer);
			}
			return answerCollection;
		}
	}
}
