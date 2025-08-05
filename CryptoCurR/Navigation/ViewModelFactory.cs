using CryptoCurR.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.Navigation
{
    public class ViewModelFactory(IServiceProvider provider) : IViewModelFactory
    {
        public async Task<MainPageViewModel> CreateMainPageViewModel()
        {
            var vm = provider.GetRequiredService<MainPageViewModel>();
            await vm.LoadTopCoinsAsync();
            return vm;
        }

        public async Task<CoinDetailsViewModel> CreateCoinDetailsViewModel(string coinId)
        {
            var vm = provider.GetRequiredService<CoinDetailsViewModel>();
            await vm.InitializeAsync(coinId);
            return vm;
        }

        public async Task<CurrencyConverterViewModel> CreateCurrencyConverterViewModel()
        {
            var vm = provider.GetRequiredService<CurrencyConverterViewModel>();
            await vm.InitializeAsync();
            return vm;
        }
    }
}
