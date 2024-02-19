using Flurl;
using Flurl.Http;
using InventarioMobileApp.Helper;
using InventarioMobileApp.Models.Request;
using InventarioMobileApp.Models.Response;
using InventarioMobileApp.Repositories.Contract;

namespace InventarioMobileApp.Repositories.Implementation
{
    public class LoginRepository : ILoginRepository
    {
        public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
        {
            try
            {
                var result = await AppConstant.BaseUrl
               .AppendPathSegment("/identity/login")
               .PostJsonAsync(loginRequest);

                if (result.ResponseMessage.IsSuccessStatusCode)
                {
                    var response = await result.ResponseMessage.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<LoginResponse>(response);
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw;
            }

            return new();
        }

        public async Task<bool> RegisterAsync(RegisterRequest registerRequest)
        {
            try
            {
                var result = await AppConstant.BaseUrl
               .AppendPathSegment("/identity/register")
               .PostJsonAsync(registerRequest);

                return result.ResponseMessage.IsSuccessStatusCode;
               
               
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw;
            }

        }
    }
}
