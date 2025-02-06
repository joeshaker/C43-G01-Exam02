using System.Diagnostics;
using ExamOOP.Classes;

namespace ExamOOP1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(10, "C#");
            subject.CreateExam();
            Console.Clear();
            Console.WriteLine("Do you want to start Exam Y/N");
            if (char.Parse(Console.ReadLine()) == 'Y')
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                subject.exam.ShowExam();
                Console.WriteLine($"The Elapsed Time: {sw.Elapsed}");
            }
        }
    }
}
