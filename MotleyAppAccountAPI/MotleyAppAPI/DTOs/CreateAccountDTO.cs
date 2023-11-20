using MediatR;
using MotleyApp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MotleyAppAPI.DTOs
{
    public class CreateAccountDTO
    {
        [Required(AllowEmptyStrings = false)]        
        public string NickName { get; set; }
        public decimal Balance { get; set; }
    }
}
