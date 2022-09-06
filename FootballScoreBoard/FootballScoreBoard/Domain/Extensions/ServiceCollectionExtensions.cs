using FootballScoreBoard.Services;
using FootballScoreBoard.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FootballScoreBoard.Domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static ServiceCollection AddFootballScoreBoard(this ServiceCollection services)
        {
            services.AddSingleton<IScoreBoardService, ScoreBoardService>();
            return services;
        }
    }
}
