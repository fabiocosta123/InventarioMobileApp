
using CsvHelper;
using CsvHelper.Configuration;
using InventarioMobileApp.Data;
using InventarioMobileApp.Repositories.Contract;

namespace InventarioMobileApp.ViewModels
{
    public partial class UploadViewModel : BaseViewModel
    {
        private readonly ICSVRepository _csvRepository;
        private readonly IInventoryRepository _repository;

        public UploadViewModel(ICSVRepository csvRepository, IInventoryRepository repository)
        {
            _csvRepository = csvRepository;
            _repository = repository;
        }

        [RelayCommand]
        public async Task Upload()
        {
            var products = _csvRepository.GetAll();

            var filePath = Preferences.Get("FilePath", string.Empty);

            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.WriteRecords(products);
            }

            if (!File.Exists(filePath))
                return;

            string fileContent = File.ReadAllText(filePath);

            var result = await _repository.UploadAsync(filePath);

            if (result)
            {
                await Shell.Current.DisplayAlert("SUCESSO", "Arquivo enviado com sucesso", "OK");
            }
        }
    }
}
