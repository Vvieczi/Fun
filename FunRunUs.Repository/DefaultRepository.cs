using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FunRunUs.Repository
{
    internal class DefaultRepository : IRepository
    {
        private readonly string _jsonPath = "../questions/questions.json";
        public Task<List<Question>> GetAllQuestions()
        {
            return Task.FromResult(_GetAllQuestion());
        }

        public Task<String> GetCompleteAnswer()
        {
            var questions = _GetAllQuestion();
            var completeSpell = questions.Select(x=>x.PrizePart).ToList();
            return Task.FromResult(String.Join(" ",completeSpell));
        }

        private List<Question> _GetAllQuestion()
        {
            using StreamReader reader = new(_jsonPath);
            string json = reader.ReadToEnd();
            List<Question> items = JsonConvert.DeserializeObject<List<Question>>(json);
            return items;
        }
    }
}