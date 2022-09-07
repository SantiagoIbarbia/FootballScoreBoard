using Castle.Core.Internal;
using FootballScoreBoard.Domain.Entities;
using System.Runtime.CompilerServices;

[assembly: System.Runtime.CompilerServices.InternalsVisibleToAttribute("FootballScoreBoard.Tests")]
[assembly: InternalsVisibleTo(InternalsVisible.ToDynamicProxyGenAssembly2)]
namespace FootballScoreBoard.Infraescturture.Interfaces
{
    internal interface IFootballBoardRepository : IDisposable
    {
        Task<FootballMatch> Add(FootballMatch match);
        Task<FootballMatch> Remove(string matchId);
        Task<FootballMatch> Update(string matchId, int homeScore, int awayScore);
        Task<ICollection<FootballMatch>?> GetAll();
    }
}
