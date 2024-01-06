using System.Threading.Tasks;
using _5letters.Dtos;
using _5letters.Models;

namespace _5letters.Services
{
    public interface ICorrectWordService
    {
        public Task<CorrectWord> AddCorrectWord(CreateCorrectWordRequest word);
        public Task<CorrectWord> GetCorrectWord();

    }
}