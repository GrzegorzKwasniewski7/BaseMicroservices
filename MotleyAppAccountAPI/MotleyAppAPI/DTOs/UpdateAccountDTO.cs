using System.ComponentModel.DataAnnotations;

namespace MotleyAppAPI.DTOs
{
    public class UpdateAccountDTO
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string NickName { get; set; }
        public decimal Balance { get; set; }
    }
}
