using InventarioMobileApp.Models.Request;
using InventarioMobileApp.Models.Response;

namespace InventarioMobileApp.Repositories.Contract
{
    public interface ILoginRepository
    {
        Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
    }
}
