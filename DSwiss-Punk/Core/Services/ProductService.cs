using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;
using DSwiss_Punk.Core.Models;

namespace DSwiss_Punk.Core.Services
{
    public class ProductService
    {
        private HttpClient httpClient;
        private List<Product> productList;
        private string apiUrl = "https://api.punkapi.com/v2/beers?";

        public ProductService()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<List<Product>> GetProductsAsync(int pageNumber, int pageSize)
        {
            if (productList?.Count > 0)
                return productList;
            if (apiUrl == null)
            {
                return new List<Product>();
            }

            var response = await httpClient.GetAsync($"{apiUrl}/page={pageNumber}&per_page={pageSize}");

            if (response.IsSuccessStatusCode)
            {
                productList = await response.Content.ReadFromJsonAsync<List<Product>>();
            }

            Debug.WriteLine(productList);

            return productList;
        }
    }
}