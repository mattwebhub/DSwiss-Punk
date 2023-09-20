using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DSwiss_Punk.Core.Models;
using DSwiss_Punk.Core.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;
using DSwiss_Punk.Core.Views;

namespace DSwiss_Punk.Core.ViewModels
{
    public class ProductListViewModel : BaseViewModel
    {
        private readonly ProductService _productService;
        public Product Product;

        public IAsyncRelayCommand LoadProductsCommand { get; }
        public IAsyncRelayCommand<Product> GoToDetailsCommand { get; }
        public IAsyncRelayCommand LoadMoreProductsCommand { get; }
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public ProductListViewModel(ProductService productService)
        {
            _productService = productService;
            LoadProductsCommand = new AsyncRelayCommand(LoadProductsAsync);
            GoToDetailsCommand = new AsyncRelayCommand<Product>(GoToDetailsAsync);
            LoadMoreProductsCommand = new AsyncRelayCommand(LoadMoreProductsAsync);
        }


        public ObservableCollection<Product> Products { get; } = new();


        private async Task LoadProductsAsync()
        {
            try
            {
                var products = await _productService.GetProductsAsync(CurrentPage, PageSize);
                foreach (var product in products)
                {
                    Products.Add(product);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading products: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async Task LoadMoreProductsAsync()
        {
            if (IsBusy) return;
            IsBusy = true;
            CurrentPage++;
            await LoadProductsAsync();
        }

        private async Task GoToDetailsAsync(Product product)
        {
            if (product == null)
            {
                return;
            }

            await Shell.Current.GoToAsync(nameof(ProductDetails), true, new Dictionary<string, object>
            {
                { "Product", product }
            });
        }
    }
}