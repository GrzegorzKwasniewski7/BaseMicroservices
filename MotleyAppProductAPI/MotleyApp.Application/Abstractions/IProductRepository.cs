using MotleyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotleyApp.Application.Abstractions
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetAll(int minQuantity);

        Task<ICollection<Product>> FilterProduct();

        Task<Product> GetProductById(int productId);

        Task<Product> AddProduct(Product toCreate);

        Task<Product?> UpdateProduct(int productId, string name, string category, decimal price, int quantity);

        Task DeleteProduct(int productId);
    }
}
