using FootballScoreBoard.Domain.Entities;
using FootballScoreBoard.Infraescturture.Interfaces;

[assembly: System.Runtime.CompilerServices.InternalsVisibleToAttribute("FootballScoreBoard.Tests")]
namespace FootballScoreBoard.Infraescturture
{
    internal class FootballBoardInMemoryRepository : IFootballBoardRepository
    {
        private IDictionary<string, FootballMatch> _activeMatches;
        public FootballBoardInMemoryRepository()
        {
            _activeMatches = new Dictionary<string, FootballMatch>();
        }
        public Task<FootballMatch> Add(FootballMatch match)
        {
            throw new NotImplementedException();
        }

        public Task<FootballMatch> Remove(string matchId)
        {
            throw new NotImplementedException();
        }

        public Task<FootballMatch> Update(string matchId, int homeScore, int awayScore)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<FootballMatch>> GetAll()
        {
            return Task.FromResult(_activeMatches.Values);
        }

        public void Dispose()
        {
            _activeMatches = new Dictionary<string, FootballMatch>();
        }
    }
}
