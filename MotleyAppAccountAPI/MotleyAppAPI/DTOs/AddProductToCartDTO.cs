using System.ComponentModel.DataAnnotations;

namespace MotleyAppAPI.DTOs
{
    public class AddProductToCartDTO
    {
        [Required]
        public int AccountId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
