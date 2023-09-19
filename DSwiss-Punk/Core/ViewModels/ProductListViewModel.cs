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
        private Product _selectedProduct;

        public IAsyncRelayCommand LoadProductsCommand { get; }
        public IAsyncRelayCommand<Product> GoToDetailsCommand { get; }

        public ProductListViewModel(ProductService productService)
        {
            _productService = productService;
            LoadProductsCommand = new AsyncRelayCommand(LoadProductsAsync);
            GoToDetailsCommand = new AsyncRelayCommand<Product>(GoToDetailsAsync);
        }


        public ObservableCollection<Product> Products { get; } = new();

        // [CONSTR]
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set => SetProperty(ref _selectedProduct, value);
        }

        private async Task LoadProductsAsync()
        {
            var products = await _productService.GetProductsAsync();
            Products.Clear();
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }
        private async Task GoToDetailsAsync(Product product)
        {
            
            Debug.Print("Going to Details!", product);
            
            await Shell.Current.GoToAsync(nameof(ProductDetails), true, new Dictionary<string, object>
        {
            {"Product", product }
        });
        }
    }
}