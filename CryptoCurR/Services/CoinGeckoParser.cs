using CryptoCurR.Interfaces;
using CryptoCurR.Models;
using System.Text.Json;

namespace CryptoCurR.Services
{
    public class CoinGeckoParser : ICoinGeckoParser
    {
        private static readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public List<CoinMarketModel>? ParseTopCoins(string json)
        {
            return JsonSerializer.Deserialize<List<CoinMarketModel>>(json, _options);
        }

        public CoinDetailModel? ParseCoinDetails(string json)
        {
            return JsonSerializer.Deserialize<CoinDetailModel>(json, _options);
        }

        public CoinSearchResult? ParseSearchResult(string json)
        {
            return JsonSerializer.Deserialize<CoinSearchResult>(json, _options);
        }

        public MarketChartData? ParseMarketChart(string json)
        {
            return JsonSerializer.Deserialize<MarketChartData>(json, _options);
        }

        public CoinTickersResponse? ParseTickers(string json)
        {
            return JsonSerializer.Deserialize<CoinTickersResponse>(json, _options);
        }

        public List<OhlcCandle>? ParseOhlc(string json)
        {
            var rawCandles = JsonSerializer.Deserialize<List<List<decimal>>>(json, _options);

            return rawCandles?
                .Select(c => new OhlcCandle
                {
                    Timestamp = FromUnixTimeMilliseconds((long)c[0]),
                    Open = c[1],
                    High = c[2],
                    Low = c[3],
                    Close = c[4]
                })
                .ToList();
        }

        private DateTime FromUnixTimeMilliseconds(long ms)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(ms).UtcDateTime;
        }
    }
}
