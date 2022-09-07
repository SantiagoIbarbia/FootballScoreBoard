using Castle.Core.Internal;
using FootballScoreBoard.Domain.Entities;
using FootballScoreBoard.Domain.Exceptions;
using FootballScoreBoard.Infraescturture.Interfaces;
using FootballScoreBoard.Services.Interfaces;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

[assembly: System.Runtime.CompilerServices.InternalsVisibleToAttribute("FootballScoreBoard.Tests")]
[assembly: InternalsVisibleTo(InternalsVisible.ToDynamicProxyGenAssembly2)]
namespace FootballScoreBoard.Services
{
    internal class ScoreBoardService : IScoreBoardService
    {
        private readonly IFootballBoardRepository _futBoardRepository;
        private readonly ISummaryMessageService _messageService;
        public ScoreBoardService(IFootballBoardRepository futBoardRepository,
                                 ISummaryMessageService messageService)
        {
            _futBoardRepository = futBoardRepository;
            _messageService = messageService;
        }
        public Task<FootballMatch> StartGame(string homeTeam, string awayTeam)
        {
            if (homeTeam.ToLower() == awayTeam.ToLower())
                throw new SameTeamException();

            FootballMatch match = new FootballMatch()
            {
                MatchId = Guid.NewGuid().ToString(),
                CreationTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                HomeTeam = new Team(homeTeam),
                AwayTeam = new Team(awayTeam)
            };

            return _futBoardRepository.Add(match);
        }
        public async Task<FootballMatch> FinishGame(string matchId)
        {

            FootballMatch match = await _futBoardRepository.Remove(matchId);
            if (match == null) throw new InvalidMatchException();

            return match;
        }

        public async Task<FootballMatch> UpdateScore(string matchId, int homeScore, int awayScore)
        {
            if (homeScore < 0 || awayScore < 0)
                throw new InvalidScoreException();

            FootballMatch match = await _futBoardRepository.Update(matchId, homeScore, awayScore);

            if (match == null)
                throw new InvalidMatchException();

            return match;
        }
        public async Task<string> GetSummary()
        {
            var matches = await _futBoardRepository.GetAll();

            return _messageService.GetSummary(matches.OrderByDescending(o => o.TotalScore).ThenByDescending(o => o.CreationTime));
        }
    }
}
