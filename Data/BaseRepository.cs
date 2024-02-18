using LiteDB;

namespace InventarioMobileApp.Data
{
    public abstract class BaseRepository
    {
        private static LiteDatabase db = null;

        protected static LiteDatabase _db 
        {
            get 
            {
                if(db is null)
                    db  = new LiteDatabase(GetPath());

                return db;
            }
        }

        private static string GetPath()
        {
            var path = FileSystem.Current.AppDataDirectory;

            return Path.Combine(path, "app.db");
        }
    }
}
