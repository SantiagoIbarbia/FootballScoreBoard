
namespace FootballScoreBoard.Domain.Exceptions
{
    internal class SameTeamException : Exception
    {
        public override string Message
        {
            get
            {
                return "Both teams are the same.";
            }
        }
    }
}
