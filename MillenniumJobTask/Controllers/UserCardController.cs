using Microsoft.AspNetCore.Mvc;
using MillenniumJobTask.Infrastructure.Models;
using MillenniumJobTask.Logic.Services.Card;

namespace MillenniumJobTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserCardController : ControllerBase
    {
        private readonly ILogger<UserCardController> _logger;
        private readonly ICardService _cardService;
        private readonly ICardActionService _cardActionService;
        public UserCardController(ILogger<UserCardController> logger, ICardService cardService, ICardActionService cardActionService)
        {
            _logger = logger;
            _cardService = cardService;
            _cardActionService = cardActionService;
        }

        [HttpGet("{UserId}/{CardNumber}")]
        public async Task<IActionResult> GetCardActions([FromRoute]CardActionsRequestParams request)
        {
            try
            {
                var cardDetails = await _cardService.GetCardDetails(request.UserId, request.CardNumber);

                if (cardDetails == null)
                {
                    _logger.LogWarning($"Card not found for user {request.UserId} and card {request.CardNumber}");
                    return NotFound(new { message = "Card not found" });
                }

                var allowedActions = await _cardActionService.GetAllowedActions(cardDetails);
                
                return Ok(new CardActionsResponse { AllowedActions = allowedActions.Select(a => a.ToString()).ToList()});
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving card actions for user {request.UserId} and card {request.CardNumber}");
                return StatusCode(500, new { message = "Internal server error" });
            }
        }
    }
}
