using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _5letters.Data;
using _5letters.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace _5letters.Services
{
    public class GameService : IGameService
    {
        private readonly AppDbContext _context;

        public GameService(AppDbContext context)
        {
            _context = context;
        }
        public Word ChekWord(string nowWord, string correctWord)
        {
            Word result = new Word(nowWord);
            for (int i = 0; i < 5; i++)
            {
                var nowLetter = nowWord[i];
                if (correctWord[i] == nowLetter)
                {
                    result.Letters.Add(new Letter(){WordLetter = nowLetter, LetterStatus = LetterStatus.RightPlace});
                }
                else if (correctWord.Contains(nowLetter))
                {
                    result.Letters.Add(new Letter(){WordLetter = nowLetter, LetterStatus = LetterStatus.InWord});
                }
                else
                {
                    result.Letters.Add(new Letter(){WordLetter = nowLetter, LetterStatus = LetterStatus.WrongLetter});
                }
            }

            if (result.Letters.All(x => x.LetterStatus == LetterStatus.RightPlace))
            {
                result.Status = WordStatus.CorrectWord;
            }
            else
            {
                result.Status = WordStatus.NotCorrectWord;
            }

            return result;
        }

        public Game RunGame(Game nowGame, string nowWorld)
        {

            nowGame.Words.Add(ChekWord(nowWorld, nowGame.CorrectWord.StringWord));

            
            if (nowGame.Words.Last().Status == WordStatus.CorrectWord)
            {
                nowGame.GameStage = GameStages.Victory;

            }
            
            else if (nowGame.Words.Count == 5)
            {
                nowGame.GameStage = GameStages.Defeat;
            }
            
            KeyboardStatusUpdate(nowGame);
            return nowGame;
        }

        public void KeyboardStatusUpdate(Game nowGame)
        {
            foreach (var letter in nowGame.Words.Last().Letters)
            {
                var flag = false;
                for (int i = 0; i < nowGame.KeyboardStatus.Count; i++)
                {

                    if (nowGame.KeyboardStatus[i].WordLetter.Equals(letter.WordLetter))
                    {
                        flag = true;
                        
                        if (nowGame.KeyboardStatus[i].LetterStatus == LetterStatus.InWord
                            && letter.LetterStatus == LetterStatus.RightPlace)
                        {
                            nowGame.KeyboardStatus[i] = letter;
                            break;
                        }
                    }
                }

                if (flag == false)
                {
                    nowGame.KeyboardStatus.Add(letter);
                }
                
            }
        }

        public async Task<Game> SaveGameChanges(Game nowGame)
        {
            var lastGame =await _context.Games.FirstOrDefaultAsync(g => g.UserId == nowGame.UserId &&
                                                              g.Date.Year == nowGame.Date.Year &&
                                                              g.Date.Month == nowGame.Date.Month &&
                                                              g.Date.Day == nowGame.Date.Day);
            if (lastGame == null)
            {
                 _context.Set<Game>().Add(nowGame);
            }
            else
            {
                lastGame.Words = nowGame.Words;
                lastGame.GameStage = nowGame.GameStage;
                lastGame.KeyboardStatus = nowGame.KeyboardStatus;
            }
            await _context.SaveChangesAsync();
            return lastGame;
        }
        public async Task<Game> TakeTodaysGame(Guid userId)
        {
            DateTime currentTime = DateTime.Now.Date;


            var game = await _context.Games
                .Include(g=>g.CorrectWord)
                .Include(g=>g.KeyboardStatus)
                .Include(g =>g.Words)
                .ThenInclude(w => w.Letters)
                .FirstOrDefaultAsync(g => g.UserId == userId &&
                                          g.Date.Year == currentTime.Year &&
                                          g.Date.Month == currentTime.Month &&
                                          g.Date.Day == currentTime.Day);
            if (game == null) return CreateNewGame(userId).Result;
            

            return game;
        }

        public async Task<Game> CreateNewGame(Guid userId)
        {
            var date = DateTimeOffset.Now;
            var words = await _context.Set<CorrectWord>().ToListAsync();
            var correctWord = words.FirstOrDefault(g =>
                                          g.Date.Year == date.Year &&
                                          g.Date.Month == date.Month &&
                                          g.Date.Day == date.Day);
            var newGame = new Game()
            {
                CorrectWord = correctWord,
                Date = date,
                GameStage = GameStages.GameInProgress,
                KeyboardStatus = new List<Letter>(),
                UserId = userId
            };
           await _context.Set<Game>().AddAsync(newGame);
           await _context.SaveChangesAsync();
            return newGame;
        }
    }
}