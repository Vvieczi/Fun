using System;
using System.Collections.Generic;
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
            while(true){
            var questions = await _repo.GetAllQuestions();
            List<String> prizes = new List<string>();
            Console.Clear();
            foreach (var question in questions)
            {
                _DisplayText(question.QuestionText);
                question.Answers.ToList().ForEach(x=> _DisplayText($"{x.Key} - {x.Value}"));
                var answer = _ReadText();
                if (answer.Equals(question.CorrectAnswer))
                {
                    prizes.Add(question.PrizePart);
                    _DisplayText($"FRAGMENT ODPOWIEDZI: {question.PrizePart}");
                }else
                {
                    var randomAnswer = _RandomString(5);
                    prizes.Add(randomAnswer);
                    _DisplayText($"FRAGMENT ODPOWIEDZI: {randomAnswer}");
                }
            }
              Console.Clear();
              _DisplayText($"TWOJE ZAKLĘCIE TO: {String.Join(" ",prizes)}");
              Console.ReadKey();
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

        private static Random _random = new Random();

        public static string _RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}