using Flurl;
using Flurl.Http;
using InventarioMobileApp.Helper;
using InventarioMobileApp.Repositories.Contract;

namespace InventarioMobileApp.Repositories.Implementation
{
    public class InventoryRepository : IInventoryRepository
    {
        public async Task<string> DownloadAsync()
        {
            try
            {
                var result = await AppConstant.BaseUrl
                                .AppendPathSegment("/inventory")
                                .WithOAuthBearerToken(Preferences.Get("AccessToken", string.Empty))
                                .GetAsync();

                if (result.ResponseMessage.IsSuccessStatusCode)
                {
                    return await result.ResponseMessage.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw;
            }

            return string.Empty;
        }

        public async Task<bool> UploadAsync(string filePath)
        {
            try
            {
                using (var fileStream = new FileStream(filePath, FileMode.Open))
                {
                    var multipartContent = new MultipartFormDataContent();
                    multipartContent.Add(new StreamContent(fileStream), "file", "estoque.csv");

                    var response = await AppConstant.BaseUrl
                                .AppendPathSegment("/inventory")
                                .WithOAuthBearerToken(Preferences.Get("AccessToken", string.Empty))
                                .PostAsync(multipartContent);

                    return response.ResponseMessage.IsSuccessStatusCode;

                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw;
            }
        }
    }
}
