using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamOOP.Abstract;

namespace ExamOOP.Classes
{
    internal class FinalExam : Exam
    {
        public FinalExam() { }
        public FinalExam(int time, int numOfQuestions) : base(time, numOfQuestions)
        {
        }

        public new void ShowExam()
        {
            Console.WriteLine("Review Final Questions and Correct Answers: ");
            for (int i = 0; i < Questions.Count; i++)
            {
                var question = Questions[i];
                Console.WriteLine($"Question {i + 1}: {question.Body}");
                //question.ToString();
                if (question.RightAnswer != null)
                {
                    Console.WriteLine($"Correct Answer: {question.RightAnswer.AnswerText}");
                }
                Console.WriteLine("=====================");
            }


        }
    }
}
