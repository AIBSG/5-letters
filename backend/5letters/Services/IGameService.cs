using _5letters.Models;

namespace _5letters.Services
{
    public interface IGameService
    {
        public Word ChekWord(string nowWord, string correctWord);
        public Game RunGame(Game nowGame, string nowWord);
    }
}