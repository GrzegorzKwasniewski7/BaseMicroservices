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
    public class DeleteProductHandler : IRequestHandler<DeleteProduct, bool>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProduct request, CancellationToken cancellationToken)
        {            
            await _productRepository.DeleteProduct(request.Id);
            return true;
        }
    }
}
