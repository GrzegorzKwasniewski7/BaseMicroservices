using MediatR;

namespace MotleyAppAPI.Services
{
    public interface IConsumerService
    {
        Task ReadMessgaes();
    }
}
