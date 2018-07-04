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
	public class KanjiListViewModel : BindableBase
	{
		INavigationService _navigationService;

		private int _lessonID;
		public int LessonID
		{
			get { return _lessonID; }
			set
			{
				SetProperty(ref _lessonID, value);
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

		public KanjiListViewModel(INavigationService navigationService)
        {
			_navigationService = navigationService;
			List<Word> wordList = new WordService().GetWordList();
			ObservableCollection<Word> wordCollection = new ObservableCollection<Word>();

			foreach (Word word in wordList)
			{
				word.BackgroundColor = "#5389d6";
				word.BorderColor = "#64aeff";
				wordCollection.Add(word);
			}

			Words = wordCollection;
			CurrentMeaning = "- Nghĩa: " + Words.ElementAt(0).Mean;
			CurrentKunyomi = "- Kunyomi: " + Words.ElementAt(0).Onyomi;
			CurrentOnyomi = "- Onyomi: " + Words.ElementAt(0).Kunyomi;
			CurrentExample = Words.ElementAt(0).Example;
			CurrentKanji = Words.ElementAt(0).Kanji;
			Words.ElementAt(0).BackgroundColor = "#ff8410";
			Words.ElementAt(0).BorderColor = "#ffb479";
		}

		public ICommand WordClickCommand
		{
			get
			{
				return new Command(async (item) =>
				{
					CurrentMeaning = "- Nghĩa: " + ((Word)item).Mean;
					CurrentKunyomi = "- Kunyomi: " + ((Word)item).Kunyomi;
					CurrentOnyomi = "- Onyomi: " + ((Word)item).Onyomi;
					CurrentExample = ((Word)item).Example;
					CurrentKanji = ((Word)item).Kanji;
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
	}
}
