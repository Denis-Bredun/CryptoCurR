using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.Navigation
{
    public class NavigationService(
        NavigationStore navigationStore, 
        IViewModelFactory viewModelFactory) : INavigationService
    {
        public async Task NavigateToMainAsync()
        {
            var mainVm = await viewModelFactory.CreateMainPageViewModel();
            navigationStore.CurrentViewModel = mainVm;
        }

        public async Task NavigateToCoinDetailsAsync(string coinId)
        {
            var detailsVm = await viewModelFactory.CreateCoinDetailsViewModel(coinId);
            navigationStore.CurrentViewModel = detailsVm;
        }

        public async Task NavigateToCurrencyConverterAsync()
        {
            var converterVm = await viewModelFactory.CreateCurrencyConverterViewModel();
            navigationStore.CurrentViewModel = converterVm;
        }
    }
}
