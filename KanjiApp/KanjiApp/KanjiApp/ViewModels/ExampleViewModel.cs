using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KanjiApp.ViewModels
{
	public class ExampleViewModel : BindableBase, INavigatedAware
	{
		INavigationService _navigationService;
		private string _example;
		public string Example
		{
			get { return _example; }
			set
			{
				SetProperty(ref _example, value);
			}
		}

		public ExampleViewModel()
        {
        }

		public void OnNavigatedFrom(INavigationParameters parameters)
		{
		}

		public void OnNavigatedTo(INavigationParameters parameters)
		{
			Example = parameters["Example"].ToString();
		}
	}
}
