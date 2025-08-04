using CryptoCurR.Models;

namespace CryptoCurR.Interfaces
{
    public interface ICoinGeckoParser
    {
        CoinDetailModel? ParseCoinDetails(string json);
        MarketChartData? ParseMarketChart(string json);
        List<OhlcCandle>? ParseOhlc(string json);
        CoinSearchResult? ParseSearchResult(string json);
        CoinTickersResponse? ParseTickers(string json);
        List<CoinMarketModel>? ParseTopCoins(string json);
        SimplePriceModel? ParseSimplePrice(string json);
    }
}
