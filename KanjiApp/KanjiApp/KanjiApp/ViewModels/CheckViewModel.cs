using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KanjiApp.ViewModels
{
	public class CheckViewModel : BindableBase, INavigatedAware
	{
		INavigationService _navigationService;

		public DelegateCommand NavigateToQuestionCommand { get; set; }

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

		public CheckViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
			NavigateToQuestionCommand = new DelegateCommand(NavigateToQuestionPage);
		}

		public void OnNavigatedFrom(INavigationParameters parameters)
		{

		}

		public void OnNavigatedTo(INavigationParameters parameters)
		{
			LessonID = int.Parse(parameters["LessonID"].ToString());
			LevelID = int.Parse(parameters["LevelID"].ToString());
		}

		public void NavigateToQuestionPage()
		{
			var navParameters = new NavigationParameters();
			navParameters.Add("LevelID", LevelID);
			navParameters.Add("LessonID", LessonID);
			_navigationService.ClearPopupStackAsync();
			_navigationService.NavigateAsync(new Uri("NavigationPage/Question" + navParameters.ToString(), UriKind.Relative));
		}
	}
}

