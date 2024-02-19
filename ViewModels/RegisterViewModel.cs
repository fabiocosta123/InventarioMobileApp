using InventarioMobileApp.Models.Request;
using InventarioMobileApp.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioMobileApp.ViewModels
{
    public partial class RegisterViewModel : BaseViewModel
    {
        [ObservableProperty]
        string email;
        [ObservableProperty]
        string password;

        private readonly ILoginRepository _repository;

        public RegisterViewModel(ILoginRepository repository)
        {
            _repository = repository;
        }

        [RelayCommand]
        public async Task Register()
        {
            try
            {

                if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                {
                    await Shell.Current.DisplayAlert("Error", "Email and Password are required", "Ok");
                    return;
                }

                var request = new RegisterRequest(Email, Password);
                var result = await _repository.RegisterAsync(request);

                if (!result)
                {
                    await Shell.Current.DisplayAlert("Error", "Falha ao cadastrar usuário", "Ok");
                    return;
                }

                
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                await Shell.Current.DisplayAlert("Error", "Falha ao cadastrar usuário", "Ok");

            }
        }
    }

}

