namespace FooballScoreBoard.Tests.Services
{
    public class ScoreBoardServiceTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void StartGame_invalidMatch_OwnException()
        {
            Assert.Pass();
        }

        [Test]
        public void StartGame_validMatch_matchReturned()
        {
            Assert.Pass();
        }

        [Test]
        public void FinishGame_invalidMatch_ownException()
        {
            Assert.Pass();
        }

        [Test]
        public void FinishGame_validMatch_matchReturned()
        {
            Assert.Pass();
        }

        [Test]
        public void UpdateScore_invalidScore_ownException()
        {
            Assert.Pass();
        }

        [Test]
        public void UpdateScore_invalidMatch_ownException()
        {
            Assert.Pass();
        }
        [Test]
        public void UpdateScore_validMatchAndResult_MatchReturned()
        {
            Assert.Pass();
        }

        [Test]
        public void GetSummary_noMatches_noMatchesMessage()
        {
            Assert.Pass();
        }

        [Test]
        public void GetSummary_validMatches_validOrderedMatchesSummary()
        {
            Assert.Pass();
        }
    }
}