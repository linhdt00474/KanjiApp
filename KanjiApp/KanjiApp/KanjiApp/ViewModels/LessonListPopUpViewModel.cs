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

namespace KanjiApp.ViewModels
{
	public class LessonListPopUpViewModel : BindableBase, INavigatedAware
	{
		private INavigationService _navigationService { get; set; }

		private int levelID;
		public int LevelID
		{
			get { return levelID; }
			set
			{
				SetProperty(ref levelID, value);
			}
		}

		private ObservableCollection<Lesson> _lessons;
		public ObservableCollection<Lesson> Lessons
		{
			get { return _lessons; }
			set
			{
				SetProperty(ref _lessons, value);
			}
		}
		public LessonListPopUpViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
		}

		public ICommand LessonClickCommand
		{
			get
			{
				return new Command(async (item) =>
				{
					string lessonID = ((Lesson)item).LessonID.ToString();
					var navParameters = new NavigationParameters();
					navParameters.Add("LessonID", lessonID);
					await _navigationService.ClearPopupStackAsync();
					await _navigationService.NavigateAsync(new Uri("/SideMenu/NavigationPage/LessonDetail" + navParameters.ToString(), UriKind.Absolute));
				});
			}
		}

		public void OnNavigatedFrom(INavigationParameters parameters)
		{

		}

		public void OnNavigatedTo(INavigationParameters parameters)
		{
			if (parameters != null && parameters.Count > 0)
			{
				LevelID = int.Parse(parameters["levelID"].ToString());
				UpdateData();
			}
		}

		public void UpdateData()
		{
			Lessons = new ObservableCollection<Lesson>();

			try
			{
				List<Lesson> lessonList = new LessonService().GetLessonListByLevelID(LevelID);
				foreach (var lesson in lessonList)
				{
					Lessons.Add(lesson);
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
