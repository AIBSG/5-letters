using System;
using _5letters.Dtos;

namespace _5letters.Services
{
    public interface IStatisticService
    {
        public Task<CreateStatisticResponse> TakeStatistic(Guid userId);
    }
}