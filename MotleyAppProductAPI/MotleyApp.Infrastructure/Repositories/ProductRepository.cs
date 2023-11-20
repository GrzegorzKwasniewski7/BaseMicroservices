using Microsoft.EntityFrameworkCore;
using MotleyApp.Application.Abstractions;
using MotleyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotleyApp.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddProduct(Product toCreate)
        {
            _context.Product.Add(toCreate);
            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task DeleteProduct(int productId)
        {
            var product = _context.Product
            .FirstOrDefault(p => p.Id == productId);

            if (product is null) return;

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
        }

        public Task<ICollection<Product>> FilterProduct()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Product>> GetAll(int minQuantity)
        {
            return await _context.Product.Where(p => p.Quantity >= minQuantity).ToListAsync();
        }

        public async Task<Product> GetProductById(int productId)
        {
            return await _context.Product.FindAsync(productId);
        }

        public async Task<Product?> UpdateProduct(int productId, string name, string category, decimal price, int quantity)
        {
            Product? product = await _context.Product.FirstOrDefaultAsync(p => p.Id == productId);
            if (product == null) return null;
            product.Name = name;
            product.Price = price;
            product.Quantity = quantity;
            product.Category = category;
            
            await _context.SaveChangesAsync();

            return product;
        }
    }
}
