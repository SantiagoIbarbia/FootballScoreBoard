using FootballScoreBoard.Domain.Entities;
using FootballScoreBoard.Infraescturture.Interfaces;
using FootballScoreBoard.Services.Interfaces;
[assembly: System.Runtime.CompilerServices.InternalsVisibleToAttribute("FootballScoreBoard.Tests")]
namespace FootballScoreBoard.Services
{
    internal class ScoreBoardService : IScoreBoardService
    {
        private readonly IFootballBoardRepository _futBoardRepository;
        public ScoreBoardService(IFootballBoardRepository futBoardRepository)
        {
            _futBoardRepository = futBoardRepository;
        }
        public Task<FootballMatch> StartGame(string homeTeam, string awayTeam)
        {
            //_futBoardRepository.Add();
            throw new NotImplementedException();
        }
        public Task<FootballMatch> FinishGame(string matchId)
        {
            //_futBoardRepository.Remove();
            throw new NotImplementedException();
        }

        public Task<FootballMatch> UpdateScore(string matchId, int homeScore, int awayScore)
        {
            //_futBoardRepository.Update(matchId, homeScore, awayScore);
            throw new NotImplementedException();
        }
        public Task<string> GetSummary()
        {
            throw new NotImplementedException();
        }



    }
}
