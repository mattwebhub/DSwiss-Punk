using DSwiss_Punk.Core.ViewModels;

namespace DSwiss_Punk;

public partial class MainPage : ContentPage
{
    public MainPage(
        ProductListViewModel viewModel
    )
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}