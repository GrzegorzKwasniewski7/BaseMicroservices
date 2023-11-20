using AutoMapper;
using MassTransit.Transports;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MotleyApp.Application.Products.Commands;
using MotleyApp.Application.Products.Queries;
using MotleyAppAPI.DTOs;
using MotleyAppAPI.Services;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace MotleyAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        
        public ProductsController(IMapper mapper, ILogger<ProductsController> logger)
        {
            _mapper = mapper;
            _logger = logger; 
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<IResult> GetProductById(IMediator mediator, int id)
        {
            var getProduct = new GetProductById { Id = id };
            var product = await mediator.Send(getProduct);

            return TypedResults.Ok(product);
        }

        [HttpGet(Name = "GetAllProducts")]
        public async Task<IResult> GetAllProducts(IMediator mediator)
        {
            var getProducts = new GetAllProducts() { MinQuantity = 1 };
            var product = await mediator.Send(getProducts);
            
            return TypedResults.Ok(product);
        }

        [HttpPost(Name = "CreateProduct")]        
        public async Task<IResult> CreateProduct(IMediator mediator, CreateProductDTO product)
        {
            try
            {
                var productToCreate = _mapper.Map(product, typeof(CreateProductDTO), typeof(CreateProduct));
                var productCreated = await mediator.Send(productToCreate);
                var productToReturn = _mapper.Map(productCreated, typeof(CreateProduct), typeof(CreateProductDTO));
                return TypedResults.Ok(productToReturn);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return TypedResults.BadRequest(ex);
            }            
        }

        [HttpPut(Name = "UpdateProduct")]
        public async Task<IResult> UpdateProduct(IMediator mediator, UpdateProductDTO product)
        {
            try
            {
                var productToCreate = _mapper.Map(product, typeof(CreateProductDTO), typeof(CreateProduct));
                var productCreated = await mediator.Send(productToCreate);
                var productToReturn = _mapper.Map(productCreated, typeof(CreateProduct), typeof(CreateProductDTO));
                return TypedResults.Ok(productToReturn);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return TypedResults.BadRequest(ex);
            }
        }

        [HttpDelete(Name = "DeleteProduct")]
        public async Task<IResult> DeleteProduct(IMediator mediator, int id)
        {
            try
            {                
                await mediator.Send(new DeleteProduct() { Id = id });                
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
