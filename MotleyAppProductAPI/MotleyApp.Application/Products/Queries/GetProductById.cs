using MediatR;
using MotleyApp.Domain.Entities;


namespace MotleyApp.Application.Products.Queries
{
    public class GetProductById: IRequest<Product>
    {
        public int Id { get; set; }
    }
}
