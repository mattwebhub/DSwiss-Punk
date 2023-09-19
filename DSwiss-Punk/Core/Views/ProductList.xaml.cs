using DSwiss_Punk.Core.ViewModels;

namespace DSwiss_Punk.Core.Views;

public partial class ProductList: ContentPage
{
    public ProductList(ProductListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}