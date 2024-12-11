using MillenniumJobTask.Logic.Services.Card.Models;

namespace MillenniumJobTask.Logic.Services.Card
{
    public interface ICardActionService
    {
        Task<IEnumerable<CardAction>> GetAllowedActions(CardDetails card);
    }
}