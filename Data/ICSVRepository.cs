using InventarioMobileApp.Models;

namespace InventarioMobileApp.Data
{
    public interface ICSVRepository
    {
        void AddRange(IEnumerable<InventoryModel> items);
        IEnumerable<InventoryModel> GetAll();
        void Update(InventoryModel item);
        void DeleteAll();
        InventoryModel? GetByBarcode(string barcode);
    }
}
