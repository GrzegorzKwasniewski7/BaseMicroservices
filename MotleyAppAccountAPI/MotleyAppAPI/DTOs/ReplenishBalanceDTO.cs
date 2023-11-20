using System.ComponentModel.DataAnnotations;

namespace MotleyAppAPI.DTOs
{
    public class ReplenishBalanceDTO
    {
        public int Id { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public decimal AddToBalanace { get; set; }
    }
}
