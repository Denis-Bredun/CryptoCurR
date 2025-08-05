using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoCurR.Constants;
using CryptoCurR.Interfaces;
using CryptoCurR.Models;
using CryptoCurR.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToastNotifications.Messages.Error;

namespace CryptoCurR.ViewModels
{
    public partial class MainPageViewModel(
        ICryptoListService cryptoListService,
        INavigationService navigationService) : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<CoinMarketModel> _coins = new ObservableCollection<CoinMarketModel>();

        [ObservableProperty]
        private CoinMarketModel _selectedCoin;

        [ObservableProperty]
        private string? _searchQuery;

        [ObservableProperty]
        private bool _isLoading;

        [ObservableProperty]
        private int _currentPage = DefaultArguments.CoinsMarketsDefaultPage;

        [ObservableProperty]
        private int _coinsPerPage = DefaultArguments.CoinsMarketsPerPage;

        public async Task LoadTopCoinsAsync()
        {
            IsLoading = true;
            var result = await cryptoListService.LoadTopCoinsAsync(CurrentPage, CoinsPerPage);
            Coins = new ObservableCollection<CoinMarketModel>(result);
            SelectedCoin = Coins.FirstOrDefault() ?? new();
            IsLoading = false;
        }

        [RelayCommand]
        private async Task SearchCoinsAsync()
        {
            IsLoading = true;
            var result = await cryptoListService.SearchCoinsAsync(SearchQuery ?? string.Empty);
            Coins = new ObservableCollection<CoinMarketModel>(result);
            IsLoading = false;
        }

        [RelayCommand]
        private async Task NextPageAsync()
        {
            CurrentPage++;
            await LoadTopCoinsAsync();
        }

        [RelayCommand]
        private async Task PreviousPageAsync()
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
                await LoadTopCoinsAsync();
            }
        }

        [RelayCommand]
        private async Task IncreasePageSizeAsync()
        {
            CoinsPerPage += 10;
            CurrentPage = 1;
            await LoadTopCoinsAsync();
        }

        [RelayCommand]
        private async Task DecreasePageSizeAsync()
        {
            if (CoinsPerPage > 10)
            {
                CoinsPerPage -= 10;
                CurrentPage = 1;
                await LoadTopCoinsAsync();
            }
        }

        [RelayCommand]
        private async Task ResetAsync()
        {
            CoinsPerPage = 10;
            CurrentPage = 1;
            SearchQuery = "";
            await LoadTopCoinsAsync();
        }

        [RelayCommand]
        private async Task NavigateToCoinDetailsAsync(CoinMarketModel selectedCoin)
        {
            IsLoading = true;
            await navigationService.NavigateToCoinDetailsAsync(selectedCoin?.Id);
            IsLoading = false;
        }

        [RelayCommand]
        private async Task NavigateToCurrencyConverterAsync()
        {
            IsLoading = true;
            await navigationService.NavigateToCurrencyConverterAsync();
            IsLoading = false;
        }
    }
}
