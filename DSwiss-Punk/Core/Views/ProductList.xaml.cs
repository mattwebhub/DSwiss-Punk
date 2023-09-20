using DSwiss_Punk.Core.ViewModels;

namespace DSwiss_Punk.Core.Views
{
    public partial class ProductList: ContentPage
    {
        private readonly ProductListViewModel _viewModel;

        public ProductList(ProductListViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = _viewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_viewModel.IsBusy)
                return;

            _viewModel.LoadProductsCommand.Execute(null);
        }
    }
}