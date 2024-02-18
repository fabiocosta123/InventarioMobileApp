using CommunityToolkit.Mvvm.Messaging;
using InventarioMobileApp.Data;
using InventarioMobileApp.Helper;
using InventarioMobileApp.Models;
using InventarioMobileApp.Repositories.Contract;
using Mopups.Services;
using System.Text;

namespace InventarioMobileApp.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {
        private readonly IInventoryRepository _repository;
        private readonly ICSVRepository _csvRepository;

        public HomeViewModel(IInventoryRepository repository, ICSVRepository csvRepository)
        {
            _repository = repository;
            _csvRepository = csvRepository;
        }

        [RelayCommand]
        public async Task Download()
        {
            try
            {
                var data = await _repository.DownloadAsync();
                if (string.IsNullOrEmpty(data))
                {
                    await Shell.Current.DisplayAlert("Error", "Falha ao realizar download", "Ok");
                    return;
                }

                var status = await Permissions.RequestAsync<Permissions.StorageWrite>();
                if (status != PermissionStatus.Granted)
                {
                    await Shell.Current.DisplayAlert("Error", "Permissão de escrita negada", "Ok");
                    return;
                }

                if (status != PermissionStatus.Granted)
                    return;

                var stream = new MemoryStream(Encoding.UTF8.GetBytes(data));
                var initialPath = FileSystem.Current.AppDataDirectory;

                var filePath = System.IO.Path.Combine(initialPath, "estoque.csv");
                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await stream.CopyToAsync(fileStream);
                }

                Preferences.Set("FilePath", filePath);

                var items = CSVHelper.ReadFromCsv<InventoryModel>(filePath);

                _csvRepository.DeleteAll();
                _csvRepository.AddRange(items);
                await Shell.Current.DisplayAlert("DOWNLOAD", "Download realizado com sucesso", "OK");
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw;
            }


        }

        [RelayCommand]
        public async Task BarCode()
        {
        }

        [RelayCommand]
        public async Task ReadBarCode()
        {
            await Shell.Current.GoToAsync($"{nameof(BarcodePage)}");
        }

        public async Task InitAsync()
        {

            var result = WeakReferenceMessenger.Default.IsRegistered<string>(this);

            if (result) return;

            WeakReferenceMessenger.Default.Register<string>(this, async (recipient, barCode) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (string.IsNullOrEmpty(barCode))
                        return;

                    var inventoryModel = _csvRepository.GetByBarcode(barCode);

                    if(inventoryModel is null)
                    {
                        await Shell.Current.DisplayAlert("Atenção",$"Código {barCode} não cadastrado", "OK");
                        return;
                    }
                       

                    var parametros = new Dictionary<string, object>
                    {
                        { "Model", inventoryModel}
                    };

                    await Shell.Current.GoToAsync(nameof(DetailProductPage), parametros);
                });
            });
        }
    }
}
