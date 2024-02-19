namespace InventarioMobileApp.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterViewModel viewlModel)
	{
		InitializeComponent();
		BindingContext = viewlModel;
	}
}