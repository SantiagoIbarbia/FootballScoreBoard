using Castle.Core.Internal;
using FootballScoreBoard.Domain.Entities;
using FootballScoreBoard.Domain.Extensions;
using FootballScoreBoard.Services.Interfaces;
using System.Runtime.CompilerServices;

[assembly: System.Runtime.CompilerServices.InternalsVisibleToAttribute("FootballScoreBoard.Tests")]
[assembly: InternalsVisibleTo(InternalsVisible.ToDynamicProxyGenAssembly2)]
namespace FootballScoreBoard.Services
{
    internal class SummaryMessageService : ISummaryMessageService
    {
        public string GetSummary(IEnumerable<FootballMatch> orderedMatches)
        {

            if (orderedMatches.IsNullOrEmpty())
            {
                return "No matches found";
            }

            string message = string.Empty;
            int i = 1;
            foreach (var match in orderedMatches)
            {
                message = $"{message}{i}. {match.HomeTeam.Name} {match.HomeTeam.Score} - {match.AwayTeam.Name} {match.AwayTeam.Score} \n";
                i++;
            }

            return message;
        }
    }
}
