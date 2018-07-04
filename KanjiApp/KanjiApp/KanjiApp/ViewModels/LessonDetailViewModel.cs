using KanjiApp.Models;
using KanjiApp.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace KanjiApp.ViewModels
{
	public class LessonDetailViewModel : BindableBase, INavigatedAware
	{
		INavigationService _navigationService;

		public DelegateCommand ChooseTestTypeCommand { get; set; }

		public DelegateCommand OpenExampleCommand { get; set; }

		public DelegateCommand ChangeLessonCommand { get; set; }

		private string _title;
		public string Title
		{
			get { return _title; }
			set
			{
				SetProperty(ref _title, value);
			}
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

		private ObservableCollection<Word> _words;
		public ObservableCollection<Word> Words
		{
			get { return _words; }
			set
			{
				SetProperty(ref _words, value);
			}
		}

		private Word _selectedWord;

		public Word SelectedWord
		{
			get { return _selectedWord; }
			set
			{
				SetProperty(ref _selectedWord, value);
			}
		}

		private string _currentLevel;

		public string CurrentLevel
		{
			get { return _currentLevel; }
			set
			{
				SetProperty(ref _currentLevel, value);
			}
		}

		private string _currentLessonName;

		public string CurrentLessonName
		{
			get { return _currentLessonName; }
			set
			{
				SetProperty(ref _currentLessonName, value);
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

		private string _currentMeaning;

		public string CurrentMeaning
		{
			get { return _currentMeaning; }
			set
			{
				SetProperty(ref _currentMeaning, value);
			}
		}

		private string _currentKunyomi;

		public string CurrentKunyomi
		{
			get { return _currentKunyomi; }
			set
			{
				SetProperty(ref _currentKunyomi, value);
			}
		}

		private string _currentOnyomi;

		public string CurrentOnyomi
		{
			get { return _currentOnyomi; }
			set
			{
				SetProperty(ref _currentOnyomi, value);
			}
		}

		private string _currentExample;

		public string CurrentExample
		{
			get { return _currentExample; }
			set
			{
				SetProperty(ref _currentExample, value);
			}
		}

		public LessonDetailViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
			ChooseTestTypeCommand = new DelegateCommand(ChooseTestType);
			OpenExampleCommand = new DelegateCommand(OpenExample);
			ChangeLessonCommand = new DelegateCommand(ChangeLesson);
		}

		public void OnNavigatedFrom(INavigationParameters parameters)
		{

		}

		public void OnNavigatedTo(INavigationParameters parameters)
		{
			LessonID = int.Parse(parameters["LessonID"].ToString());
			LevelID = new LevelService().GetLevelIDByLessonID(LessonID);
			List<Word> wordList = new WordService().GetWordListByLessonID(LessonID, LevelID);
			ObservableCollection<Word> wordCollection = new ObservableCollection<Word>();

			foreach (Word word in wordList)
			{
				word.BackgroundColor = "#5389d6";
				word.BorderColor = "#64aeff";
				wordCollection.Add(word);
			}

			Words = wordCollection;
			CurrentLevel = "- Level: " + new LevelService().GetLevelNameByLevelID(LevelID);
			CurrentLessonName = "- Bài học: " + new LessonService().GetLessonNameByLessonID(LessonID);
			Title ="Cấp độ " + new LevelService().GetLevelNameByLevelID(LevelID) + " - "+ new LessonService().GetLessonNameByLessonID(LessonID);
			CurrentMeaning = Words.ElementAt(0).Mean;
			CurrentKunyomi = Words.ElementAt(0).Onyomi;
			CurrentOnyomi = Words.ElementAt(0).Kunyomi;
			CurrentExample = Words.ElementAt(0).Example;
			CurrentKanji = Words.ElementAt(0).Kanji;
			SelectedWord = Words.ElementAt(0);
			Words.ElementAt(0).BackgroundColor = "#ff8410";
			Words.ElementAt(0).BorderColor = "#ffb479";
		}

		public ICommand WordClickCommand
		{
			get
			{
				return new Command(async (item) =>
				{
					CurrentMeaning = ((Word)item).Mean;
					CurrentKunyomi = ((Word)item).Onyomi;
					CurrentOnyomi = ((Word)item).Kunyomi;
					CurrentExample = ((Word)item).Example;
					CurrentKanji = ((Word)item).Kanji;
					SelectedWord = (Word)item;
					foreach (Word word in Words)
					{
						word.BackgroundColor = "#5389d6";
						word.BorderColor = "#64aeff";
					}
					((Word)item).BackgroundColor = "#ff8410";
					((Word)item).BorderColor = "#ffb479";
					await Task.Delay(500);
				});
			}
		}

		private async void ChooseTestType()
		{
			var navParameters = new NavigationParameters();
			navParameters.Add("LevelID", LevelID);
			navParameters.Add("LessonID", LessonID);
			await _navigationService.NavigateAsync("Check", navParameters);
		}

		private async void OpenExample()
		{
			var navParameters = new NavigationParameters();
			navParameters.Add("Example", CurrentExample);
			//await _navigationService.NavigateAsync(new Uri("Example" + navParameters.ToString(), UriKind.Relative));
			await _navigationService.NavigateAsync("Example",navParameters);
		}

		private async void ChangeLesson()
		{
			var navParameters = new NavigationParameters();
			navParameters.Add("levelID", LevelID);
			await _navigationService.NavigateAsync("LessonListPopUp", navParameters);
		}
	}
}
