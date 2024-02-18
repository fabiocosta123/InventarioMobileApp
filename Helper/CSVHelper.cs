using CsvHelper;
using CsvHelper.Configuration;

namespace InventarioMobileApp.Helper
{
    public class CSVHelper
    {
        public static IEnumerable<T> ReadFromCsv<T>(string filePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                DetectDelimiter = true,
            };

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                return csv.GetRecords<T>().ToList();
            }
        }
    }
}
