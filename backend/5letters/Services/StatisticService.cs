using System;
using System.Linq;
using _5letters.Data;
using _5letters.Dtos;
using _5letters.Models;
using Microsoft.EntityFrameworkCore;

namespace _5letters.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly AppDbContext _context;

        public StatisticService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateStatisticResponse> TakeStatistic(Guid userId)
        {
            var victoriesNumber = await _context.Games
                    .Where(g => g.UserId == userId)
                    .CountAsync(g => g.GameStage == GameStages.Victory);
            var defeatsNumber = await _context.Games
                    .Where(g => g.UserId == userId)
                    .CountAsync(g => g.GameStage == GameStages.Defeat);
            var averageAttemptsNumber = await _context.Games
                    .Where(g => g.GameStage == GameStages.Victory && g.UserId == userId)
                    .Select(g => g.Words.Count).AverageAsync(); 
            var result = new CreateStatisticResponse()
            {
                VictoriesNumber = victoriesNumber,
                DefeatsNumber = defeatsNumber,
                AverageAttemptsNumber = (int)Math.Round( averageAttemptsNumber)
            };
            return result;
        }
    }
}