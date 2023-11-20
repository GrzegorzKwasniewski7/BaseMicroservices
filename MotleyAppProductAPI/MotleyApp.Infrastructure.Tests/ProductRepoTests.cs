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
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "MotleyDB")
            .Options;

            using (var context = new AppDbContext(options))
            {
                context.Product.AddRange(GetProducts());
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new AppDbContext(options))
            {
                //Act
                ProductRepository productRepo = new ProductRepository(context);
                ICollection<Product> products = await productRepo.GetAll(1);

                //Assert
                Assert.Equal(2, products.Count);
            }
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