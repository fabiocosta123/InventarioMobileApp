namespace InventarioMobileApp.Views;

public partial class DownloadPage : ContentPage
{
	public DownloadPage(DownloadViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

   
}