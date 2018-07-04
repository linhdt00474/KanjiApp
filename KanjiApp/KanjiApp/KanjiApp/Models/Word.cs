using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace KanjiApp.Models
{
	public class Word: INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public int LevelID { get; set; }
		public int WordID { get; set; }
		public string Kanji { get; set; }
		public string LessonID { get; set; }
		public string Kunyomi { get; set; }
		public string Onyomi { get; set; }
		public string Mean { get; set; }
		public string Example { get; set; }

		private string _backgroundColor;
		public string BackgroundColor
		{
			get { return _backgroundColor; }
			set
			{
				_backgroundColor = value;
				OnPropertyChanged("BackgroundColor");
			}
		}

		private string _borderColor;
		public string BorderColor
		{
			get { return _borderColor; }
			set
			{
				_borderColor = value;
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
