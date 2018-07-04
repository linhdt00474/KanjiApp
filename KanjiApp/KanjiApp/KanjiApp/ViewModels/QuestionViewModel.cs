using KanjiApp.Models;
using KanjiApp.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using KanjiApp.Utilities;
using System.Threading.Tasks;

namespace KanjiApp.ViewModels
{
	public class QuestionViewModel : BindableBase, INavigatedAware
	{
		INavigationService _navigationService;

		private Timer _timer;

		private TimeSpan _totalSeconds;
		public TimeSpan TotalSeconds
		{
			get { return _totalSeconds; }
			set { SetProperty(ref _totalSeconds, value); }
		}

		public Command StartCommand { get; set; }
		public Command StopCommand { get; set; }

		private bool _isLoading;
		public bool IsLoading
		{
			get { return this._isLoading; }
			set { SetProperty(ref _isLoading, value); }
		}

		private int _lessonID;
		public int LessonID
		{
			get { return _lessonID; }
			set
			{
				SetProperty(ref _lessonID, value);
			}
		}

		private int _levelID;
		public int LevelID
		{
			get { return _levelID; }
			set
			{
				SetProperty(ref _levelID, value);
			}
		}

		private ObservableCollection<QuestionKanji> _questions;
		public ObservableCollection<QuestionKanji> Questions
		{
			get { return _questions; }
			set
			{
				SetProperty(ref _questions, value);
			}
		}

		private ObservableCollection<AnsweredQuestion> _answeredQuestions;
		public ObservableCollection<AnsweredQuestion> AnsweredQuestions
		{
			get { return _answeredQuestions; }
			set
			{
				SetProperty(ref _answeredQuestions, value);
			}
		}

		private QuestionKanji _currentQuestion;
		public QuestionKanji CurrentQuestion
		{
			get { return _currentQuestion; }
			set
			{
				SetProperty(ref _currentQuestion, value);
			}
		}

		private string _currentKanji;

		public string CurrentKanji
		{
			get { return _currentKanji; }
			set
			{
				SetProperty(ref _currentKanji, value);
			}
		}

		private ObservableCollection<Answer> _currentAnswers;

		public ObservableCollection<Answer> CurrentAnswers
		{
			get { return _currentAnswers; }
			set
			{
				SetProperty(ref _currentAnswers, value);
			}
		}

		private int _currentQuestionNo;
		public int CurrentQuestionNo
		{
			get { return _currentQuestionNo; }
			set
			{
				SetProperty(ref _currentQuestionNo, value);
			}
		}

		private int _score;
		public int Score
		{
			get { return _score; }
			set
			{
				SetProperty(ref _score, value);
			}
		}

		public QuestionViewModel(INavigationService navigationService)
        {
			_navigationService = navigationService;
			AnsweredQuestions = new ObservableCollection<AnsweredQuestion>();
		}

		public void OnNavigatedFrom(INavigationParameters parameters)
		{

		}

		public void OnNavigatedTo(INavigationParameters parameters)
		{
			try
			{
				//IsLoading = true;
				LessonID = int.Parse(parameters["LessonID"].ToString());
				LevelID = int.Parse(parameters["LevelID"].ToString());
				#region Start Timer
				StartCommand = new Command(StartTimerCommand);
				StopCommand = new Command(StopTimerCommand);
				TotalSeconds = new TimeSpan(0, 0, 0, 15);
				_timer = new Timer(TimeSpan.FromSeconds(1), CountDown);
				#endregion
				#region Load questions
				List<QuestionKanji> questionList = new QuestionService().GetQuestionList(LevelID, LessonID);
				ObservableCollection<QuestionKanji> questionCollection = new ObservableCollection<QuestionKanji>();
				foreach (QuestionKanji question in questionList)
				{
					questionCollection.Add(question);
				}
				Questions = questionCollection;
				CurrentQuestionNo = 1;
				Init();
				#endregion
				//IsLoading = false;
				_timer.Start();
			}
			catch (Exception)
			{
				throw;
			}
		}

		public ICommand WordClickCommand
		{
			get
			{
				return new Command(async (item) =>
				{
					var answer = item as Answer;
					var answeredQuestion = new AnsweredQuestion()
					{
						Question = CurrentQuestion.Question,
						CorrectAnswer = CurrentQuestion.CorrectAnswer,
						IsCorrect = answer.IsCorrect,
						UserAnswer = answer.AnswerText
					};
					StopTimerCommand();
					SaveTestResult(answeredQuestion);
					if (answer.IsCorrect)
					{
						answer.BackgroundColor = "#90d571";
						answer.BorderColor = "#90d571";
					}
					else
					{
						answer.BackgroundColor = "#ff8997";
						answer.BorderColor = "#ff8997";
					}
					
					await Task.Delay(2000);
					if (answer.IsCorrect)
					{
						Score++;
					}
					ChooseNewQuestion();
				});
			}
		}

		public ICommand SkipClickCommand
		{
			get
			{
				return new Command(() =>
				{
					var answeredQuestion = new AnsweredQuestion()
					{
						Question = CurrentQuestion.Question,
						CorrectAnswer = CurrentQuestion.CorrectAnswer,
						IsCorrect = false,
						UserAnswer = string.Empty
					};
					StopTimerCommand();
					SaveTestResult(answeredQuestion);
					ChooseNewQuestion();
				});
			}
		}

		private void StartTimerCommand()
		{
			_timer.Start();
		}

		private void CountDown()
		{
			if (_totalSeconds.TotalSeconds == 0)
			{
				//do something after hitting 0, in this example it just stops/resets the timer
				StopTimerCommand();
				var answeredQuestion = new AnsweredQuestion()
				{
					Question = CurrentQuestion.Question,
					CorrectAnswer = CurrentQuestion.CorrectAnswer,
					IsCorrect = false,
					UserAnswer = string.Empty
				};
				SaveTestResult(answeredQuestion);
				ChooseNewQuestion();
			}
			else
			{
				TotalSeconds = _totalSeconds.Subtract(new TimeSpan(0, 0, 0, 1));
			}
		}

		private void StopTimerCommand()
		{
			_timer.Stop();
		}

		private void ResetTimerCommand()
		{
			TotalSeconds = new TimeSpan(0, 0, 0, 15);
			_timer = new Timer(TimeSpan.FromSeconds(1), CountDown);
			StartTimerCommand();
		}

		private void ChooseNewQuestion()
		{
			//IsLoading = true;
			if (CurrentQuestionNo < 10)
			{
				CurrentQuestionNo++;
				Init();
				ResetTimerCommand();
			}
			else
			{
				ShowTestResult();
			}
			//IsLoading = false;
		}

		private void Init()
		{
			CurrentQuestion = Questions[CurrentQuestionNo-1];
			CurrentKanji = Questions[CurrentQuestionNo-1].Question;
			CurrentAnswers = new QuestionService().GetAnswerListByQuestionId(Questions[CurrentQuestionNo-1].QuestionID);
			foreach (var answer in CurrentAnswers)
			{
				answer.BackgroundColor = "#ffffff";
				answer.BorderColor = "#000000";
			}
		}

		private void SaveTestResult(AnsweredQuestion answeredQuestion)
		{
			try
			{
				AnsweredQuestions.Add(answeredQuestion);
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void ShowTestResult()
		{
			var navParameters = new NavigationParameters();
			navParameters.Add("Score", Score);
			navParameters.Add("AnsweredQuestions", AnsweredQuestions);
			_navigationService.NavigateAsync(new Uri("TestResult" + navParameters.ToString(), UriKind.Relative));
		}
	}
}
