using System;
using System.Threading.Tasks;
using _5letters.Models;

namespace _5letters.Services
{
    public interface IGameService
    {
        public Word ChekWord(string nowWord, string correctWord);
        public Game RunGame(Game nowGame, string nowWord);
        public void KeyboardStatusUpdate(Game nowGame);
        public Task<Game> TakeTodaysGame(Guid userId);
        public Task<Game> SaveGameChanges(Game nowGame);

        public Task<Game> CreateNewGame(Guid userId);


    }
}