using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunRunUs.Repository;


namespace FunRunUs.Spell
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
            while (true)
            {
                Console.Clear();
                _DisplayText("PODAJ ZAKLĘCIE");
                var answer = _ReadText();
                var correctAnswer = await _repo.GetCompleteAnswer();
                if (correctAnswer.ToUpper().Equals(answer.ToUpper()))
                {
                    _DisplayText("Prawidłowe Zaklęcie".ToUpper());
                }
                else
                {
                    _DisplayText("Złe Zaklęcie".ToUpper());
                }
                Console.ReadKey();
            }
        }

        private static void _DisplayText(string text)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }

        private static string _ReadText()
        {
            Console.CursorLeft = Console.WindowWidth / 2;
            return Console.ReadLine().ToString().ToUpper();
        }
    }
}