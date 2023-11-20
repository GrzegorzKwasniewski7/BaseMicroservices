using MediatR;
using MotleyApp.Application.Abstractions;
using MotleyApp.Application.Products.Queries;
using MotleyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotleyApp.Application.Products.QueryHandlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProducts, ICollection<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ICollection<Product>> Handle(GetAllProducts request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAll(request.MinQuantity);
        }
    }
}
