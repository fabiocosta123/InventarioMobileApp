using InventarioMobileApp.Models;

namespace InventarioMobileApp.Data
{
    public class CSVRepository : BaseRepository, ICSVRepository
    {
        public CSVRepository() : base()
        {
            
        }

        public void AddRange(IEnumerable<InventoryModel> items)
        {
            var collection = _db.GetCollection<InventoryModel>();
            collection.Insert(items);
        }

        public void DeleteAll()
        {
            var collectionNames = _db.GetCollectionNames();

            foreach(var collectionName in collectionNames)
                _db.DropCollection(collectionName);
        }

        public IEnumerable<InventoryModel> GetAll()
        {
            var collection = _db.GetCollection<InventoryModel>();
            return collection.FindAll();
        }

        public InventoryModel? GetByBarcode(string barcode)
        {
            var collection = _db.GetCollection<InventoryModel>();
            return collection.FindOne(x=>x.Ean == barcode);
        }

        public void Update(InventoryModel item)
        {
            var collection = _db.GetCollection<InventoryModel>();
            collection.Upsert(item);
        }
    }
}
