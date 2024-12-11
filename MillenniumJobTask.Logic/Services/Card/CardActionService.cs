using MillenniumJobTask.Logic.Services.Card.Models;

namespace MillenniumJobTask.Logic.Services.Card
{
    public class CardActionService : ICardActionService
    {
        public readonly List<ActionMatrixItem> _cardActions = CreateSampleCardActionMatrix(); // AHTUNG! private

        private static List<ActionMatrixItem> CreateSampleCardActionMatrix()
        {
            List<ActionMatrixItem> cardActionMatrix =
            [
                new ActionMatrixItem
                {
                    CardAction = CardAction.ACTION1,
                    CardTypes = new() { CardType.Prepaid, CardType.Debit, CardType.Credit },
                    CardStatuses = new() { new StatusPin(CardStatus.Active, null) },
                },
                new ActionMatrixItem
                {
                    CardAction = CardAction.ACTION2,
                    CardTypes = new() { CardType.Prepaid, CardType.Debit, CardType.Credit },
                    CardStatuses = new() { new StatusPin(CardStatus.Inactive, null) },
                },
                new ActionMatrixItem
                {
                    CardAction = CardAction.ACTION3,
                    CardTypes = new() { CardType.Prepaid, CardType.Debit, CardType.Credit },
                    CardStatuses = new() { new StatusPin(CardStatus.Ordered, null), 
                                           new StatusPin(CardStatus.Inactive, null),
                                           new StatusPin(CardStatus.Active, null),
                                           new StatusPin(CardStatus.Restricted, null),
                                           new StatusPin(CardStatus.Blocked, null),
                                           new StatusPin(CardStatus.Expired, null),
                                           new StatusPin(CardStatus.Closed, null),
                    },
                },
                new ActionMatrixItem
                {
                    CardAction = CardAction.ACTION4,
                    CardTypes = new() { CardType.Prepaid, CardType.Debit, CardType.Credit },
                    CardStatuses = new() { new StatusPin(CardStatus.Ordered, null),
                                           new StatusPin(CardStatus.Inactive, null),
                                           new StatusPin(CardStatus.Active, null),
                                           new StatusPin(CardStatus.Restricted, null),
                                           new StatusPin(CardStatus.Blocked, null),
                                           new StatusPin(CardStatus.Expired, null),
                                           new StatusPin(CardStatus.Closed, null),
                    },
                },
                new ActionMatrixItem
                {
                    CardAction = CardAction.ACTION5,
                    CardTypes = new() { CardType.Credit },
                    CardStatuses = new() { new StatusPin(CardStatus.Ordered, null),
                                           new StatusPin(CardStatus.Inactive, null),
                                           new StatusPin(CardStatus.Active, null),
                                           new StatusPin(CardStatus.Restricted, null),
                                           new StatusPin(CardStatus.Blocked, null),
                                           new StatusPin(CardStatus.Expired, null),
                                           new StatusPin(CardStatus.Closed, null),
                    },
                },
                new ActionMatrixItem
                {
                    CardAction = CardAction.ACTION6,
                    CardTypes = new() { CardType.Prepaid, CardType.Debit, CardType.Credit },
                    CardStatuses = new() { new StatusPin(CardStatus.Ordered, true),
                                           new StatusPin(CardStatus.Inactive, true),
                                           new StatusPin(CardStatus.Active, true),
                                           new StatusPin(CardStatus.Blocked, true)
                    },
                },
                new ActionMatrixItem
                {
                    CardAction = CardAction.ACTION7,
                    CardTypes = new() { CardType.Prepaid, CardType.Debit, CardType.Credit },
                    CardStatuses = new() { new StatusPin(CardStatus.Ordered, false),
                                           new StatusPin(CardStatus.Inactive, false),
                                           new StatusPin(CardStatus.Active, false),
                                           new StatusPin(CardStatus.Blocked, true)
                    },
                },
                new ActionMatrixItem
                {
                    CardAction = CardAction.ACTION8,
                    CardTypes = new() { CardType.Prepaid, CardType.Debit, CardType.Credit },
                    CardStatuses = new() { new StatusPin(CardStatus.Ordered, null),
                                           new StatusPin(CardStatus.Inactive, null),
                                           new StatusPin(CardStatus.Active, null),
                                           new StatusPin(CardStatus.Blocked, null),
                    },
                },
                new ActionMatrixItem
                {
                    CardAction = CardAction.ACTION9,
                    CardTypes = new() { CardType.Prepaid, CardType.Debit, CardType.Credit },
                    CardStatuses = new() { new StatusPin(CardStatus.Ordered, null),
                                           new StatusPin(CardStatus.Inactive, null),
                                           new StatusPin(CardStatus.Active, null),
                                           new StatusPin(CardStatus.Restricted, null),
                                           new StatusPin(CardStatus.Blocked, null),
                                           new StatusPin(CardStatus.Expired, null),
                                           new StatusPin(CardStatus.Closed, null),
                    },
                },
                new ActionMatrixItem
                {
                    CardAction = CardAction.ACTION10,
                    CardTypes = new() { CardType.Prepaid, CardType.Debit, CardType.Credit },
                    CardStatuses = new() { new StatusPin(CardStatus.Ordered, null),
                                           new StatusPin(CardStatus.Inactive, null),
                                           new StatusPin(CardStatus.Active, null),
                    },
                },
                new ActionMatrixItem
                {
                    CardAction = CardAction.ACTION11,
                    CardTypes = new() { CardType.Prepaid, CardType.Debit, CardType.Credit },
                    CardStatuses = new() { new StatusPin(CardStatus.Inactive, null),
                                           new StatusPin(CardStatus.Active, null),
                    },
                },
                new ActionMatrixItem
                {
                    CardAction = CardAction.ACTION12,
                    CardTypes = new() { CardType.Prepaid, CardType.Debit, CardType.Credit },
                    CardStatuses = new() { new StatusPin(CardStatus.Ordered, null),
                                           new StatusPin(CardStatus.Inactive, null),
                                           new StatusPin(CardStatus.Active, null),
                    },
                },
                new ActionMatrixItem
                {
                    CardAction = CardAction.ACTION13,
                    CardTypes = new() { CardType.Prepaid, CardType.Debit, CardType.Credit },
                    CardStatuses = new() { new StatusPin(CardStatus.Ordered, null),
                                           new StatusPin(CardStatus.Inactive, null),
                                           new StatusPin(CardStatus.Active, null),
                    },
                },
            ];

            return cardActionMatrix;
        }

        public async Task<IEnumerable<CardAction>> GetAllowedActions(CardDetails card)
        {
            // At this point, we would typically make an HTTP call to an external service
            // to fetch the data. For this example we use generated sample data.
            await Task.Delay(1000);

            if (card == null)
                return new List<CardAction>();

            return _cardActions
                    .Where(p =>
                        p.CardTypes.Contains(card.CardType)
                        && p.CardStatuses.Any(z => z.CardStatus == card.CardStatus 
                                              && (z.ValidatePinSet == null || z.ValidatePinSet == card.IsPinSet)))
                    .Select(p => p.CardAction)
                    .ToList();
        }

        public record StatusPin(CardStatus CardStatus, bool? ValidatePinSet);
        public record ActionMatrixItem
        {
            public CardAction CardAction { get; init; }
            public required List<CardType> CardTypes { get; init; }
            public required List<StatusPin> CardStatuses { get; init; }
        }
    }
}
