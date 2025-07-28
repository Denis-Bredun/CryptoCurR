using CryptoCurR.DTOs;
using CryptoCurR.Interfaces;
using CryptoCurR.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.Services
{
    public class CoinDetailsMapper : ICoinDetailsMapper
    {
        public CoinDetailsLoadDto MapToDto(
            CoinDetailModel coinDetail,
            CoinTickersResponse coinTickers,
            MarketChartData marketChart,
            List<OhlcCandle> ohlcCandles)
        {
            return new(
                coinDetail,
                coinTickers,
                marketChart,
                ohlcCandles
            );
        }

        public CoinChartDataDto MapToDto(
            MarketChartData marketChart,
            List<OhlcCandle> ohlcCandles)
        {
            return new(
                marketChart,
                ohlcCandles
            );
        }

        public (CoinDetailModel, CoinTickersResponse, MarketChartData, ObservableCollection<OhlcCandle>)
            MapFromDto(CoinDetailsLoadDto dto)
        {
            return (
                dto.CoinDetail ?? new(),
                dto.CoinTickers ?? new(),
                dto.MarketChart ?? new(),
                new ObservableCollection<OhlcCandle>(dto.OhlcCandles) ?? []
            );
        }

        public (MarketChartData, ObservableCollection<OhlcCandle>) MapFromDto(CoinChartDataDto dto)
        {
            return (
                dto.MarketChart ?? new(),
                new ObservableCollection<OhlcCandle>(dto.OhlcCandles) ?? []
            );
        }
    }
}
