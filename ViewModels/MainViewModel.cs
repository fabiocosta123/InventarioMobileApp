using InventarioMobileApp.Models.Request;
using InventarioMobileApp.Repositories.Contract;

namespace InventarioMobileApp.ViewModels;

public partial class MainViewModel : BaseViewModel
{

    [ObservableProperty]
    string email;

    [ObservableProperty]
    string password;

    private readonly ILoginRepository _repository;
    public MainViewModel(ILoginRepository repository)
    {
        _repository = repository;
    }

    [RelayCommand]
    public async Task Login()
    {
        try
        {

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                await Shell.Current.DisplayAlert("Error", "Email and Password are required", "Ok");
                return;
            }

            var request = new LoginRequest(Email, Password);
            var result = await _repository.LoginAsync(request);

            if (string.IsNullOrEmpty(result.accessToken))
            {
                await Shell.Current.DisplayAlert("Error", "Falha ao realizar login", "Ok");
                return;
            }

            Preferences.Set("AccessToken", result.accessToken);
            Preferences.Set("RefreshToken", result.refreshToken);
            Preferences.Set("ExpiresIn", result.expiresIn);

            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
        catch (Exception ex)
        {
            var msg = ex.Message;
            await Shell.Current.DisplayAlert("Error", "Falha ao realizar login", "Ok");
            
        }
    }

    [RelayCommand]
    public async Task PrimeiroAcesso()
    {
        await Shell.Current.GoToAsync($"{nameof(RegisterPage)}");
    }

   
}
