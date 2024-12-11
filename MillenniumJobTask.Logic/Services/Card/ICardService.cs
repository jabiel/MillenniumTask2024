using MillenniumJobTask.Logic.Services.Card.Models;

namespace MillenniumJobTask.Logic.Services.Card
{
    public interface ICardService
    {
        Task<CardDetails?> GetCardDetails(string userId, string cardNumber);
    }
}