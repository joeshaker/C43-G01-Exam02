using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamOOP.Classes;

namespace ExamOOP.Abstract
{
    internal abstract class Question
    {
        protected Question() { }
        public Question(string? head, string? body, double mark)
        {
            Head = head;
            Body = body;
            Mark = mark;
        }

        public string ? Head { get; set; }
        public string ? Body { get; set; }
        public double Mark { get; set; }

        public List<Answer> AnswerList { get; set; } = new List<Answer>();
        public Answer RightAnswer { get; set; }

        public abstract void DisplayQustion();

        public override string ToString()
        {
            return $"Head of Question: {Head} Body: {Body} and Mark= {Mark}";
        }
            
    }
}
