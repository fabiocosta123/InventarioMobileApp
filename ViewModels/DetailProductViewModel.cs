using InventarioMobileApp.Data;
using InventarioMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioMobileApp.ViewModels
{
    [QueryProperty(nameof(Model), nameof(Model))]
    public partial class DetailProductViewModel : BaseViewModel
    {
        [ObservableProperty]
        InventoryModel model;

        [ObservableProperty]
        int quantidadeAtual = 1;

        private readonly ICSVRepository _repository;

        public DetailProductViewModel(ICSVRepository repository)
        {
            _repository = repository;
        }

        [RelayCommand]
        public async Task Salvar()
        {
            Model.qtd = QuantidadeAtual;
            _repository.Update(Model);
            await Shell.Current.DisplayAlert("Salvo", "Item salvo com sucesso", "OK");
            
        }

        [RelayCommand]
        public async Task AlterarStatus()
        {
            await Shell.Current.DisplayAlert("Alterado", "Item marcado com sucesso", "OK");
        }
    }
}
