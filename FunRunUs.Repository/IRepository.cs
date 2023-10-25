using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace FunRunUs.Repository
{
    public interface IRepository
    {
        public Task<List<Question>> GetAllQuestions();
    }
}
