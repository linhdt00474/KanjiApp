using System;
using System.Collections.Generic;
using System.Text;

namespace KanjiApp.Models
{
    public class AnsweredQuestion:QuestionKanji
    {
		public string UserAnswer { get; set; }

		public bool IsCorrect { get; set; }
    }
}
