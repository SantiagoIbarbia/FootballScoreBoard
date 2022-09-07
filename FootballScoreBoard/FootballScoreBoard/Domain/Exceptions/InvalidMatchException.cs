
namespace FootballScoreBoard.Domain.Exceptions
{
    internal class InvalidMatchException : Exception
    {
        public override string Message
        {
            get
            {
                return "There is no LIVE match with that ID";
            }
        }
    }

}