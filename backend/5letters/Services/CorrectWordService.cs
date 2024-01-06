using System;
using System.Linq;
using System.Threading.Tasks;
using _5letters.Data;
using _5letters.Dtos;
using _5letters.Models;
using Microsoft.EntityFrameworkCore;

namespace _5letters.Services
{
    public class CorrectWordService : ICorrectWordService
    {
        private readonly AppDbContext _context;

        public CorrectWordService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CorrectWord> AddCorrectWord (CreateCorrectWordRequest request)
        {
            var word = new CorrectWord()
            {
                StringWord = request.Word,
                Date = DateTimeOffset.Now
                
            };

            var wordEntry = await _context.Set<CorrectWord>().AddAsync(word);
            await _context.SaveChangesAsync();
            return wordEntry.Entity;
        }

        public  async Task<CorrectWord> GetCorrectWord()
        {
            var date = DateTimeOffset.UtcNow;
            var words = await _context.Set<CorrectWord>().ToListAsync();
            var correctWord = words.FirstOrDefault(w=>w.Date.Date == date.Date);
        
            return correctWord;
        }
    }

}