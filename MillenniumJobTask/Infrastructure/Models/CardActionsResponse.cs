namespace MillenniumJobTask.Infrastructure.Models
{
    public class CardActionsResponse
    {
        public required IEnumerable<string> AllowedActions { get; init; }
    }
}
