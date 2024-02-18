using InventarioMobileApp.Data;
using InventarioMobileApp.Repositories.Contract;
using InventarioMobileApp.Repositories.Implementation;
using Mopups.Hosting;
using Mopups.Interfaces;
using Mopups.Services;
using UraniumUI;
using ZXing.Net.Maui.Controls;

namespace InventarioMobileApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
            .UseUraniumUI()
			.UseUraniumUIMaterial()
			.UseBarcodeReader()
			.ConfigureMopups()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddMaterialIconFonts();
                fonts.AddFontAwesomeIconFonts();
            });

		builder.Services.AddTransient<MainViewModel>();
		builder.Services.AddTransient<MainPage>();

        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<HomePage>();

		builder.Services.AddTransient<DownloadViewModel>();
		builder.Services.AddTransient<DownloadPage>();

        builder.Services.AddTransient<BarcodeViewModel>();
        builder.Services.AddTransient<BarcodePage>();

        builder.Services.AddTransient<UploadViewModel>();
        builder.Services.AddTransient<UploadPage>();

        builder.Services.AddScoped<ILoginRepository, LoginRepository>();
		builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
		builder.Services.AddScoped<ICSVRepository, CSVRepository>();

		builder.Services.AddTransient<DetailProductPage>();
        builder.Services.AddTransient<DetailProductViewModel>();

        builder.Services.AddSingleton<IPopupNavigation>(MopupService.Instance);

		return builder.Build();
	}
}
