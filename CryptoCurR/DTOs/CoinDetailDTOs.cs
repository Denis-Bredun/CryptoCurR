using CryptoCurR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.DTOs
{
    public record class CoinChartDataDto(
        MarketChartData? MarketChart, 
        List<OhlcCandle> OhlcCandles);

    public record class CoinDetailsLoadDto(
    CoinDetailModel? CoinDetail,
    CoinTickersResponse? CoinTickers,
    MarketChartData? MarketChart,
    List<OhlcCandle> OhlcCandles);
}
