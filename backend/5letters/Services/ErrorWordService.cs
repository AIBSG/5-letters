using _5letters.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _5letters.Services
{
    public class ErrorWordService : IErrorWordService
    {
        public async Task<bool> IsExistWord(string nowWord)
        {
            string[] words =  await File.ReadAllLinesAsync(Directory.GetCurrentDirectory()+ @"\WordsFile\Words.txt");
            return  words.Contains(nowWord);
        }
    }
}