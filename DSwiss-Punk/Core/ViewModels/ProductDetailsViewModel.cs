using CommunityToolkit.Mvvm.ComponentModel;
using DSwiss_Punk.Core.Models;


namespace DSwiss_Punk.Core.ViewModels
{
    [QueryProperty(nameof(Product), "Product")]
    public partial class ProductDetailsViewModel : BaseViewModel
    {
        public ProductDetailsViewModel()
        {
        }
        [ObservableProperty] 
        public Product product;
    }
}