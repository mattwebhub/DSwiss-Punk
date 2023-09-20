using System.Diagnostics;
using System.Net.Http.Json;
using DSwiss_Punk.Core.Models;

namespace DSwiss_Punk.Core.Services
{
    public class ProductService
    {
        private HttpClient _httpClient;
        private List<Product> _productList;
        private const string ApiUrl = "https://api.punkapi.com/v2/beers?";

        public ProductService()
        {
            // Note: We would want to modify this to accept this instance on the constructor, so that it can be more testable
            // For time constraints we will leave it as is.
            this._httpClient = new HttpClient();
        }

        public async Task<List<Product>> GetProductsAsync(int pageNumber, int pageSize)
        {
            if (_productList?.Count > 0)
                return _productList;

            var response = await _httpClient.GetAsync($"{ApiUrl}/page={pageNumber}&per_page={pageSize}");

            if (response.IsSuccessStatusCode)
            {
                _productList = await response.Content.ReadFromJsonAsync<List<Product>>();
            }

            Debug.WriteLine(_productList);

            return _productList;
        }
    }
}