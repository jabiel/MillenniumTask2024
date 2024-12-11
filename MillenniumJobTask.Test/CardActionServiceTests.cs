using MillenniumJobTask.Logic.Services.Card;
using MillenniumJobTask.Logic.Services.Card.Models;
using Xunit;

namespace MillenniumJobTask.Test
{
    public class CardActionServiceTests
    {
        [Fact]
        public async Task GetAllowedActions_with_null_cardDetails_returns_empty_actionlist()
        {
            // Arrange
            CardActionService srv = new CardActionService();
            // Act
            var result = await srv.GetAllowedActions(null);
            // Assert             
            Assert.Empty(result);
        }

        [Theory]
        [InlineData(CardType.Prepaid, CardStatus.Closed, false, new int[] { 3, 4, 9 })]   // "Dla karty PREPAID w statusie CLOSED aplikacja powinna zwrócić akcje: ACTION3, ACTION4, ACTION9"
        [InlineData(CardType.Prepaid, CardStatus.Ordered, false, new int[] { 3, 4, 7, 8, 9, 10, 12, 13 })]   // no 6 as pin not set
        [InlineData(CardType.Prepaid, CardStatus.Ordered, true, new int[] { 3, 4, 6, 8, 9, 10, 12, 13 })] // 6 instead of 7 as pinIsSet
        [InlineData(CardType.Credit, CardStatus.Closed, false, new int[] { 3, 4, 5, 9 })]
        [InlineData(CardType.Credit, CardStatus.Blocked, false, new int[] { 3, 4, 8, 9 })] // no 6,7 as pin not set
        [InlineData(CardType.Credit, CardStatus.Blocked, true, new int[] { 3, 4, 6, 7, 8, 9 })] // Dla karty CREDIT w statusie BLOCKED aplikacja powinna zwrócić akcje: ACTION3, ACTION4, ACTION5,ACTION6(jeżeli pin nadany), ACTION7(jeżeli pin nadany), ACTION8, ACTION9
        [InlineData(CardType.Debit, CardStatus.Restricted, true, new int[] { 3, 4, 9 })] 
        public async Task GetAllowedActions_returns_correct_actions(CardType cardType, CardStatus cardStatus, bool isPinSet, int[] expextedActionIds)
        {
            // Arrange
            CardActionService srv = new CardActionService();
            // Act
            var result = await srv.GetAllowedActions(new CardDetails("test", cardType, cardStatus, isPinSet));
            // Assert             
            Assert.Equal(expextedActionIds.Select(id => (CardAction)id).ToList(), result);
        }


    }
}
