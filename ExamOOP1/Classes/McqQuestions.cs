using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamOOP.Abstract;

namespace ExamOOP.Classes
{
    internal class McqQuestions : Question
    {
        public McqQuestions() { }
        public McqQuestions(string? head, string? body, double mark) : base(head, body, mark)
        {
        }

        public override void DisplayQustion()
        {
            Console.WriteLine($"{Head}:{Body}");
            for (int i = 0; i < AnswerList.Count; i++) {
                Console.WriteLine($"{i + 1}. {AnswerList[i].AnswerText}");
            }

        }
    }
}
