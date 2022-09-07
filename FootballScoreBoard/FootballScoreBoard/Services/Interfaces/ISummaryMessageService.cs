using Castle.Core.Internal;
using FootballScoreBoard.Domain.Entities;
using System.Runtime.CompilerServices;

[assembly: System.Runtime.CompilerServices.InternalsVisibleToAttribute("FootballScoreBoard.Tests")]
[assembly: InternalsVisibleTo(InternalsVisible.ToDynamicProxyGenAssembly2)]
namespace FootballScoreBoard.Services.Interfaces
{
    internal interface ISummaryMessageService
    {
        string GetSummary(IEnumerable<FootballMatch> orderedMatches);
    }
}
