using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoCurR.Constants;
using CryptoCurR.Interfaces;
using CryptoCurR.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.ViewModels
{
    public partial class CoinDetailsViewModel(
            ICoinDetailsLoader loader,
            ICoinDetailsMapper mapper) : ObservableObject
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

        public List<int> AvailableTimeframes { get; } = DefaultArguments.AvailableTimeframes;

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

        private async Task LoadChartDataAsync()
        {
            IsLoading = true;

            var dto = await loader.LoadChartAsync(CoinDetail.Id, SelectedTimeframe);
            (MarketChart, OhlcCandles) = mapper.MapFromDto(dto);

            IsLoading = false;
        }
    }
}
