// ProductService

using System.Diagnostics;
using DSwiss_Punk.Core.Models;

namespace DSwiss_Punk.Core.Services
{
    public class ProductService
    {
        public async Task<List<Product>> GetProductsAsync()
        {
            // [CONSTR] Placeholder for ProductService
            await Task.Delay(1000); // Simulate a delay
            Debug.Print("Getting products");
            return new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Description = "Description 1", Price = 100 },
                new Product { Id = 2, Name = "Product 2", Description = "Description 2", Price = 200 },

            };
        }
    }
}