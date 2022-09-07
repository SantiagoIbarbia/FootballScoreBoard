
namespace FootballScoreBoard.Domain.Entities
{
    public class Team
    {
        public Team(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public string Logo { get; set; }
        public int Score { get; set; } = 0;

        //More data like players, position, corners...
    }
}
