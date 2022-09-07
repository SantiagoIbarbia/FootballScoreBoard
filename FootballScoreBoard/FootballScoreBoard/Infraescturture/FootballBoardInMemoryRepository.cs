using Castle.Core.Internal;
using FootballScoreBoard.Domain.Entities;
using FootballScoreBoard.Infraescturture.Interfaces;
using System.Runtime.CompilerServices;

[assembly: System.Runtime.CompilerServices.InternalsVisibleToAttribute("FootballScoreBoard.Tests")]
[assembly: InternalsVisibleTo(InternalsVisible.ToDynamicProxyGenAssembly2)]
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
            FootballMatch added;
            if (_activeMatches.ContainsKey(match?.MatchId))
            {
                added = _activeMatches[match.MatchId];
            }
            else
            {
                _activeMatches.Add(match.MatchId, match);
                added = match;
            }
            return Task.FromResult(added);
        }

        public Task<FootballMatch> Remove(string matchId)
        {
            if (_activeMatches.TryGetValue(matchId, out FootballMatch removed))
            {
                _activeMatches.Remove(matchId);
            }

            return Task.FromResult(removed);
        }

        public Task<FootballMatch> Update(string matchId, int homeScore, int awayScore)
        {
            if (_activeMatches.TryGetValue(matchId, out FootballMatch match))
            {
                match.HomeTeam.Score = homeScore;
                match.AwayTeam.Score = awayScore;
            }

            return Task.FromResult(match);
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
