using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamOOP.Classes;

namespace ExamOOP.Abstract
{
    internal abstract class Exam
    {
        protected Exam() { }
        public Exam(int time, int numOfQuestions)
        {
            Time = time;
            NumOfQuestions = numOfQuestions;
        }

        public  int Time { get; set; }
        public  int NumOfQuestions { get; set; }

        public List<Question> Questions { get; set; } = new List<Question>();

        //public  Subject Subject { get; set; }

        public virtual void ShowExam()
        {
            if (Questions == null || Questions.Count == 0)
            {
                Console.WriteLine("No questions available for this exam.");
                return;
            }

            Console.WriteLine("Starting Exam...");
            Console.WriteLine($"Exam Time: {Time} minutes");
            Console.WriteLine($"Number of Questions: {NumOfQuestions}");
            Console.WriteLine("=====================");

            double totalMarks = 0;
            double userMarks = 0;

            for (int i = 0; i < Questions.Count; i++)
            {
                var question = Questions[i];
                if (question is McqQuestions mcqQuestion)
                {
                    Console.WriteLine("Choose the correct answer:");
                    question.DisplayQustion();
                    Console.Write("Your answer (enter the number): ");
                    string ?userAnswer = Console.ReadLine();

                    if (int.TryParse(userAnswer, out int answerId) &&
                        answerId >= 1 && answerId <= mcqQuestion.AnswerList.Count)
                    {
                        if (mcqQuestion.AnswerList[answerId - 1].AnswerId.CompareTo(mcqQuestion.RightAnswer.AnswerId)==0)
                        {
                            Console.WriteLine("Correct!");
                            userMarks += question.Mark;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Marked as incorrect.");
                    }
                }
                else if (question is TrueOrFalseQuestions tfQuestion)
                {
                    //Console.Write("Your answer (True/False): ");
                    question.DisplayQustion();
                    string? userAnswer = Console.ReadLine();

                    if (userAnswer.Equals(tfQuestion.RightAnswer.AnswerText, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Correct!");
                        userMarks += question.Mark;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect!");
                    }
                }

                totalMarks += question.Mark;
                Console.WriteLine("=====================");
            }

            Console.WriteLine("Exam Finished!");

            if (this is FinalExam)
            {
                FinalExam finalExam = (FinalExam)this;
                //Console.WriteLine("Review Questions and Correct Answers: ");
                //for (int i = 0; i < Questions.Count; i++)
                //{
                //    var question = Questions[i];
                //    Console.WriteLine($"Question {i + 1}: {question.Body}");
                //    if (question.RightAnswer != null)
                //    {
                //        Console.WriteLine($"Correct Answer: {question.RightAnswer.AnswerText}");
                //    }
                //    Console.WriteLine("=====================");
                //}
                finalExam.ShowExam();
                Console.WriteLine($"Your Score: {userMarks} out of {totalMarks}");

            }
            else if (this is PracticalExam)
            {
                PracticalExam practicalExam = (PracticalExam)this;
                practicalExam.ShowExam();
                //Console.WriteLine("Review Questions and Correct Answers: ");
                //for (int i = 0; i < Questions.Count; i++)
                //{
                //    var question = Questions[i];
                //    if (question.RightAnswer != null)
                //    {
                //        Console.WriteLine($"Correct Answers: Num{i+1}:{question.RightAnswer.AnswerText}");
                //    }
                //    Console.WriteLine("=====================");
                //}
            }
            //Console.WriteLine("\nReview Questions and Correct Answers:");
            //for (int i = 0; i < Questions.Count; i++)
            //{
            //    var question = Questions[i];
            //    Console.WriteLine($"Question {i + 1}: {question.Body}");
            //    Console.WriteLine($"Correct Answer: {question.RightAnswer.AnswerText}");
            //    Console.WriteLine("=====================");
            //}
            //Console.WriteLine($"Your Score: {userMarks} out of {totalMarks}");
        }

    }
}
