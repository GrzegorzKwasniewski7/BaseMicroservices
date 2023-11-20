using MediatR;
using MotleyApp.Application.Abstractions;
using MotleyApp.Application.Products.Commands;
using MotleyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotleyApp.Application.Products.CommandHandlers
{
    public class CompleteOrderHandler: IRequestHandler<CompleteOrder, bool>
    {
        private readonly IProductRepository _productRepository;

        public CompleteOrderHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(CompleteOrder request, CancellationToken cancellationToken)
        {
            //TO DO
            //Implement logic for completing order and related objects
            return true;
        }
        
    }
}
