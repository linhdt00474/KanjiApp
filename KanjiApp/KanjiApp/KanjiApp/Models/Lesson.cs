using System;
using System.Collections.Generic;
using System.Text;

namespace KanjiApp.Models
{
	public class Lesson
	{
		public int LevelID { get; set; }
		public int LessonID { get; set; }
		public string LessonName { get; set; }
		public string IsLearning { get; set; }
	}
}
