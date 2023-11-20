using Microsoft.EntityFrameworkCore;
using Moq;
using MotleyApp.Application.Abstractions;
using MotleyApp.Domain.Entities;
using MotleyApp.Infrastructure.Repositories;

namespace MotleyApp.Infrastructure.Tests
{
    public class ProductRepoTests
    {
        [Fact]
        public async Task GetProducts_ReturnsAProductCollectionResult()
        {
            
        }

        private IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>
            {
                new Product()
                {
                    Id = 1,
                    Name = "Test One",
                    Category = "C1",
                    Quantity = 1,
                    Price = 100
                },
                new Product()
                {
                    Id = 2,
                    Name = "Test One",
                    Category = "C2",
                    Quantity = 2,
                    Price = 200
                }
            };
            return products;
        }
    }
}