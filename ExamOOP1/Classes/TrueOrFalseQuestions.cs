using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamOOP.Abstract;

namespace ExamOOP.Classes
{
    internal class TrueOrFalseQuestions : Question
    {
        public TrueOrFalseQuestions() { }
        public TrueOrFalseQuestions(string? head, string? body, double mark) : base(head, body, mark)
        {
        }

        public override void DisplayQustion()
        {
            Console.WriteLine($"Header: {Head},{Body} (True/False)");
        }
    }
}
