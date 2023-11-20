using MediatR;
using MotleyApp.Domain.Entities;


namespace MotleyApp.Application.Products.Queries
{
    public class GetAccountById: IRequest<Account>
    {
        public int Id { get; set; }
    }
}
