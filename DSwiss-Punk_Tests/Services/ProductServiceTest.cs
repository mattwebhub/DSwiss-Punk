using FluentAssertions;
// using NSubstitute; Used for mocking

using DSwiss_Punk.Core.Models;
using DSwiss_Punk.Core.Services;

namespace DSwiss_Punk_Tests.Services
{
    public class ProductServiceTests
    {
        [Fact]
        public async Task GetProductsAsync_ReturnsExpectedProducts()
        {
            // Arrange
            var expectedProducts = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Description = "Description 1", Price = 100 },
                new Product { Id = 2, Name = "Product 2", Description = "Description 2", Price = 200 },
            };

            var productService = new ProductService();

            // Act
            var products = await productService.GetProductsAsync();

            // Assert
            products.Should().BeEquivalentTo(expectedProducts);
        }
    }
}