using FluentAssertions;
using DSwiss_Punk.Core.Models;
using DSwiss_Punk.Core.Services;
using System.Net;
using Newtonsoft.Json;


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
                new Product
                {
                    Name = "Buzz", Tagline = "A Real Bitter Experience.",
                    Description =
                        "A light, crisp and bitter IPA brewed with English and American hops. A small batch brewed only once.",
                    Image_Url = "https://images.punkapi.com/v2/keg.png"
                },
                new Product
                {
                    Name = "Trashy Blonde", Tagline = "You Know You Shouldn't",
                    Description =
                        "A titillating, neurotic, peroxide punk of a Pale Ale. Combining attitude, style, substance, and a little bit of low self esteem for good measure; what would your mother say? The seductive lure of the sassy passion fruit hop proves too much to resist. All that is even before we get onto the fact that there are no additives, preservatives, pasteurization or strings attached. All wrapped up with the customary BrewDog bite and imaginative twist.",
                    Image_Url = "https://images.punkapi.com/v2/2.png"
                },
            };

            var httpMessageHandler =
                new MockHttpMessageHandler(JsonConvert.SerializeObject(expectedProducts), HttpStatusCode.OK);
            var httpClient = new HttpClient(httpMessageHandler);

            var productService = new ProductService(httpClient);

            // Act
            var products = await productService.GetProductsAsync(1, 2);

            // Assert
            products.Should().BeEquivalentTo(expectedProducts, options => options
                .Including(p => p.Name)
                .Including(p => p.Tagline)
                .Including(p => p.Description));
        }
    }

    public class MockHttpMessageHandler : HttpMessageHandler
    {
        private readonly string _response;
        private readonly HttpStatusCode _statusCode;

        public MockHttpMessageHandler(string response, HttpStatusCode statusCode)
        {
            _response = response;
            _statusCode = statusCode;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpResponseMessage
            {
                StatusCode = _statusCode,
                Content = new StringContent(_response)
            });
        }
    }
}