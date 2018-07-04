using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace KanjiApp.Models
{
    public class Answer: INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public string AnswerText { get; set; }
		public bool IsCorrect { get; set; }
		private string backgroundColor;
		public string BackgroundColor
		{
			get { return backgroundColor; }
			set
			{
				backgroundColor = value;
				OnPropertyChanged("BackgroundColor");
			}
		}
		private string borderColor;
		public string BorderColor
		{
			get { return borderColor; }
			set
			{
				borderColor = value;
				OnPropertyChanged("BorderColor");
			}
		}
		// Create the OnPropertyChanged method to raise the event
		protected void OnPropertyChanged(string name)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(name));
			}
		}
	}
}
