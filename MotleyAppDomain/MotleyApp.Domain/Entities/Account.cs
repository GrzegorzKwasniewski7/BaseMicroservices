using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotleyApp.Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Nickname { get; set; }

        [Range(1, int.MaxValue)]
        public decimal Balance { get; set; }
        public virtual ICollection<Product> Cart { get; set; }
    }
}
