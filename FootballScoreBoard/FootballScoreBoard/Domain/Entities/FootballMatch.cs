
namespace FootballScoreBoard.Domain.Entities
{
    public class FootballMatch
    {
        public string MatchId { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public int TotalScore
        {
            get
            {
                return (HomeTeam?.Score ?? 0) + (AwayTeam?.Score ?? 0);
            }
        }
    }
}
