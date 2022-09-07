
namespace FootballScoreBoard.Domain.Exceptions
{

    internal class InvalidScoreException : Exception
    {
        public override string Message
        {
            get
            {
                return "You have passed an invalid result";
            }
        }
    }

}
