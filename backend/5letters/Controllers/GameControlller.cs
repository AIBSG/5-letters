using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;
using _5letters.Models;
using _5letters.Services;

namespace _5letters.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        private readonly IErrorWordService _errorWordService;
        
        public GameController(IGameService gameService, IErrorWordService errorWordService)
        {
            _gameService = gameService;
            _errorWordService = errorWordService;
        }
        
        [HttpPost]
        public async Task <IActionResult> GetGame(Guid userId)
        {
            var nowGame = await _gameService.TakeTodaysGame(userId);
            return Ok(nowGame);
        }
        
        [HttpPost]
        public async Task<IActionResult> SendWord(Guid userId, string nowWord)
        {
            var isWordExist = await _errorWordService.IsExistWord(nowWord);
            if (!isWordExist)
                return Ok("не знаю такого слова");
            var nowGame = await _gameService.TakeTodaysGame(userId);
            nowGame = _gameService.RunGame(nowGame, nowWord);
            await _gameService.SaveGameChanges(nowGame);
            return Ok(nowGame);
        }
    }
}