using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using DSwiss_Punk.Core.Services;
using DSwiss_Punk.Core.ViewModels;
using DSwiss_Punk.Core.Views;
using static DSwiss_Punk.Core.Services.ProductService;

namespace DSwiss_Punk;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddSingleton<ProductService>();
		builder.Services.AddSingleton<ProductListViewModel>();
		builder.Services.AddSingleton<ProductList>();

        builder.Services.AddTransient<ProductDetailsViewModel>();
        builder.Services.AddTransient<ProductDetails>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

