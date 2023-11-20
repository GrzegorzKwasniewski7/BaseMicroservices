using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotleyApp.Application.Accounts.Commands
{
    public class ReplenishBalance
    {
        public int Id { get; set; }
        public decimal AddToBalance{ get; set; }
    }
}
