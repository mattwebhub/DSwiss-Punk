using DSwiss_Punk.Core.ViewModels;

namespace DSwiss_Punk.Core.Views;

public partial class ProductDetails : ContentPage
{
	public ProductDetails(ProductDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
