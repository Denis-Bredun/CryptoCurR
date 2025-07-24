using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.Constants
{
    public static class CoinGeckoApi
    {
        public const string BaseUrl = "https://api.coingecko.com/api/v3";

        public const string CoinsMarketsEndpoint = "/coins/markets";

        public const string CoinByIdEndpoint = "/coins/{0}";

        public const string SearchEndpoint = "/search?query={0}";

        public const string MarketChartEndpoint = "/coins/{0}/market_chart";

        public const string OhlcEndpoint = "/coins/{0}/ohlc";

        public const string TickersEndpoint = "/coins/{0}/tickers";

        public static string GetMarketsUrl(
            string vsCurrency = DefaultArguments.VsCurrency, 
            int perPage = DefaultArguments.CoinsMarketsPerPage, 
            int page = DefaultArguments.CoinsMarketsDefaultPage)
        {
            return $"{BaseUrl}{CoinsMarketsEndpoint}?vs_currency={vsCurrency}&order=market_cap_desc&per_page={perPage}&page={page}";
        }

        public static string GetCoinUrl(string id)
        {
            return string.Format($"{BaseUrl}{CoinByIdEndpoint}", id);
        }

        public static string GetSearchUrl(string query)
        {
            return string.Format($"{BaseUrl}{SearchEndpoint}", Uri.EscapeDataString(query));
        }

        public static string GetMarketChartUrl(
            string id, 
            int days = DefaultArguments.DefaultPeriodInDays, 
            string vsCurrency = DefaultArguments.VsCurrency)
        {
            return string.Format($"{BaseUrl}{MarketChartEndpoint}?vs_currency={vsCurrency}&days={days}", id);
        }

        public static string GetOhlcUrl(
            string id, 
            int days = DefaultArguments.DefaultPeriodInDays, 
            string vsCurrency = DefaultArguments.VsCurrency)
        {
            return string.Format($"{BaseUrl}{OhlcEndpoint}?vs_currency={vsCurrency}&days={days}", id);
        }

        public static string GetTickersUrl(string id)
        {
            return string.Format($"{BaseUrl}{TickersEndpoint}", id);
        }
    }
}
