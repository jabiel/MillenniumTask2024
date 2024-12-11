using System.ComponentModel.DataAnnotations;

namespace MillenniumJobTask.Infrastructure.Models
{
    public class CardActionsRequestParams
    {
        [Required]
        [StringLength(8, MinimumLength = 5)]
        public required string UserId { get; set; }

        [Required]
        [StringLength(7, MinimumLength = 4)] // Zakładając, że karta ma 16 cyfr
        public required string CardNumber { get; set; }
    }
}
