using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoCurR.Interfaces;
using CryptoCurR.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToastNotifications.Messages.Error;

namespace CryptoCurR.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly ICryptoListService _cryptoListService;        

        [ObservableProperty]
        private ObservableCollection<CoinMarketModel> _coins;

        [ObservableProperty]
        private CoinMarketModel _selectedCoin;

        [ObservableProperty]
        private string? _searchQuery;

        [ObservableProperty]
        private bool _isLoading;

        [ObservableProperty]
        private int _currentPage = 1;

        [ObservableProperty]
        private int _coinsPerPage = 10;

        public MainPageViewModel(ICryptoListService cryptoListService)
        {
            _cryptoListService = cryptoListService;
            Coins = new ObservableCollection<CoinMarketModel>();
        }

        public async Task InitializeAsync()
        {
            await LoadTopCoinsAsync();
        }

        [RelayCommand]
        private async Task LoadTopCoinsAsync()
        {
            IsLoading = true;
            var result = await _cryptoListService.LoadTopCoinsAsync(CurrentPage, CoinsPerPage);
            Coins = new ObservableCollection<CoinMarketModel>(result);
            IsLoading = false;
        }

        [RelayCommand]
        private async Task SearchCoinsAsync()
        {
            IsLoading = true;
            var result = await _cryptoListService.SearchCoinsAsync(SearchQuery ?? string.Empty);
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
        private void NavigateToCoinDetails(CoinMarketModel selectedCoin)
        {
        }
    }
}
