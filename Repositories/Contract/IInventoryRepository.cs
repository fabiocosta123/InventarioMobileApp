namespace InventarioMobileApp.Repositories.Contract
{
    public interface IInventoryRepository
    {
        Task<String> DownloadAsync();
        Task<bool> UploadAsync(string filePath);
    }
}
