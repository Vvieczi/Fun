using System;
using System.Linq;
using System.Threading.Tasks;
using FunRunUs.Repository;


namespace FunRunUs.ConsoleApp
{

    public class App
    {
        private readonly IRepository _repo;

        public App(IRepository repo)
        {
            _repo = repo;
        }

        public async Task Run(string[] args)
        {
            var questions = await _repo.GetAllQuestions();
            foreach (var question in questions)
            {
                _DisplayText(question.QuestionText);
                question.Answers.ToList().ForEach(x=> _DisplayText($"{x.Key} - {x.Value}"));
                var answer = _ReadText();
                if (answer.Equals(question.CorrectAnswer))
                {
                    _DisplayText($"FRAGMENT ODPOWIEDZI: {question.PrizePart}");
                }
            }
        }

        private static void _DisplayText(string text)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }

        private static char _ReadText()
        {
            Console.CursorLeft = Console.WindowWidth / 2;
            var answer = Console.ReadLine().ToString().ToUpper();
            var converterAnswer = Convert.ToChar(answer);
            return converterAnswer;
        }
    }
}