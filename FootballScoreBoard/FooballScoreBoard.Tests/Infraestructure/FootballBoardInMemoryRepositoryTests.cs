
using FootballScoreBoard.Domain.Entities;
using FootballScoreBoard.Infraescturture;
using FootballScoreBoard.Tests.Utilities;

namespace FooballScoreBoard.Tests.Infraestructure
{
    internal class FootballBoardInMemoryRepositoryTests
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
        public async Task Add_ValidMatch_Added()
        {
            FootballBoardInMemoryRepository inner = new FootballBoardInMemoryRepository();

            var match = await inner.Add(SINGLE_MATCH);
            Assert.IsNotEmpty(match.MatchId);
        }
        [Test]
        public async Task Add_DuplicatedMatch_ReturnFirst()
        {
            FootballBoardInMemoryRepository inner = new FootballBoardInMemoryRepository();

            var match = await inner.Add(SINGLE_MATCH);
            Assert.IsNotEmpty(match.MatchId);
        }

        [Test]
        public async Task Remove_ValidMatch_Removed()
        {
            FootballBoardInMemoryRepository inner = new FootballBoardInMemoryRepository();

            var match = await inner.Add(SINGLE_MATCH);
            var matchRemoved = await inner.Remove(SINGLE_MATCH.MatchId);
            Assert.IsTrue(matchRemoved.MatchId == match.MatchId);
        }


        [Test]
        public async Task Remove_InValidMatch_NullResult()
        {
            FootballBoardInMemoryRepository inner = new FootballBoardInMemoryRepository();
            var matchRemoved = await inner.Remove("invalidMatchId");
            Assert.IsNull(matchRemoved);
        }

        [Test]
        public async Task Update_InValidMatch_NullResult()
        {
            FootballBoardInMemoryRepository inner = new FootballBoardInMemoryRepository();
            var matchUpdated = await inner.Update("invalidMatchId", 1, 0);
            Assert.IsNull(matchUpdated);
        }

        [Test]
        public async Task Update_ValidMatch_Updated()
        {
            FootballBoardInMemoryRepository inner = new FootballBoardInMemoryRepository();
            var match = (await inner.Add(SINGLE_MATCH));
            int matchScore = match.TotalScore;
            var matchUpdated = await inner.Update("example", 1, 1);
            Assert.IsTrue(matchUpdated.TotalScore > matchScore);
        }

        [Test]
        public async Task GetAll()
        {
            FootballBoardInMemoryRepository inner = new FootballBoardInMemoryRepository();
            foreach (var match in UNORDERED_MATCHES)
            {
                await inner.Add(match);
            }
            var matches = await inner.GetAll();
            Assert.IsTrue(matches.Any());
            Assert.IsTrue(matches.Count == 5);
        }
    }
}
