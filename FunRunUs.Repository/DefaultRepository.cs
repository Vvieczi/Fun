using System.Collections.Generic;
using System.IO;
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
            using StreamReader reader = new(_jsonPath);
            string json = reader.ReadToEnd();
            List<Question> items = JsonConvert.DeserializeObject<List<Question>>(json);
            return Task.FromResult(items);
        }
    }
}