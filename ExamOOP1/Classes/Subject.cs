using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamOOP.Abstract;

namespace ExamOOP.Classes
{
    internal class Subject
    {
        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam exam { get; set; }

        public void CreateExam()
        {
            Console.WriteLine("Which type of exam do you want? (1-PracticalExam   OR    2-FinalExam)");
            char examType = char.Parse(Console.ReadLine() ?? "0");

            if (examType == '1')
            {
                exam = new PracticalExam();
            }
            else
            {
                exam = new FinalExam();
            }

            Console.WriteLine($"Creating {exam.GetType().Name}...");

            Console.Write("Enter Time of Exam in Minutes: ");
            exam.Time = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter Number of Questions: ");
            exam.NumOfQuestions = int.Parse(Console.ReadLine() ?? "0");

            if (exam is FinalExam)
            {
                for (int i = 0; i < exam.NumOfQuestions; i++)
                {
                    Console.WriteLine("Which type of Question do you want? 1-MCQ 2-True/False");
                    char questionType = char.Parse(Console.ReadLine() ?? "0");

                    Question question;
                    if (questionType == '1')
                    {
                        question = new McqQuestions();
                        question.Head = "Multiple Choices";
                    }
                    else
                    {
                        question = new TrueOrFalseQuestions();
                        question.Head = "True or False";
                    }

                    Console.WriteLine("Enter the body of the question:");
                    question.Body = Console.ReadLine();

                    Console.WriteLine("Enter the mark of the question:");
                    question.Mark = int.Parse(Console.ReadLine() ?? "0");

                    if (question is McqQuestions mcqQuestion)
                    {
                        Console.WriteLine("Enter the number of choices:");
                        int numChoices = int.Parse(Console.ReadLine() ?? "0");

                        for (int j = 0; j < numChoices; j++)
                        {
                            Console.WriteLine($"Enter choice {j + 1}:");
                            string choiceText = Console.ReadLine();
                            mcqQuestion.AnswerList.Add(new Answer { AnswerId = j + 1, AnswerText = choiceText });
                        }

                        Console.WriteLine("Enter the ID of the correct answer:");
                        int correctAnswerId = int.Parse(Console.ReadLine() ?? "0");
                        mcqQuestion.RightAnswer = mcqQuestion.AnswerList.FirstOrDefault(a => a.AnswerId == correctAnswerId);
                    }
                    else if (question is TrueOrFalseQuestions tfQuestion)
                    {
                        Console.WriteLine("Enter the correct answer (1-True, 2-False):");
                        int correctAnswerId = int.Parse(Console.ReadLine() ?? "0");

                        if (correctAnswerId == 1)
                        {
                            tfQuestion.RightAnswer = new Answer { AnswerId = 1, AnswerText = "True" };
                        }
                        else
                        {
                            tfQuestion.RightAnswer = new Answer { AnswerId = 2, AnswerText = "False" };
                        }
                    }

                    exam.Questions.Add(question);
                }
            }
            else if (exam is PracticalExam)
            {
                for (int i = 0; i < exam.NumOfQuestions; i++)
                {
                    Question question = new McqQuestions();
                    question.Head = "Multiple Choices";

                    Console.WriteLine("Enter the body of the question:");
                    question.Body = Console.ReadLine();

                    Console.WriteLine("Enter the mark of the question:");
                    question.Mark = int.Parse(Console.ReadLine() ?? "0");

                    Console.WriteLine("Enter the number of choices:");
                    int numChoices = int.Parse(Console.ReadLine() ?? "0");

                    for (int j = 0; j < numChoices; j++)
                    {
                        Console.WriteLine($"Enter choice {j + 1}:");
                        string choiceText = Console.ReadLine();
                        question.AnswerList.Add(new Answer { AnswerId = j + 1, AnswerText = choiceText });
                    }

                    Console.WriteLine("Enter the ID of the correct answer:");
                    int correctAnswerId = int.Parse(Console.ReadLine() ?? "0");
                    question.RightAnswer = question.AnswerList.FirstOrDefault(a => a.AnswerId == correctAnswerId);

                    exam.Questions.Add(question);
                }
            }

            Console.WriteLine($"{exam.GetType().Name} is created successfully!");
        }

        public override string ToString()
        {
            return $"SubjectID: {SubjectId}, SubjectName: {SubjectName}";
        }

    }
}
