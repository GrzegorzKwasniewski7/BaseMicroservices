using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotleyApp.Application.Accounts.Commands;
using MotleyApp.Application.Products.Commands;
using MotleyApp.Application.Products.Queries;
using MotleyApp.Domain.Entities;
using MotleyAppAPI.DTOs;
using MotleyAppAPI.Services;

namespace MotleyAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IMessageProducer _messagePublisher;

        public AccountsController(IMapper mapper, IMessageProducer messagePublisher, ILogger<AccountsController> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _messagePublisher = messagePublisher;
        }

        [HttpGet("{id}", Name = "GetAccountById")]
        public async Task<IResult> GetAccountById(IMediator mediator, int id)
        {
            var getProduct = new GetAccountById { Id = id };
            var product = await mediator.Send(getProduct);

            return TypedResults.Ok(product);
        }        

        [HttpPost(Name = "CreateAccount")]
        public async Task<IResult> CreateAccount(IMediator mediator, CreateAccountDTO product)
        {
            try
            {
                var accountToCreate = _mapper.Map(product, typeof(CreateAccountDTO), typeof(CreateAccount));
                var accountCreated = await mediator.Send(accountToCreate);
                var productToReturn = _mapper.Map(accountCreated, typeof(CreateAccount), typeof(CreateAccountDTO));
                return TypedResults.Ok(productToReturn);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return TypedResults.BadRequest();
            }
        }

        [HttpPut(Name = "UpdateAccount")]
        public async Task<IResult> UpdateAccount(IMediator mediator, UpdateAccountDTO product)
        {
            try
            {
                var accountToUpdate = _mapper.Map(product, typeof(UpdateAccountDTO), typeof(UpdateAccount));
                var updatedAccount = await mediator.Send(accountToUpdate);
                var productToReturn = _mapper.Map(updatedAccount, typeof(UpdateAccount), typeof(UpdateAccountDTO));
                return TypedResults.Ok(productToReturn);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return TypedResults.BadRequest();
            }
        }

        [HttpDelete(Name = "DeleteAccount")]
        public async Task<IResult> DeleteAccount(IMediator mediator, int id)
        {
            try
            {
                await mediator.Send(new DeleteAccount() { Id = id });
                return TypedResults.Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return TypedResults.BadRequest(ex);
            }
        }

        [HttpPut("ReplenishBalance", Name = "ReplenishBalance")]
        public async Task<IResult> ReplenishBalance(IMediator mediator, ReplenishBalanceDTO balance)
        {
            try
            {
                var balanceToReplenish = _mapper.Map(balance, typeof(ReplenishBalanceDTO), typeof(ReplenishBalance));
                await mediator.Send(balanceToReplenish);
                return TypedResults.Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return TypedResults.BadRequest(ex);
            }
        }


        [HttpPut("AddProductToCart", Name = "AddProductToCart")]
        public async Task<IResult> AddProductToCart(IMediator mediator, AddProductToCartDTO productToAdd)
        {
            try
            {
                var product = _mapper.Map(productToAdd, typeof(AddProductToCartDTO), typeof(AddProductToCart));
                await mediator.Send(product);
                return TypedResults.Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return TypedResults.BadRequest(ex);
            }
        }

        [HttpPut("CompleteOrder", Name = "CompleteOrder")]
        public async Task<IResult> CompleteOrder(IMediator mediator, CompleteOrderDTO orderToComplete)
        {
            try
            {
                _messagePublisher.SendMessage(orderToComplete);
                return TypedResults.Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return TypedResults.BadRequest(ex);
            }
        }
    }
}
