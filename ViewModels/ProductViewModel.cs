using InventarioMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioMobileApp.ViewModels
{
    public partial class ProductViewModel : BaseViewModel
    {

        [ObservableProperty]
        InventoryModel model;

        public ProductViewModel()
        {
            
        }

        [RelayCommand]
        public async Task Salvar(){ }

        [RelayCommand]
        public async Task AlterarStatus(){ }

    }
}
