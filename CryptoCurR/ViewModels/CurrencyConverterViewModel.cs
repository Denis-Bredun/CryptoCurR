using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoCurR.Constants;
using CryptoCurR.Interfaces;
using CryptoCurR.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCurR.ViewModels
{
    public partial class CurrencyConverterViewModel(
            ICurrencyConverterService currencyConverterService) : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<CoinMarketModel> _fromCurrencies = new();

        [ObservableProperty]
        private ObservableCollection<CoinMarketModel> _toCurrencies = new();

        [ObservableProperty]
        private CoinMarketModel? _selectedFromCurrency;

        [ObservableProperty]
        private CoinMarketModel? _selectedToCurrency;

        [ObservableProperty]
        private decimal _amount = DefaultArguments.DefaultConverterAmount;

        [ObservableProperty]
        private decimal _convertedAmount;

        [ObservableProperty]
        private bool _isLoading;

        private bool _isSwitching;

        partial void OnAmountChanged(decimal value)
        {
            if (CanConvert())
            {
                _ = ConvertAsync();
            }
        }

        partial void OnSelectedFromCurrencyChanged(CoinMarketModel? value)
        {
            if (CanConvertWithSwitchCheck())
            {
                _ = ConvertAsync();
            }
        }

        partial void OnSelectedToCurrencyChanged(CoinMarketModel? value)
        {
            if (CanConvertWithSwitchCheck())
            {
                _ = ConvertAsync();
            }
        }        

        public async Task InitializeAsync()
        {
            IsLoading = true;

            var coins = await currencyConverterService.LoadCurrenciesAsync();
            FromCurrencies.Clear();
            ToCurrencies.Clear();

            foreach (var coin in coins)
            {
                FromCurrencies.Add(coin);
                ToCurrencies.Add(coin);
            }

            SelectedFromCurrency = FromCurrencies.First();
            SelectedToCurrency = ToCurrencies.Skip(1).FirstOrDefault();

            await ConvertAsync();

            IsLoading = false;
        }

        [RelayCommand]
        private async Task ConvertAsync()
        {
            IsLoading = true;

            ConvertedAmount = await currencyConverterService.ConvertCurrencyAsync(
                SelectedFromCurrency.Id,
                SelectedToCurrency.Id,
                SelectedToCurrency.Symbol,
                Amount);

            IsLoading = false;
        }

        [RelayCommand]
        private void SwitchCurrencies()
        {
            _isSwitching = true;

            (SelectedFromCurrency, SelectedToCurrency) = (SelectedToCurrency, SelectedFromCurrency);

            if (ConvertedAmount > 0)
            {
                (Amount, ConvertedAmount) = (ConvertedAmount, Amount);
            }
            else
            {
                _ = ConvertAsync();
            }

            _isSwitching = false;
        }

        private bool CanConvert()
        {
            return Amount > 0 && SelectedFromCurrency != null && SelectedToCurrency != null;
        }

        private bool CanConvertWithSwitchCheck()
        {
            return !_isSwitching && CanConvert();
        }
    }
} 