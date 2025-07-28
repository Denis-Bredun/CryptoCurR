using CryptoCurR.DTOs;
using CryptoCurR.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.Interfaces
{
    public interface ICoinDetailsMapper
    {
        CoinDetailsLoadDto MapToDto(
            CoinDetailModel coinDetail,
            CoinTickersResponse coinTickers,
            MarketChartData marketChart,
            List<OhlcCandle> ohlcCandles);
        CoinChartDataDto MapToDto(
            MarketChartData marketChart,
            List<OhlcCandle> ohlcCandles);

        (CoinDetailModel, 
            CoinTickersResponse, 
            MarketChartData,
            ObservableCollection<OhlcCandle>) MapFromDto(CoinDetailsLoadDto dto);
        (MarketChartData,
            ObservableCollection<OhlcCandle>) MapFromDto(CoinChartDataDto dto);
    }
}
