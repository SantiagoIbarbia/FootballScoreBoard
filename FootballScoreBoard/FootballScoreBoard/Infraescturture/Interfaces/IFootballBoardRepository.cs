using FootballScoreBoard.Domain.Entities;
[assembly: System.Runtime.CompilerServices.InternalsVisibleToAttribute("FootballScoreBoard.Tests")]

namespace FootballScoreBoard.Infraescturture.Interfaces
{
    internal interface IFootballBoardRepository
    {
        Task<FootballMatch> Add(FootballMatch match);
        Task<FootballMatch> Remove(string matchId);
        Task<FootballMatch> Update(string matchId, int homeScore, int awayScore);
        Task<ICollection<FootballMatch>?> GetAll();
    }
}
