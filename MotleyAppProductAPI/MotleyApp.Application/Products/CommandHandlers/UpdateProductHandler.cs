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
    public class UpdateProductHandler : IRequestHandler<UpdateProduct, Product>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(UpdateProduct request, CancellationToken cancellationToken)
        {            
            return await _productRepository.UpdateProduct(request.Id, request.Name, request.Category, request.Price, request.Quantity);
        }
    }
}
