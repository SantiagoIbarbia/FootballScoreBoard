namespace FootballScoreBoard.Domain.Extensions
{
    internal static class IEnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> value)
        {
            return value == null || !value.Any();
        }
    }
}
