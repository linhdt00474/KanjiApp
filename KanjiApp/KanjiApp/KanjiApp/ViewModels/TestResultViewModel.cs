using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using KanjiApp.Models;
using System.Collections.ObjectModel;

namespace KanjiApp.ViewModels
{
	public class TestResultViewModel : BindableBase, INavigatedAware
	{
		INavigationService _navigationService;

		public DelegateCommand<string> OnNavigateCommand { get; set; }

		private string _adviceMessage;
		public string AdviceMessage
		{
			get { return _adviceMessage; }
			set { SetProperty(ref _adviceMessage, value); }
		}

		private int _score;
		public int Score
		{
			get { return _score; }
			set { SetProperty(ref _score, value); }
		}

		private ObservableCollection<AnsweredQuestion> answeredQuestions;
		public ObservableCollection<AnsweredQuestion> AnsweredQuestions
		{
			get { return answeredQuestions; }
			set { SetProperty(ref answeredQuestions, value); }
		}

		public TestResultViewModel()
        {
			AnsweredQuestions = new ObservableCollection<AnsweredQuestion>();
		}

		public void OnNavigatedFrom(INavigationParameters parameters)
		{
			throw new NotImplementedException();
		}

		public void OnNavigatedTo(INavigationParameters parameters)
		{
			Score = int.Parse(parameters["Score"].ToString());
			AnsweredQuestions = parameters["AnsweredQuestions"] as ObservableCollection<AnsweredQuestion>;
		}
	}
}
