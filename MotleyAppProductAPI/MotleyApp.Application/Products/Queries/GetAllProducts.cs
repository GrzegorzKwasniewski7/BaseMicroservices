using MediatR;
using MotleyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotleyApp.Application.Products.Queries
{
    public class GetAllProducts: IRequest<ICollection<Product>>
    {
        public int MinQuantity { get; set; }
    }
}
