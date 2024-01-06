using System.Threading.Tasks;

namespace _5letters.Services
{
    public interface IErrorWordService
    {
        public Task<bool> IsExistWord(string nowWord);
    }
}