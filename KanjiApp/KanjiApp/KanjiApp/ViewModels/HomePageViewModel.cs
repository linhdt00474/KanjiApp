using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using KanjiApp.Models;
using KanjiApp.Services;
using System.Windows.Input;
using Xamarin.Forms;
using KanjiApp.Views;
using System.ComponentModel;
using System.Threading.Tasks;
using Prism.Navigation;
using KanjiApp.Interfaces;

namespace KanjiApp.ViewModels
{
	public class HomePageViewModel : BindableBase,INavigatedAware
	{
		private INavigationService _navigationService { get; set; }
		//private LessonService _lessonService;

		private ObservableCollection<Lesson> lessons;
		public ObservableCollection<Lesson> Lessons
		{
			get { return lessons; }
			set
			{
				SetProperty(ref lessons, value);
			}
		}

		private int levelID;

		public int LevelID
		{
			get { return levelID; }
			set
			{
				SetProperty(ref levelID, value);
			}
		}

		private string levelName;

		public string LevelName
		{
			get { return levelName; }
			set
			{
				SetProperty(ref levelName, value);
			}
		}
		public HomePageViewModel(INavigationService navigationService)
        {
			_navigationService = navigationService;

			if (Lessons == null || Lessons.Count == 0)
			{
				Lessons = new ObservableCollection<Lesson>();
				try
				{
					List<Lesson> lessonList = new LessonService().GetLessonListByLevelID(5);
					foreach (var lesson in lessonList)
					{
						Lessons.Add(lesson);
					}
					LevelName = new LevelService().GetLevelNameByLevelID(5);
				}
				catch (Exception)
				{
					throw;
				}
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
				LevelName = new LevelService().GetLevelNameByLevelID(LevelID);
			}
			catch (Exception)
			{
				throw;
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

		public ICommand LessonClickCommand
		{
			get
			{
				return new Command((item) =>
				{
					string lessonID = ((Lesson)item).LessonID.ToString();
					var navParameters = new NavigationParameters();
					navParameters.Add("LessonID", lessonID);
					_navigationService.NavigateAsync(new Uri("/SideMenu/NavigationPage/LessonDetail" + navParameters.ToString(), UriKind.Absolute));
				});
			}
		}
	}
}
