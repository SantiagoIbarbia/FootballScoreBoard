using FootballScoreBoard.Infraescturture;
using FootballScoreBoard.Infraescturture.Interfaces;
using FootballScoreBoard.Services;
using FootballScoreBoard.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace FootballScoreBoard.Domain.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static ServiceCollection AddFootballScoreBoard(this ServiceCollection services)
        {
            services.AddSingleton<IScoreBoardService, ScoreBoardService>();
            services.AddSingleton<IFootballBoardRepository, FootballBoardInMemoryRepository>();
            services.AddSingleton<ISummaryMessageService, SummaryMessageService>();

            return services;
        }
    }
}
