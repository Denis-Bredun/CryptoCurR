using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoCurR.Constants;
using CryptoCurR.Converters;
using CryptoCurR.Interfaces;
using CryptoCurR.Models;
using CryptoCurR.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.ViewModels
{
    public partial class CoinDetailsViewModel(
            ICoinDetailsLoader loader,
            ICoinDetailsMapper mapper,
            INavigationService navigationService) : ObservableObject
    {
        [ObservableProperty]
        private CoinDetailModel? _coinDetail;

        [ObservableProperty]
        private CoinTickersResponse? _coinTickers;

        [ObservableProperty]
        private ObservableCollection<OhlcCandle>? _ohlcCandles;

        [ObservableProperty]
        private MarketChartData? _marketChart;

        [ObservableProperty]
        private bool _isLoading;

        [ObservableProperty]
        private int _selectedTimeframe = DefaultArguments.DefaultPeriodInDays;

        [ObservableProperty]
        private bool isLineChart = DefaultArguments.DefaultIsLineChart;

        public bool IsCandlestickChart => !IsLineChart;
        public List<int> AvailableTimeframes { get; } = DefaultArguments.AvailableTimeframes;
        public Func<double, string> DateLabelFormatter { get; } = DefaultArguments.DateLabelFormatter;
        public Func<double, string> OhlcLabelFormatter { get; } = DefaultArguments.OhlcLabelFormatter;

        partial void OnIsLineChartChanged(bool value)
        {
            OnPropertyChanged(nameof(IsCandlestickChart));
        }

        public async Task InitializeAsync(string coinId)
        {
            IsLoading = true;

            var dto = await loader.LoadAllAsync(coinId, SelectedTimeframe);
            (CoinDetail, CoinTickers, MarketChart, OhlcCandles) = mapper.MapFromDto(dto);

            IsLoading = false;
        }

        [RelayCommand]
        private async Task ChangeTimeframeAsync(int days)
        {
            if (days == SelectedTimeframe)
                return;

            SelectedTimeframe = days;
            await LoadChartDataAsync();
        }

        [RelayCommand]
        private async Task GoBackAsync()
        {
            IsLoading = true;
            await navigationService.NavigateToMainAsync();
            IsLoading = false;
        }

        [RelayCommand]
        private void OpenTradeUrl(string url)
        {
            if (!string.IsNullOrWhiteSpace(url))
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
        }

        private async Task LoadChartDataAsync()
        {
            IsLoading = true;

            var dto = await loader.LoadChartAsync(CoinDetail.Id, SelectedTimeframe);
            (MarketChart, OhlcCandles) = mapper.MapFromDto(dto);

            IsLoading = false;
        }
    }
}
