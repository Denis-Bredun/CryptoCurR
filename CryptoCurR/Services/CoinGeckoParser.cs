using CryptoCurR.Interfaces;
using CryptoCurR.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CryptoCurR.Services
{
    public class CoinGeckoParser : ICoinGeckoParser
    {
        private static readonly JsonSerializerSettings _settings = new()
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        public List<CoinMarketModel>? ParseTopCoins(string json)
        {
            return JsonConvert.DeserializeObject<List<CoinMarketModel>>(json, _settings);
        }

        public CoinDetailModel? ParseCoinDetails(string json)
        {
            return JsonConvert.DeserializeObject<CoinDetailModel>(json, _settings);
        }

        public CoinSearchResult? ParseSearchResult(string json)
        {
            return JsonConvert.DeserializeObject<CoinSearchResult>(json, _settings);
        }

        public MarketChartData? ParseMarketChart(string json)
        {
            return JsonConvert.DeserializeObject<MarketChartData>(json, _settings);
        }

        public CoinTickersResponse? ParseTickers(string json)
        {
            return JsonConvert.DeserializeObject<CoinTickersResponse>(json, _settings);
        }

        public List<OhlcCandle>? ParseOhlc(string json)
        {
            var rawCandles = JsonConvert.DeserializeObject<List<List<decimal>>>(json, _settings);

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

        public SimplePriceModel? ParseSimplePrice(string json)
        {
            return JsonConvert.DeserializeObject<SimplePriceModel>(json, _settings) ?? new();
        }
    }
}
