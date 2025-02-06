using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOP.Classes
{
    internal class Answer:IComparable<Answer>
    {
        public Answer() { }
        public Answer(int answerId, string? answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }

        public  int AnswerId { get; set; }
        public string ?AnswerText { get; set; }

        public int CompareTo(Answer? other)
        {
            if (other == null) return 1;
            return AnswerId.CompareTo(other.AnswerId);
        }
    }
}
