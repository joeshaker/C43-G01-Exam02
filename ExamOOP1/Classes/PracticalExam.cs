using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamOOP.Abstract;

namespace ExamOOP.Classes
{
    internal class PracticalExam : Exam
    {
        public PracticalExam() { }
        public PracticalExam(int time, int numOfQuestions) : base(time, numOfQuestions)
        {
        }

        public new void ShowExam()
        {
            Console.WriteLine("Review Practical Questions and Correct Answers: ");
            for (int i = 0; i < Questions.Count; i++)
            {
                var question = Questions[i];
                //question.ToString();
                if (question.RightAnswer != null)
                {
                    Console.WriteLine($"Correct Answers: Num{i + 1}:{question.RightAnswer.AnswerText}");
                }
                Console.WriteLine("=====================");
            }
        }
    }
}
