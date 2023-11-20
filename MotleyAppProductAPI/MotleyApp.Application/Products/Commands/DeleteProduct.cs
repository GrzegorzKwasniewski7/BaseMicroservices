using MediatR;
using MotleyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotleyApp.Application.Products.Commands
{
    public class DeleteProduct: IRequest<bool>
    {
        public int Id { get; set; }
    }
}
