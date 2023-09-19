using DSwiss_Punk.Core.Views;

namespace DSwiss_Punk;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(ProductDetails), typeof(ProductDetails));
    }
}

