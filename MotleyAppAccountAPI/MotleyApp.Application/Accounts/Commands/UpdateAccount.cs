using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotleyApp.Application.Products.Commands
{
    public class UpdateAccount
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public decimal Balance { get; set; }
    }
}
