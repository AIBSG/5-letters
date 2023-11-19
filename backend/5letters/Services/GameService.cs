using System.Linq;
using _5letters.Models;

namespace _5letters.Services
{
    public class GameService : IGameService
    {
        public Word ChekWord(string nowWord, string correctWord)
        {
            Word result = new Word(nowWord);
            for (int i = 0; i < 5; i++)
            {
                var nowLetter = nowWord[i];
                if (correctWord[i] == nowLetter)
                {
                    result.Letters.Add(new Letter(nowLetter, LetterStatus.RightPlace));
                }
                else if (correctWord.Contains(nowLetter))
                {
                    result.Letters.Add(new Letter(nowLetter, LetterStatus.InWord));
                }
                else
                {
                    result.Letters.Add(new Letter(nowLetter, LetterStatus.WrongLetter));
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
            nowGame.Words.Add(ChekWord(nowWorld, nowGame.CorrectWord));
            if (nowGame.Words.Last().Status == WordStatus.CorrectWord)
            {
                nowGame.GameStage = GameStages.Victory;

            }
            else if (nowGame.Words.Count == 5)
            {
                nowGame.GameStage = GameStages.Defeat;
            }

            return nowGame;
        }

    }
}