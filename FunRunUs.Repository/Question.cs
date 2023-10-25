using System.Collections.Generic;

namespace FunRunUs.Repository
{
    public class Question
    {
        public string QuestionText { get; set; }
        public Dictionary<char,string> Answers { get; set; }
        public char CorrectAnswer { get; set; }
        public string PrizePart { get; set; }
    }
}