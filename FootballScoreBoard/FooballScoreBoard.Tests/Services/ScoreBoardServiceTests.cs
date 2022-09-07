using FootballScoreBoard.Services.Interfaces;
using FootballScoreBoard.Services;
using Moq;
using FootballScoreBoard.Infraescturture.Interfaces;
using FootballScoreBoard.Domain.Entities;
using FootballScoreBoard.Domain.Exceptions;
using FootballScoreBoard.Tests.Utilities;
using System.Text.RegularExpressions;

namespace FooballScoreBoard.Tests
{
    public class ScoreBoardServiceTests
    {
        private FootballMatch SINGLE_MATCH;
        private ICollection<FootballMatch> UNORDERED_MATCHES;
        [SetUp]
        public void Setup()
        {
            SINGLE_MATCH = MockFilesHelper.DeserializeFromMockFile<FootballMatch>("Files/match.json");
            UNORDERED_MATCHES = MockFilesHelper.DeserializeFromMockFile<ICollection<FootballMatch>>("Files/unorderedMatches.json");
        }

        [Test]
        public async Task StartGame_invalidMatch_OwnException()
        {
            Mock<IFootballBoardRepository> _repo = new Mock<IFootballBoardRepository>();
            _repo.Setup(o => o.Add(It.IsAny<FootballMatch>())).ThrowsAsync(new SameTeamException());
            IScoreBoardService inner = new ScoreBoardService(_repo.Object);

            Assert.ThrowsAsync<SameTeamException>(() => inner.StartGame("Boca", "Boca"));
        }

        [Test]
        public async Task StartGame_validMatch_matchReturned()
        {
            Mock<IFootballBoardRepository> _repo = new Mock<IFootballBoardRepository>();
            _repo.Setup(o => o.Add(It.IsAny<FootballMatch>())).ReturnsAsync(SINGLE_MATCH);
            IScoreBoardService inner = new ScoreBoardService(_repo.Object);
            var match = await inner.StartGame("Boca", "River");
            Assert.IsTrue(match.CreationTime > DateTime.Now.AddDays(-1));
        }

        [Test]
        public async Task FinishGame_invalidMatch_ownException()
        {
            Mock<IFootballBoardRepository> _repo = new Mock<IFootballBoardRepository>();
            _repo.Setup(o => o.Remove(It.IsAny<string>())).ThrowsAsync(new InvalidMatchException());
            IScoreBoardService inner = new ScoreBoardService(_repo.Object);

            Assert.ThrowsAsync<InvalidMatchException>(() => inner.FinishGame("a00223"));
        }

        [Test]
        public async Task FinishGame_validMatch_matchReturned()
        {
            Mock<IFootballBoardRepository> _repo = new Mock<IFootballBoardRepository>();
            _repo.Setup(o => o.Remove(It.IsAny<string>())).ReturnsAsync(SINGLE_MATCH);
            IScoreBoardService inner = new ScoreBoardService(_repo.Object);
            FootballMatch match = await inner.FinishGame("example");
            Assert.IsNotNull(match);
        }

        [Test]
        public async Task UpdateScore_invalidScore_ownException()
        {
            Mock<IFootballBoardRepository> _repo = new Mock<IFootballBoardRepository>();
            _repo.Setup(o => o.Update(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).ThrowsAsync(new InvalidScoreException());
            IScoreBoardService inner = new ScoreBoardService(_repo.Object);
            Assert.ThrowsAsync<InvalidScoreException>(() => inner.UpdateScore("example", 2, 0));
        }

        [Test]
        public async Task UpdateScore_invalidMatch_ownException()
        {
            Mock<IFootballBoardRepository> _repo = new Mock<IFootballBoardRepository>();
            _repo.Setup(o => o.Update(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).ThrowsAsync(new InvalidMatchException());
            IScoreBoardService inner = new ScoreBoardService(_repo.Object);
            Assert.ThrowsAsync<InvalidMatchException>(() => inner.UpdateScore("example", 2, 0));
        }
        [Test]
        public async Task UpdateScore_validMatchAndResult_MatchReturned()
        {
            Mock<IFootballBoardRepository> _repo = new Mock<IFootballBoardRepository>();
            _repo.Setup(o => o.Update(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(SINGLE_MATCH);
            IScoreBoardService inner = new ScoreBoardService(_repo.Object);
            FootballMatch match = await inner.UpdateScore("example", 2, 0);
            Assert.IsTrue(match?.LocalTeam?.Score == 2);
        }

        [Test]
        public async Task GetSummary_noMatches_noMatchesMessage()
        {
            Mock<IFootballBoardRepository> _repo = new Mock<IFootballBoardRepository>();
            _repo.Setup(o => o.GetAll()).ReturnsAsync(new List<FootballMatch>());
            IScoreBoardService inner = new ScoreBoardService(_repo.Object);
            string summary = await inner.GetSummary();
            Assert.IsTrue(summary.StartsWith("No matches found"));
        }

        [Test]
        public async Task GetSummary_validMatches_validOrderedMatchesSummary()
        {
            Mock<IFootballBoardRepository> _repo = new Mock<IFootballBoardRepository>();
            _repo.Setup(o => o.GetAll()).ReturnsAsync(UNORDERED_MATCHES);
            IScoreBoardService inner = new ScoreBoardService(_repo.Object);
            string summary = await inner.GetSummary();
            Assert.IsTrue(summary.StartsWith(""));
        }
    }
}