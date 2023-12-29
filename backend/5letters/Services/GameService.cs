using System.Collections.Generic;
using System.Linq;
using _5letters.Models;
using Microsoft.VisualBasic;

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
<<<<<<< HEAD

            nowGame.Words.Add(ChekWord(nowWorld, nowGame.CorrectWord.StringWord));
=======
            nowGame.Words.Add(ChekWord(nowWorld, nowGame.CorrectWord));
>>>>>>> 180907a1ebbeebd8de057eec01bc3cbc844e1e29
            
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

    }
}