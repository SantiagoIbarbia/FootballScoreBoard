using FootballScoreBoard.Domain.Entities;
using FootballScoreBoard.Domain.Exceptions;
using FootballScoreBoard.Infraescturture.Interfaces;
using FootballScoreBoard.Services.Interfaces;
using FootballScoreBoard.Services;
using FootballScoreBoard.Tests.Utilities;
using Moq;

namespace FootballScoreBoard.Tests.Services
{
    internal class SummaryMessageServiceTests
    {
        private ICollection<FootballMatch> UNORDERED_MATCHES;

        [SetUp]
        public void Setup()
        {
            UNORDERED_MATCHES = MockFilesHelper.DeserializeFromMockFile<ICollection<FootballMatch>>("Files/unorderedMatches.json");
        }
        [Test]
        public async Task Summary_notmatches()
        {
            ISummaryMessageService inner = new SummaryMessageService();
            string summary = inner.GetSummary(new List<FootballMatch>());
            Assert.IsTrue(summary == "No matches found");

        }

        [Test]
        public async Task Summary_multipleMatches_firstLineOK()
        {
            ISummaryMessageService inner = new SummaryMessageService();
            string summary = inner.GetSummary(UNORDERED_MATCHES);
            Assert.IsTrue(summary.StartsWith("1. Mexico 0 - Canada 5 \n"));

        }

    }
}
