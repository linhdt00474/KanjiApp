using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KanjiApp.Models
{
    public class QuestionKanji
    {
		[PrimaryKey,AutoIncrement]
		public int QuestionID { get; set; }

		public int LessonID { get; set; }

		public int LevelID { get; set; }

		public string Question { get; set; }

		public string CorrectAnswer { get; set; }
    }
}
