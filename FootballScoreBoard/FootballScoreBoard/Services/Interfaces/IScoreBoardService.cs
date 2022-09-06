using FootballScoreBoard.Domain.Entities;

namespace FootballScoreBoard.Services.Interfaces
{
    public interface IScoreBoardService
    {
        Task<FootballMatch> StartGame(string homeTeam, string awayTeam);
        Task<FootballMatch> FinishGame(string matchId);
        Task<FootballMatch> UpdateScore(string matchId, int homeScore, int awayScore);
        Task<string> GetSummary();
    }
}
