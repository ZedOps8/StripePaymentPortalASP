using System.ComponentModel.DataAnnotations;

namespace StripeWebApp.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Url(ErrorMessage = "Invalid URL format.")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price ID is required.")]
        public string? PriceId { get; set; }
    }
}
