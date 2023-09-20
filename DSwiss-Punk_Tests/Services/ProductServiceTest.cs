using FluentAssertions;
using NSubstitute;
using DSwiss_Punk.Core.Models;
using DSwiss_Punk.Core.Services;
using System.Net.Http;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Xunit;

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
                new Product { Id = 1, Name = "Buzz", Tagline = "A Real Bitter Experience.", First_brewed = "09/2007", Description = "A light, crisp and bitter IPA brewed with English and American hops. A small batch brewed only once.", Image_url = "https://images.punkapi.com/v2/keg.png" },
                new Product { Id = 2, Name = "Trashy Blonde", Tagline = "You Know You Shouldn't", First_brewed = "04/2008", Description = "A titillating, neurotic, peroxide punk of a Pale Ale. Combining attitude, style, substance, and a little bit of low self esteem for good measure; what would your mother say? The seductive lure of the sassy passion fruit hop proves too much to resist. All that is even before we get onto the fact that there are no additives, preservatives, pasteurization or strings attached. All wrapped up with the customary BrewDog bite and imaginative twist.", Image_url = "https://images.punkapi.com/v2/2.png" },
            };

            var httpClient = Substitute.For<HttpClient>();
            string expectedUri = "https://api.punkapi.com/v2/beers?page=1&per_page=2";
            httpClient.GetAsync(expectedUri)
                      .Returns(new HttpResponseMessage(HttpStatusCode.OK)
                      {
                          Content = new StringContent(JsonConvert.SerializeObject(expectedProducts), Encoding.UTF8, "application/json")
                      });

            var productService = new ProductService();

            // Act
            var products = await productService.GetProductsAsync(1, 2);

            // Assert
            products.Should().BeEquivalentTo(expectedProducts);
        }
    }
}