using System;
using _5letters.Services;
using Microsoft.AspNetCore.Mvc;

namespace _5letters.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StatisticController: ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpPost]
        public async Task<IActionResult> GetStatistic(Guid userId)
        {
            return Ok( await _statisticService.TakeStatistic(userId));
        }
        
    }
}