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
    public class CreateProductHandler : IRequestHandler<CreateProduct, Product>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            var person = new Product
            {
                Name = request.Name,
                Category= request.Category,
                Price= request.Price,
                Quantity= request.Quantity,
            };

            return await _productRepository.AddProduct(person);
        }
    };
}
