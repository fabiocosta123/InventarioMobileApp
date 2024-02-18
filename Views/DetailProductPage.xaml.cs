namespace InventarioMobileApp.Views;

public partial class DetailProductPage : ContentPage
{
	public DetailProductPage(DetailProductViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}