using MediatR;
using MotleyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotleyApp.Application.Products.Commands
{
    public class CreateAccount: IRequest<Account>
    {
        public string NickName { get; set; }
        public decimal Balance { get; set; }        
    }
}
