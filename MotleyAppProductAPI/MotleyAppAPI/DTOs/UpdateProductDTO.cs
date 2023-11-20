using System.ComponentModel.DataAnnotations;

namespace MotleyAppAPI.DTOs
{
    public class UpdateProductDTO
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        public string? Category { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
