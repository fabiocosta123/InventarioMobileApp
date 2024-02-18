using InventarioMobileApp.Views;

namespace InventarioMobileApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(BarcodePage), typeof(BarcodePage));
        Routing.RegisterRoute(nameof(DetailProductPage), typeof(DetailProductPage));
    }
}
