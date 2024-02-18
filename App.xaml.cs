namespace InventarioMobileApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

	//protected override async void OnStart()
	//{
	//	if (!string.IsNullOrEmpty(Preferences.Get("AccessToken", string.Empty)))
	//		await Shell.Current.GoToAsync($"//{nameof(HomePage)}");

	//	base.OnStart();
	//}
}
